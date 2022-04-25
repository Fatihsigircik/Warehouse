using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Android.Renderscripts;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.Forms.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectInOrOutProduct : ContentPage
    {
        public event EventHandler Closed;
        public VwProductDetails SelectedProductDetail;
        public bool DialogResult { get; set; } = false;

        private readonly string _docno;
        private readonly Warehouse _warehouse;
        private readonly short _inorout;
        private ProductVariant currentProductVariant;
        private string searchType = "barcode";
        private readonly Dictionary<string, Func<Task<VwProduct>>> SearchMethods;

        private List<Currency> _currencies;
        private List<Unit> _units;

        private VwProduct _currentProduct;


        public SelectInOrOutProduct(string docno, Warehouse warehouse, short inorout, VwProductDetails updateProduct=null)
        {
            _docno = docno;
            _warehouse = warehouse;
            _inorout = inorout;
            SelectedProductDetail = updateProduct;
            SearchMethods = new Dictionary<string, Func<Task<VwProduct>>>
            {
                { "barcode", SearchByBarcode },
                { "productCode", SearchByCode },
                { "productName", SearchByName }
            };
            InitializeComponent();
            LoadCurrency();
            LoadUnit();
            if (SelectedProductDetail != null)
            {
                SetCurrentProduct(SelectedProductDetail.ProductCode);
            }
        }

        private async void SetCurrentProduct(string productCode)
        {
            var pr= await ApiHelper.GetProductViewByCode(productCode);
            if(pr==null)
                throw new Exception($"Ürün Bulunamadı...");
            _currentProduct = pr;

            BindingContext = pr;
            if (pr.HasVariant)
            {
                var variantList = await ApiHelper.GetVProductVariantList(pr.ProductId);
                pckVariant.ItemsSource = variantList;
                pckVariant.SelectedItem =
                    variantList.FirstOrDefault(q => q.VariantId == currentProductVariant?.VariantId) ?? variantList[0];
            }

            if (SelectedProductDetail.Price != null) txtPrice.Text = SelectedProductDetail.Price.Value.ToString("F");
            if (SelectedProductDetail.Stock != null) txtQuantity.Text = SelectedProductDetail.Stock.Value.ToString("F");

            pckStokUnit.SelectedItem = _units.FirstOrDefault(q => q.UnitId == SelectedProductDetail.UnitId);
            pckCurrency.SelectedItem = _currencies.FirstOrDefault(q => q.CurrencyId == SelectedProductDetail.CurrencyId);
            if (SelectedProductDetail.VariantId > 0)
                pckVariant.SelectedItem =
                    (pckVariant.ItemsSource as List<ProductVariant>).FirstOrDefault(q =>
                        q.VariantId == SelectedProductDetail.VariantId);
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

        

        private async void SbSearch_OnSearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                
                currentProductVariant = null;
                pckVariant.ItemsSource = null;
                var detail = await SearchMethods[searchType].Invoke();
                if (detail == null)
                    throw new Exception($"Ürün Bulunamadı...");
                _currentProduct = detail;
                this.BindingContext = detail;
                pckStokUnit.SelectedItem = _units.FirstOrDefault(q => q.UnitId == detail.UnitId);
                pckCurrency.SelectedIndex = 0;
                if (detail.HasVariant)
                {
                    var variantList = await ApiHelper.GetVProductVariantList(detail.ProductId);
                    pckVariant.ItemsSource = variantList;
                    pckVariant.SelectedItem =
                        variantList.FirstOrDefault(q => q.VariantId == currentProductVariant?.VariantId)??variantList[0];
                }

                sbSearch.Unfocus();
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.Alert($"İşlem Sırasında Hata Alındı...{Environment.NewLine}{exception.Message}",
                    "Hata", "Tamam");

            }
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

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            DialogResult = true;
            Navigation.PopModalAsync(true);
            Closed?.Invoke(this,EventArgs.Empty);
        }

        private void ImgbtnAddDetail_OnClicked(object sender, EventArgs e)
        {
            DialogResult = true;
            SelectedProductDetail = new VwProductDetails()
            {
                ProductId = _currentProduct.ProductId,
                Barcode = _currentProduct.Barcode,
                CompanyName = "",
                CreatedDate = DateTime.Now,
                CreatedId = SettingsHelper.UserName.UserId,
                CurrencyCode = (pckCurrency.SelectedItem as Currency).CurrencyCode,
                CurrencyId = (pckCurrency.SelectedItem as Currency).CurrencyId,
                CurrencyName = (pckCurrency.SelectedItem as Currency).CurrencyName,
                CustomerCode = "",
                CustomerId = -1,
                CustomerName = "",
                CustomerSurname = "",
                DocumentCode = _docno,
                InOrOut = _inorout,
                IsApproved = true,
                Price = Convert.ToDecimal(txtPrice.Text),
                ProductCode = _currentProduct.ProductCode,
                ProductName = _currentProduct.ProductName,
                Stock = Convert.ToDecimal(txtQuantity.Text),
                UnitId = (pckStokUnit.SelectedItem as Unit).UnitId,
                UnitName = (pckStokUnit.SelectedItem as Unit).UnitName,
                VariantId = (pckVariant.SelectedIndex == -1 ? 0 : (pckVariant.SelectedItem as ProductVariant).VariantId),
                VatPercent = _currentProduct.VatPercent,
                WarehouseId = _warehouse.WarehouseId,
                WarehouseName = _warehouse.WarehouseName
            };
            Navigation.PopModalAsync(true);
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}