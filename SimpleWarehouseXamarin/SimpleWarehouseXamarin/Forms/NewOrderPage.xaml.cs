using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Newtonsoft.Json;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using SimpleWarehouseXamarin.Helper;
using SimpleWarehouseXamarin.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Currency = SimpleWarehouseMobil.Models.Currency;
using VwProduct = SimpleWarehouseMobil.Models.VwProduct;

namespace SimpleWarehouseXamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        private ProductVariant currentProductVariant;

        public Order Order;
        private ObservableCollection<VwOrderDetails> _orderDetails;

        private List<Currency> _currencies;
        private List<Unit> _units;
        private List<Warehouse> _warehouses;

        private string searchType = "barcode";

        private readonly Dictionary<string, Func<Task<VwProduct>>> SearchMethods;

        private VwOrderDetails _isUpdate;
        private NewOrderLine _updateOrderLine;

        public NewOrderPage(int orderType, Order ord = null)
        {
            SearchMethods = new Dictionary<string, Func<Task<VwProduct>>>
            {
                { "barcode", SearchByBarcode },
                { "productCode", SearchByCode },
                { "productName", SearchByName }
            };

            InitializeComponent();
            _orderDetails = new ObservableCollection<VwOrderDetails>();
            _orderDetails.CollectionChanged += _orderDetails_CollectionChanged;
            lvOrderItems.ItemsSource = _orderDetails;
            Order = ord ?? new Order();
            var cvl = new ContentView[] { r, w };
            cvl[orderType - 1].IsVisible = false;
            var contentView = cvl[^orderType];
            contentView.BindingContext = Order;
            Title = contentView.FindByName<Label>("lblCaption").Text;
            LoadCurrency();
            LoadUnit();
            LoadWarehouse();
            sbSearch.Focus();
        }

        private void _orderDetails_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (_orderDetails.Count == 0)
            {
                lblTotal.Text = $"{0:F}";
                lblVat.Text = $"{0:F}";
                return;
            }

            CalculatePrice();
        }

        private void CalculatePrice()
        {
            var totalPrice = _orderDetails.Sum(q => q.Price * q.Quantity);
            var totalVat = _orderDetails.Sum(q => q.Price * q.Quantity * q.VatPercent / 100);
            lblTotal.Text = $"{totalPrice:F} {_orderDetails[0].CurrencyCode}";
            lblVat.Text = $"{totalVat:F} {_orderDetails[0].CurrencyCode}";
        }

        private async void LoadWarehouse()
        {
            _warehouses = await ApiHelper.GetWarehouseList();
            pckWarehouse.ItemsSource = _warehouses;
        }

        private async void LoadUnit()
        {
            _units = await ApiHelper.GetUnitList();
            pckStokUnit.ItemsSource = _units;
        }

        private async void LoadCurrency()
        {
            _currencies = await ApiHelper.GetCurrencyList();
            pckCurrency.ItemsSource = _currencies;
        }


        private async void ImgbtnSaveOrder_OnClicked(object sender, EventArgs e)
        {
            Element orderElement = r.IsVisible ? (Element)r : w;
            var customer = orderElement.GetType().GetProperty("CurrentCustomer", BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public).GetValue(orderElement) as VwCustomer;
            var orderCode = orderElement.GetType().GetProperty("OrderNumber", BindingFlags.Instance |
                                                                              BindingFlags.NonPublic |
                                                                              BindingFlags.Public).GetValue(orderElement)?.ToString();
            var docNumber = orderElement.GetType().GetProperty("DocNumber", BindingFlags.Instance |
                                                                            BindingFlags.NonPublic |
                                                                            BindingFlags.Public).GetValue(orderElement)?.ToString();
            var orderDate = (DateTime)orderElement.GetType().GetProperty("OrderDate", BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public).GetValue(orderElement);


            if (new object[] { customer, orderCode, docNumber, orderDate }.Any(q =>
                q == null || string.IsNullOrEmpty(q?.ToString())))
            {
                UserDialogs.Instance.Alert(
                    $"Hata Oluştu.{Environment.NewLine} Müşteri Bilgileri,Sipariş Kodu, Belge Numarası ve Sipariş Tarihi Alanları Boş Olmamalı");
                return;
            }


            var msgList = new List<string>();
            var retVal = true;
            if (string.IsNullOrEmpty(orderCode))
            {
                msgList.Add("Lütfen Sipariş Kodunu Giriniz.");
                retVal = false;
            }
            if (string.IsNullOrEmpty(customer.CustomerName))
            {
                msgList.Add("Lütfen Cari Bilgilerini Giriniz.");
                retVal = false;
            }
            if (_orderDetails.Count == 0)
            {
                msgList.Add("Lütfen Ürün Ekleyin.");
                retVal = false;
            }

            var msg = string.Join(Environment.NewLine, msgList);
            if (!retVal)
            {
                UserDialogs.Instance.Alert($"Aşağıdaki Hataları Giderin...{Environment.NewLine} {msg}", "Uyarı",
                    "Tamam");
                return;
            }

            try
            {


                var seperator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
                var totalPrice = Convert.ToDecimal(lblTotal.Text.Split(' ').FirstOrDefault().Replace(",", seperator).Replace(".", seperator));
                var totalVal = Convert.ToDecimal(lblVat.Text.Split(' ').FirstOrDefault().Replace(",", seperator).Replace(".", seperator));
                var fullOrder = new FullOrder()
                {
                    CustomerName = customer.CustomerName,
                    CustomerSurname = customer.CustomerSurname,
                    InvoiceAddress = customer.Address,
                    InvoiceAddress2 = customer.Address2,
                    CompanyName = customer.CompanyName,
                    OrderCode = orderCode,
                    CustomerCode = customer.CustomerCode,
                    Phone = customer.Phone,
                    TotalPrice = totalPrice,
                    CreatedDate = DateTime.Now,
                    CreatedId = SettingsHelper.UserName.UserId,
                    CurrencyId = _orderDetails.FirstOrDefault().CurrencyId,
                    CustomerId = customer.CustomerId,
                    DocNumber = docNumber,
                    InvoiceCityId = customer.CityId,
                    InvoiceCountryId = customer.CountryId,
                    InvoiceRegionId = customer.RegionId,
                    InvoiceTownId = customer.TownId,
                    IsDeleted = false,
                    Mail = customer.Mail,
                    OrderDate = orderDate,
                    OrderStatusId = 1,
                    OrderTypeId = r.IsVisible ? 1 : 2,
                    TaxNumber = customer.TaxNumber,
                    TaxOffice = customer.TaxOffice,
                    TotalVal = totalVal,
                    OrderDetails = GetDetails()
                };

                try
                {
                    var tmp = await ApiHelper.AddOrder(fullOrder);
                    UserDialogs.Instance.Alert("Sipariş Kaydedildi...", "Bilgi", "Tamam");
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert($"Hata Oluştu...{Environment.NewLine}{ex.Message}", "Hata", @"Tamam");
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }

        }



        private List<OrderDetail> GetDetails()
        {
            return _orderDetails.Select(q => q as OrderDetail).ToList();
        }

        private void NewOrderLine_OnDeleted(NewOrderLine orderline, VwOrderDetails orderdetails)
        {
            _orderDetails.Remove(orderdetails);
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            popupOverlay.IsVisible = false;
            ClearControls();
        }

        private void PopupOverlay_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "IsVisible")
            {
                NavigationPage.SetHasBackButton(this, !popupOverlay.IsVisible);
            }

            if (popupOverlay.IsVisible)
                sbSearch.Focus();
        }

        private void imgBtnAddItem_Clicked(object sender, EventArgs e)
        {
            popupOverlay.IsVisible = true;
        }

        private Dictionary<string, string> PlaceHolderDictionary = new Dictionary<string, string>()
        {
            {"barcode","Ürün Barkodu"},
            {"productCode","Ürün Kodu"},
            {"productName","Ürün Adı"}
        };
        private void rbSearchType(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                sbSearch.Placeholder = PlaceHolderDictionary[(sender as RadioButton).Value.ToString()];
                searchType = (sender as RadioButton).Value.ToString();
            }

        }

        private async void SbSearch_OnSearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                currentProductVariant = null;
                pckVariant.ItemsSource = null;
                var detail = await SearchMethods[searchType].Invoke();
                if (detail == null)
                    throw new Exception($"Ürün Bulunamadı...");
                popupOverlay.BindingContext = detail;
                pckStokUnit.SelectedItem = _units.FirstOrDefault(q => q.UnitId == detail.UnitId);
                pckWarehouse.SelectedIndex = 1;
                if (detail.HasVariant)
                {
                    var variantList = await ApiHelper.GetVProductVariantList(detail.ProductId);
                    pckVariant.ItemsSource = variantList;
                    pckVariant.SelectedItem =
                        variantList.FirstOrDefault(q => q.VariantId == currentProductVariant?.VariantId)??variantList[0];
                }

                var price = await ApiHelper.GerProductPrice(detail.ProductId, 1);
                if (price != null && price.Count > 0)
                {
                    txtPrice.Text = price[0].Price.ToString("F");
                    pckCurrency.SelectedItem =
                        (pckCurrency.ItemsSource as List<Currency>).FirstOrDefault(q =>
                            q.CurrencyId == price[0].CurrencyId);
                }

                sbSearch.Unfocus();
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.Alert($"İşlem Sırasında Hata Alındı...{Environment.NewLine}{exception.Message}",
                    "Hata", "Tamam");

            }
        }

        private async Task<VwProduct> SearchByBarcode()
        {
            var product = await ApiHelper.GetProductViewByBarcode(sbSearch.Text);
            if (product == null)
            {
                var subProduct = await ApiHelper.GetSubproductViewByBarcodes(sbSearch.Text);
                if (subProduct == null)
                    throw new Exception($"{sbSearch.Text} Barkodlu Ürün Bulunamadı...");

                product = await ApiHelper.GetProductViewById(subProduct.ProductId);
                currentProductVariant = subProduct;
            }
            return product;
        }
        private async Task<VwProduct> SearchByCode()
        {
            return await ApiHelper.GetProductViewByCode(sbSearch.Text);
        }

        private async Task<VwProduct> SearchByName()
        {
            return await ApiHelper.GetProductViewByName(sbSearch.Text);
        }

        private void ImgbtnAddDetail_OnClicked(object sender, EventArgs e)
        {
            var newoeDetails = new VwOrderDetails();
            SetProperty(newoeDetails);
            if (_isUpdate == null)
            {

                _orderDetails.Add(newoeDetails);
            }
            else
            {
                _orderDetails[Array.IndexOf(_orderDetails.ToArray(), _isUpdate)] = newoeDetails;
                //_isUpdate =newoeDetails;
                //_updateOrderLine.OrderDetail = _isUpdate;
                _isUpdate = null;
                _updateOrderLine = null;

                //CalculatePrice();
            }
            popupOverlay.IsVisible = false;
            ClearControls();
        }

        void SetProperty(VwOrderDetails vod)
        {
            var product = popupOverlay.BindingContext as VwProduct;

            vod.ProductId = product.ProductId;
            vod.WarehouseName = (pckWarehouse.SelectedItem as Warehouse).WarehouseName;
            vod.ProductCode = product.ProductCode;
            vod.ProductName = product.ProductName;
            vod.Barcode = product.Barcode;
            vod.CurrencyCode = (pckCurrency.SelectedItem as Currency).CurrencyCode;
            vod.UnitId = (pckStokUnit.SelectedItem as Unit).UnitId;
            vod.InOrOut = -1;
            vod.UnitName = (pckStokUnit.SelectedItem as Unit).UnitName;
            vod.CurrencyId = (pckCurrency.SelectedItem as Currency).CurrencyId;
            vod.CurrencyName = (pckCurrency.SelectedItem as Currency).CurrencyName;
            vod.Price = Convert.ToDecimal(txtPrice.Text, System.Threading.Thread.CurrentThread.CurrentCulture);
            vod.Quantity = Convert.ToDecimal(txtQuantity.Text, System.Threading.Thread.CurrentThread.CurrentCulture);
            vod.VariantBarcode = (pckVariant.SelectedItem as ProductVariant)?.Barcode;
            vod.VariantId = (pckVariant.SelectedItem as ProductVariant)?.VariantId;
            vod.VatPercent = product.VatPercent;
            vod.WarehouseId = (pckWarehouse.SelectedItem as Warehouse).WarehouseId;
        }

        private void ClearControls()
        {
            popupOverlay.BindingContext = null;
            rbBarcode.IsChecked = true;
            txtPrice.Text = "0";
            txtQuantity.Text = "1";
            pckVariant.ItemsSource = null;
            sbSearch.Text = "";

        }

        private async void NewOrderLine_OnUpdated(NewOrderLine orderline, VwOrderDetails orderdetails)
        {
            popupOverlay.BindingContext = new VwProduct
            {
                Barcode = orderdetails.Barcode,
                HasVariant = orderdetails.VariantId != null,
                ProductCode = orderdetails.ProductCode,
                ProductId = orderdetails.ProductId,
                ProductName = orderdetails.ProductName,
                UnitId = orderdetails.UnitId,
                VatPercent = orderdetails.VatPercent,
                UnitName = orderdetails.UnitName

            };
            txtPrice.Text = orderdetails.Price?.ToString("F", System.Threading.Thread.CurrentThread.CurrentCulture);
            txtQuantity.Text = orderdetails.Quantity?.ToString("F", System.Threading.Thread.CurrentThread.CurrentCulture);
            pckCurrency.SelectedItem =
                (pckCurrency.ItemsSource as List<Currency>).FirstOrDefault(q =>
                    q.CurrencyId == orderdetails.CurrencyId);
            pckStokUnit.SelectedItem =
                (pckStokUnit.ItemsSource as List<Unit>).FirstOrDefault(q => q.UnitId == orderdetails.UnitId);
            pckWarehouse.SelectedItem =
                (pckWarehouse.ItemsSource as List<Warehouse>).FirstOrDefault(q =>
                    q.WarehouseId == orderdetails.WarehouseId);

            if (orderdetails.VariantId != null && orderdetails.VariantId > 0)
            {
                var variantList = await ApiHelper.GetVProductVariantList(orderdetails.ProductId);
                pckVariant.ItemsSource = variantList;
                pckVariant.SelectedItem =
                    variantList.FirstOrDefault(q => q.VariantId == orderdetails.VariantId);
            }

            _isUpdate = orderdetails;
            _updateOrderLine = orderline;
            popupOverlay.IsVisible = true;

        }
    }
}