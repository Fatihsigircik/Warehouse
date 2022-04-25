using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Helpers.Models;
using SimpleWarehouseWindows.Models;
using Utility;

namespace SimpleWarehouseWindows.NewForm.Order
{
    public partial class frmNewOrder : BaseForm
    {
        private delegate void RefAction<T1>(ref T1 arg1, string value = "");

        List<Currency> currencies = new List<Currency>();
        List<Unit> units = new List<Unit>();
        List<Warehouse> warehouses = new List<Warehouse>();
        Dictionary<string, List<ProductVariant>> variantDictionary = new Dictionary<string, List<ProductVariant>>();

        List<OrderDetailHelper> detail = new List<OrderDetailHelper>();

        private Dictionary<int, RefAction<OrderDetailHelper>> functionDictionary;

        private int _id;
        private static Dictionary<int, frmNewOrder> _newOrder = new Dictionary<int, frmNewOrder>();
        private List<Currency> _currencies;
        private bool _isLoading = true;

        private Models.Customer _currentCustomer;

        public static frmNewOrder GetInstance(int id = 0)
        {
            if (!_newOrder.ContainsKey(id))
                _newOrder.Add(id, new frmNewOrder(id));
            return _newOrder[id];
        }

        public static void RemoveInstance(frmNewOrder frm)
        {
            var finded = _newOrder.Values.FirstOrDefault(q => q == frm);
            if (finded == null)
                return;
            _newOrder.Remove(finded._id);
            finded.Close();
            finded.Dispose();
        }
        public frmNewOrder(int id)
        {
            _id = id;
            IsOnlyOne = true;
            InitializeComponent();
            kdgvProductDetail.AutoGenerateColumns = false;
            OpenLoader();
            LoadCurrency();
            LoadUnits();
            LoadWarehouse();
            LoadOrderStatus();
            LoadCountry();
            LoadFunctions();
            CloseLoader();
            _isLoading = false;
            if (id == 0)
            {
                Text = "Yeni Toptan Sipariş";
            }

        }

        private async Task LoadOrder()
        {
            var order = await ApiHelper.GetOrder(_id);
            _currentCustomer = await ApiHelper.GetCustomer(order.CustomerId);
            _currentCustomer.CompanyName = order.CompanyName;
            _currentCustomer.CustomerName = order.CustomerName;
            _currentCustomer.CustomerSurname = order.CustomerSurname;
            _currentCustomer.CustomerCode = order.CustomerCode;
            _currentCustomer.Mail = order.Mail;
            LoadCustomerInfo();
            this.Parent.Text = $@"{order.OrderCode}({order.DocNumber})";
            ktxtDocNumber.Text = order.DocNumber;
            kcbOrderStatus.SelectedItem =
                (kcbOrderStatus.DataSource as List<OrderStatus>)?.FirstOrDefault(q =>
                    q.OrderStatusId == order.OrderStatusId);
            ktxtPhone.Text = order.Phone;
            ktxtTaxNo.Text = order.TaxNumber;
            ktxtTaxOffice.Text = order.TaxOffice;

            ktxtDeliveryAddress.Text = order.DeliveryAddress;
            kcbDeliveryCountry.SelectedItem = (kcbDeliveryCountry.Items.Cast<Country>())?.FirstOrDefault(q => q.CountryId == order.DeliveryCountryId);
            kcbDeliveryCity.SelectedItem =
                (kcbDeliveryCity.DataSource as List<City>)?.FirstOrDefault(q => q.CityId == order.DeliveryCityId);

            kcbDeliveryTown.SelectedItem =
                (kcbDeliveryTown.DataSource as List<Town>)?.FirstOrDefault(q => q.TownId == order.DeliveryTownId);


            ktxtInvoiceAddress.Text = order.InvoiceAddress;
            kcbInvoiceCountry.SelectedItem = (kcbInvoiceCountry.Items.Cast<Country>())?.FirstOrDefault(q => q.CountryId == order.InvoiceCountryId);
            kcbInvoiceCity.SelectedItem =
                (kcbInvoiceCity.DataSource as List<City>)?.FirstOrDefault(q => q.CityId == order.InvoiceCityId);

            kcbInvoiceTown.SelectedItem =
                (kcbInvoiceTown.DataSource as List<Town>)?.FirstOrDefault(q => q.TownId == order.InvoiceTownId);

            ktxtOrderCode.Text = order.OrderCode;
            kdtpOrderDate.Value = order.OrderDate ?? DateTime.Now;

            //OrderDetails = GetDetails()
            foreach (var orderDetail in order.OrderDetails)
            {
                await SetOrderDetail(orderDetail);
            }
            LoadDataGrid();
            CalculateTotal();
        }

        private async Task SetOrderDetail(OrderDetail orderDetail)
        {
            var product = await ApiHelper.GetProductById(orderDetail.ProductId);
            detail.Add(new OrderDetailHelper(/*currencies,warehouses,units*/)
            {
                ProductId = orderDetail.ProductId,
                CurrencyId = orderDetail.CurrencyId,
                ProductName = orderDetail.ProductName,
                ProductCode = product.ProductCode,
                Price = orderDetail.Price,
                Currency = currencies.FirstOrDefault(q => q.CurrencyId == orderDetail.CurrencyId),
                UnitId = orderDetail.UnitId,
                Barcode = orderDetail.Barcode,
                VatPercent = orderDetail.VatPercent,
                CurrencyCode = currencies.FirstOrDefault(q => q.CurrencyId == orderDetail.CurrencyId)?.CurrencyCode,
                OrderId = orderDetail.OrderId,
                InOrOut = orderDetail.InOrOut,
                WarehouseId = orderDetail.WarehouseId,
                Quantity = orderDetail.Quantity,
                Unit = units.FirstOrDefault(q => q.UnitId == orderDetail.UnitId),
                UnitName = units.FirstOrDefault(q => q.UnitId == orderDetail.UnitId)?.UnitName,
                VariantId = orderDetail.VariantId,
                Warehouse = warehouses.FirstOrDefault(q => q.WarehouseId == orderDetail.WarehouseId),
                Variant = (await GetVariantList(new OrderDetailHelper(/*currencies, warehouses, units*/)
                { ProductCode = product.ProductCode, ProductId = product.ProductId }))
                    .FirstOrDefault(q => q.VariantId == orderDetail.VariantId),
                OrderDetailId = orderDetail.OrderDetailId,
                WarehouseName = warehouses.FirstOrDefault(q => q.WarehouseId == orderDetail.WarehouseId)?.WarehouseName
            });
        }

        private void LoadFunctions()
        {
            functionDictionary = new Dictionary<int, RefAction<OrderDetailHelper>>()
            {
                {0,SelectProduct}
            };
        }

        private async void LoadWarehouse()
        {
            warehouses = await ApiHelper.GetWarehouseList();
        }

        private async void LoadUnits()
        {
            units = await ApiHelper.GetUnitList();
        }

        private async void LoadCurrency()
        {
            currencies = await ApiHelper.GetCurrencyList();
        }

        private void LoadCountry()
        {
            var countryList = ApiHelper.GetCountryListSynchronous();
            kcbInvoiceCountry.DataSource = new BindingSource() { DataSource = countryList };
            kcbDeliveryCountry.DataSource = new BindingSource() { DataSource = countryList };
        }

        private async void LoadOrderStatus()
        {
            kcbOrderStatus.DataSource = await ApiHelper.GetOrderStatusList();
        }

        private void kcbInvoiceCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbInvoiceCountry.SelectedIndex != -1)
            {
                if (!_isLoading)
                    OpenLoader();
                var country = kcbInvoiceCountry.SelectedItem as Country;
                kcbInvoiceCity.DataSource = ApiHelper.GetCityListSynchronous(country.CountryId);
                if (!_isLoading)
                    CloseLoader();
            }
            _loadCity = false;
        }

        private void kcbInvoiceCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbInvoiceCity.SelectedIndex != -1)
            {

                if (!_isLoading)
                    OpenLoader();
                var city = kcbInvoiceCity.SelectedItem as City;
                kcbInvoiceTown.DataSource = ApiHelper.GetTownListSynchronous(city.CityId);
                if (!_isLoading)
                    CloseLoader();
            }
            _loadTown = false;
        }

        private void kcbDeliveryCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbDeliveryCity.SelectedIndex == -1)
                return;


            if (!_isLoading)
                OpenLoader();
            var city = kcbDeliveryCity.SelectedItem as City;
            kcbDeliveryTown.DataSource = ApiHelper.GetTownListSynchronous(city.CityId);
            if (!_isLoading)
                CloseLoader();
        }

        private void kcbDeliveryCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcbDeliveryCountry.SelectedIndex == -1)
                return;


            if (!_isLoading)
                OpenLoader();
            var country = kcbDeliveryCountry.SelectedItem as Country;
            kcbDeliveryCity.DataSource = ApiHelper.GetCityListSynchronous(country.CountryId);
            if (!_isLoading)
                CloseLoader();
        }

        private async void bsaGenerateOrderCode_Click(object sender, EventArgs e)
        {
            try
            {
                var currentCode = await ApiHelper.GetCurrentCustomerCode(ktxtOrderCode.Text);
                if (string.IsNullOrEmpty(currentCode))
                {
                    throw new Exception($"{ktxtOrderCode.Text} Prefixi İle Başlayan Kayıt Bulunamadı...");
                }
                ktxtOrderCode.Text = currentCode;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void bsaSelectCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ktxtCustomerCode.Text))
                return;
            try
            {
                _currentCustomer = await ApiHelper.GetCustomerByCode(ktxtCustomerCode.Text);
                if (_currentCustomer == null)
                {
                    MessageBox.Show($"'{ktxtCustomerCode.Text}' Kodlu Cari Bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadCustomerInfo();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _loadCity = false;
        private bool _loadTown = false;
        private void LoadCustomerInfo()
        {
            ktxtCustomerCode.Text = _currentCustomer.CustomerCode;
            ktxtCompanyName.Text = _currentCustomer.CompanyName;
            ktxtCustomerName.Text = _currentCustomer.CustomerName;
            ktxtCustomerSurname.Text = _currentCustomer.CustomerSurname;
            ktxtPhone.Text = _currentCustomer.Phone;
            ktxtTaxNo.Text = _currentCustomer.TaxNumber;
            ktxtTaxOffice.Text = _currentCustomer.TaxOffice;

            kcbInvoiceCountry.SelectedItem =
                ((kcbInvoiceCountry.DataSource as BindingSource).DataSource as List<Country>).FirstOrDefault(q =>
                    q.CountryId == _currentCustomer.CountryId);


            kcbInvoiceCity.SelectedItem = (kcbInvoiceCity.DataSource as List<City>).FirstOrDefault(q =>
                q.CityId == _currentCustomer.CityId);

            kcbInvoiceTown.SelectedItem = (kcbInvoiceTown.DataSource as List<Town>).FirstOrDefault(q =>
                q.TownId == _currentCustomer.TownId);

            ktxtInvoiceAddress.Text = _currentCustomer.Address;

            kgbOrderDateils.Enabled = kbtnAddLine.Enabled = kbtnDelete.Enabled = true;
        }

        private void kbtnSelectCustomer_Click(object sender, EventArgs e)
        {
            var frm = new frmCustomerList(ktxtCustomerCode.Text);
            if (frm.ShowDialog() != DialogResult.OK || frm.SelectedCustomer == null)
                return;
            _currentCustomer = frm.SelectedCustomer;
            LoadCustomerInfo();
        }

        private void kbtnCopyAddress_Click(object sender, EventArgs e)
        {
            kcbDeliveryCountry.SelectedIndex = kcbInvoiceCountry.SelectedIndex;
            kcbDeliveryCity.SelectedIndex = kcbInvoiceCity.SelectedIndex;
            kcbDeliveryTown.SelectedIndex = kcbInvoiceTown.SelectedIndex;
            ktxtDeliveryAddress.Text = ktxtInvoiceAddress.Text;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                if ((this.ActiveControl == kdgvProductDetail) || (kdgvProductDetail.CurrentCell != null && kdgvProductDetail.CurrentCell.IsInEditMode))
                {
                    if (kdgvProductDetail.CurrentRow == null)
                        return base.ProcessCmdKey(ref msg, keyData);

                    var p = kdgvProductDetail.CurrentRow.IsNewRow
                        ? GetNewOrderDetail()
                        : kdgvProductDetail.CurrentRow.DataBoundItem as OrderDetailHelper;
                    LoadDataGrid();
                    functionDictionary[0].Invoke(ref p);

                    kdgvProductDetail.Refresh();
                    CalculateTotal();
                }
            }
            else if (keyData == Keys.Delete)
            {
                if ((this.ActiveControl == kdgvProductDetail) || (kdgvProductDetail.CurrentCell != null && !kdgvProductDetail.CurrentCell.IsInEditMode))
                {
                    if (kdgvProductDetail.CurrentRow == null)
                        return base.ProcessCmdKey(ref msg, keyData);
                    if (MessageBox.Show("Silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) !=
                        DialogResult.Yes)
                        return base.ProcessCmdKey(ref msg, keyData);
                    var currentRow = kdgvProductDetail.CurrentRow.DataBoundItem as OrderDetailHelper;
                    kdgvProductDetail.Rows.Remove(kdgvProductDetail.CurrentRow);
                    detail.Remove(currentRow);

                    kdgvProductDetail.Refresh();
                    CalculateTotal();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LoadDataGrid()
        {
            kdgvProductDetail.DataSource = new BindingSource() { DataSource = detail };
        }

        private OrderDetailHelper GetNewOrderDetail()
        {

            var newOrderDetail = new OrderDetailHelper(/*currencies, warehouses, units*/);
            detail.Add(newOrderDetail);
            return newOrderDetail;
        }


        void SelectProduct(ref OrderDetailHelper p, string value = "")
        {
            frmProductList frm = new frmProductList(value);
            if (frm.ShowDialog() == DialogResult.OK)
            {

                var product = frm.SelectedProduct;
                var price = ApiHelper.GetPriceByProductIdAndPriceListGroupId(product.ProductId,
                    _currentCustomer.WholesaleGroupId ?? -1).FirstOrDefault();

                OpenLoader();
                p.ProductId = product.ProductId;
                p.ProductName = product.ProductName;
                p.Price = price?.Price;
                p.Quantity = 1;
                p.Barcode = product.Barcode;
                p.UnitId = product.UnitId;
                p.Unit = units.FirstOrDefault(q => q.UnitId == product.UnitId);
                p.VatPercent = product.VatPercent;
                p.InOrOut = -1;
                p.ProductCode = product.ProductCode;
                p.Warehouse = warehouses.FirstOrDefault();
                p.CurrencyId = price?.CurrencyId;
                p.Currency = currencies.FirstOrDefault(q => q.CurrencyId == price?.CurrencyId) ?? currencies.FirstOrDefault(q => q.CurrencyCode.TrimEnd() == "TL");
                CloseLoader();
                LoadDataGrid();
                if (product.HasVariant)
                {
                    OpenLoader();
                    List<ProductVariant> variantList = null;

                    variantList = GetVariantList(p).Result;

                    while (variantList == null)
                    {
                        System.Threading.Thread.Sleep(100);
                    }



                    CloseLoader();
                    var frmVariant = new frmSelectVariant(variantList ?? new List<ProductVariant>());
                    frmVariant.ShowDialog();
                    p.Variant = frmVariant.SelectedVariant;

                }
                CalculateTotal();
            }
            else
            {
                detail.Remove(p);
            }
        }

        private void kdgvProductDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == -1 || kdgvProductDetail.CurrentRow.IsNewRow)
                return;
            if (e.ColumnIndex == 6)
            {
                var item = kdgvProductDetail.Rows[e.RowIndex].DataBoundItem as OrderDetailHelper;
                //var cell = kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var comboCell = new DataGridViewComboBoxCell { DataSource = currencies, Value = item.Currency, DisplayMember = "CurrencyCode" };
                comboCell.ValueType = typeof(Currency);
                kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex] = comboCell;
            }
            else if (e.ColumnIndex == 8)
            {
                var item = kdgvProductDetail.Rows[e.RowIndex].DataBoundItem as OrderDetailHelper;
                //var cell = kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex];
                var comboCell = new DataGridViewComboBoxCell { DataSource = warehouses, Value = item.Warehouse, DisplayMember = "WarehouseName" };
                comboCell.ValueType = typeof(Warehouse);
                kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex] = comboCell;
            }
        }

        private async void kdgvProductDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex == 6 && kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell c)
            {

                var teBoxCell = new DataGridViewTextBoxCell();

                (kdgvProductDetail.Rows[e.RowIndex].DataBoundItem as OrderDetailHelper).Currency = c.Value as Currency;
                kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex] = teBoxCell;
                CalculateTotal();
            }
            else if (e.ColumnIndex == 8 && kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell cb)
            {
                var teBoxCell = new DataGridViewTextBoxCell();

                (kdgvProductDetail.Rows[e.RowIndex].DataBoundItem as OrderDetailHelper).Warehouse = cb.Value as Warehouse;
                kdgvProductDetail.Rows[e.RowIndex].Cells[e.ColumnIndex] = teBoxCell;
            }
            else if (e.ColumnIndex == 1 || e.ColumnIndex == 0)
            {
                var rp = kdgvProductDetail.CurrentRow.IsNewRow
                        ? GetNewOrderDetail()
                        : (kdgvProductDetail.CurrentRow.DataBoundItem ?? GetNewOrderDetail()) as OrderDetailHelper;
                Models.Product p = null;
                try
                {
                    var value = (kdgvProductDetail.CurrentCell.Value ?? "").ToString();
                    p = e.ColumnIndex == 1 ? await ApiHelper.GetProductByCode(value) : await ApiHelper.GetProductByBarcode(value);
                }
                catch
                {
                    // ignored
                }

                if (p == null)
                {
                    if (kdgvProductDetail.CurrentRow == null)
                        return;


                    LoadDataGrid();
                    functionDictionary[0].Invoke(ref rp, (sender as TextBox)?.Text);


                }
                else
                {
                    var price = ApiHelper.GetPriceByProductIdAndPriceListGroupId(p.ProductId,
                        _currentCustomer.WholesaleGroupId ?? -1).FirstOrDefault();

                    OpenLoader();
                    rp.ProductId = p.ProductId;
                    rp.ProductName = p.ProductName;
                    rp.Price = price?.Price;
                    rp.Barcode = p.Barcode;
                    rp.UnitId = p.UnitId;
                    rp.Unit = units.FirstOrDefault(q => q.UnitId == p.UnitId);
                    rp.VatPercent = p.VatPercent;
                    rp.InOrOut = -1;
                    rp.ProductCode = p.ProductCode;
                    rp.Warehouse = warehouses.FirstOrDefault();
                    rp.CurrencyId = price?.CurrencyId;
                    rp.Currency = currencies.FirstOrDefault(q => q.CurrencyId == price?.CurrencyId) ?? currencies.FirstOrDefault(q => q.CurrencyCode.TrimEnd() == "TL");
                    CloseLoader();
                    LoadDataGrid();
                    if (p.HasVariant)
                    {
                        OpenLoader();
                        var variantList = await GetVariantList(rp);
                        CloseLoader();
                        var frmVariant = new frmSelectVariant(variantList ?? new List<ProductVariant>());
                        frmVariant.ShowDialog();
                        rp.Variant = frmVariant.SelectedVariant;

                    }
                }
                kdgvProductDetail.Refresh();
                CalculateTotal();
            }
            else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                CalculateTotal();
            }

        }

        private void CalculateTotal()
        {
            var totals = new Dictionary<string, decimal>();
            detail.ForEach(q =>
            {
                if (!totals.ContainsKey(q.Currency.CurrencyCode))
                    totals.Add(q.Currency.CurrencyCode, 0);
                totals[q.Currency.CurrencyCode] += (q.Quantity * q.Price) ?? 0;
            });

            klblTotal.Text = string.Join(" + ", totals.Select(q => $"{q.Value:F} {q.Key}"));
        }

        private async Task<List<ProductVariant>> GetVariantList(OrderDetailHelper orderDetailHelper)
        {
            List<ProductVariant> variantList = null;
            if (!variantDictionary.ContainsKey(orderDetailHelper.ProductCode))
            {
                variantList = await ApiHelper.GetProductVariants(orderDetailHelper.ProductId);
                variantDictionary.Add(orderDetailHelper.ProductCode, variantList);
            }
            else
            {
                variantList = variantDictionary[orderDetailHelper.ProductCode];
            }

            return variantList;
        }

        private void kdgvProductDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            e.FormattingApplied = false;
        }

        private void kdgvProductDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //e.Cancel = true;
        }

        private void kdgvProductDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (kdgvProductDetail.CurrentRow.IsNewRow)
                return;

            var columnIndex = kdgvProductDetail.CurrentCell.ColumnIndex;
            if (columnIndex == 6)
            {
                (e.Control as ComboBox).SelectedIndexChanged += FrmNewOrder_SelectedIndexChanged;
            }
            else if (columnIndex == 8)
            {
                (e.Control as ComboBox).SelectedIndexChanged += FrmNewOrderWarehouse_SelectedIndexChanged; ;
            }
            else if (columnIndex == 5)
            {
                (e.Control as TextBox).KeyPress += FrmNewOrder_KeyPress;
            }

        }

        private void FrmNewOrderWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            detail[kdgvProductDetail.CurrentRow.Index].Warehouse = (sender as ComboBox).SelectedItem as Warehouse;
            (kdgvProductDetail.CurrentRow.DataBoundItem as OrderDetailHelper).Warehouse = (sender as ComboBox).SelectedItem as Warehouse;
            //(sender as ComboBox).SelectedIndexChanged -= FrmNewOrderWarehouse_SelectedIndexChanged;
        }

        private void FrmNewOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Utility.General.NumericChars.Contains(e.KeyChar))
                e.Handled = true;
        }

        private void FrmNewOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedItem == null)
                return;

            detail[kdgvProductDetail.CurrentRow.Index].Currency = (sender as ComboBox).SelectedItem as Currency;
            (kdgvProductDetail.CurrentRow.DataBoundItem as OrderDetailHelper).Currency = (sender as ComboBox).SelectedItem as Currency;
            //(sender as ComboBox).SelectedIndexChanged -= FrmNewOrder_SelectedIndexChanged;
        }

        private async void kdgvProductDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 6 || e.ColumnIndex == 8)
            {
                kdgvProductDetail.BeginEdit(false);
                if (kdgvProductDetail.EditingControl is ComboBox cb)
                    cb.DroppedDown = true;
            }

            if (!kdgvProductDetail.CurrentRow.IsNewRow && e.RowIndex != -1 && e.ColumnIndex == 9)
            {
                var item = kdgvProductDetail.CurrentRow.DataBoundItem as OrderDetailHelper;
                var variants = await GetVariantList(item);
                var frmSelectVariant = new frmSelectVariant(variants);
                if (frmSelectVariant.ShowDialog() == DialogResult.OK)
                {
                    item.Variant = frmSelectVariant.SelectedVariant;
                    kdgvProductDetail.Refresh();
                }
            }
        }

        private async void kbtnSave_Click(object sender, EventArgs e)
        {
            await SaveOrder();
        }

        private async Task SaveOrder()
        {
            var msg = "";
            if (!ValidateOrder(ref msg))
            {
                MessageBox.Show($"Bir Sorun Oluştu..{Environment.NewLine}{msg}");
                return;
            }
            try
            {
                var order = GetOrder();
                if (_id == 0)
                {
                    var tmp = (await ApiHelper.AddOrder(order));
                    _id = tmp.OrderId;
                    _newOrder.Remove(0);
                    _newOrder[_id] = this;
                    Text = $@"{tmp.OrderCode}({tmp.DocNumber})";
                    this.Parent.Text = Text;
                }
                else
                {
                    order.OrderId = _id;
                    await ApiHelper.UpdateOrder(order);
                }
                kbtnPrint.Enabled = true;
                MessageBox.Show("Sipariş Kaydedildi...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Hata Oluştu...{Environment.NewLine}{e.Message}", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private bool ValidateOrder(ref string msg)
        {
            var msgList = new List<string>();
            var retVal = true;
            if (ktxtOrderCode.Text.Length == 0)
            {
                msgList.Add("Lütfen Sipariş Kodunu Giriniz.");
                retVal = false;
            }
            if (ktxtDocNumber.Text.Length == 0)
            {
                msgList.Add("Lütfen Belge Numarası Giriniz.");
                retVal = false;
            }
            if (_currentCustomer == null)
            {
                msgList.Add("Lütfen Cari Seçiniz.");
                retVal = false;
            }

            if (ktxtDeliveryAddress.Text.Length == 0)
            {
                msgList.Add("Lütfen Teslimat Adresini Giriniz.");
                retVal = false;
            }

            if (detail.Count == 0)
            {
                msgList.Add("Lütfen Ürün Ekleyin.");
                retVal = false;
            }

            msg = string.Join(Environment.NewLine, msgList);
            return retVal;
        }


        private Helpers.Models.FullOrder GetOrder()
        {
            var fullOrder = new FullOrder()
            {
                CurrencyId = detail[0].Currency.CurrencyId,
                CreatedDate = DateTime.Now,
                CreatedId = SettingsHelper.UserName.UserGroupId,
                IsDeleted = false,
                CustomerId = _currentCustomer.CustomerId,
                CompanyName = _currentCustomer.CompanyName,
                CustomerName = _currentCustomer.CustomerName,
                CustomerSurname = _currentCustomer.CustomerSurname,
                DocNumber = ktxtDocNumber.Text,
                OrderStatusId = kcbOrderStatus.SelectedItem.Cast<OrderStatus>()?.OrderStatusId,
                Phone = ktxtPhone.Text,
                CustomerCode = _currentCustomer.CustomerCode,
                TaxNumber = ktxtTaxNo.Text,
                TaxOffice = ktxtTaxOffice.Text,
                Mail = _currentCustomer.Mail,
                DeliveryAddress = ktxtDeliveryAddress.Text,
                DeliveryAddress2 = "",
                DeliveryCityId = kcbDeliveryCity.SelectedItem.Cast<City>()?.CityId,
                DeliveryCountryId = kcbDeliveryCountry.SelectedItem.Cast<Country>().CountryId,
                DeliveryRegionId = null,
                DeliveryTownId = kcbDeliveryTown.SelectedItem.Cast<Town>().TownId,
                InvoiceAddress = ktxtInvoiceAddress.Text,
                InvoiceAddress2 = "",
                InvoiceCityId = kcbInvoiceCity.SelectedItem.Cast<City>().CityId,
                InvoiceCountryId = kcbInvoiceCountry.SelectedItem.Cast<Country>().CountryId,
                InvoiceRegionId = null,
                InvoiceTownId = kcbInvoiceTown.SelectedItem.Cast<Town>().TownId,
                OrderCode = ktxtOrderCode.Text,
                OrderDate = kdtpOrderDate.Value,
                OrderTypeId = 2,
                TotalPrice = detail.Sum(q => q.Price * q.Quantity),
                TotalVal = detail.Sum(q => (q.Price - (q.Price / (1M + ((decimal)q.VatPercent / 100M)))) * q.Quantity),
                OrderDetails = GetDetails()
            };
            return fullOrder;
        }

        private List<OrderDetail> GetDetails()
        {
            detail.ForEach(q =>
            {
                q.CurrencyId = q.Currency.CurrencyId;
                q.CurrencyCode = q.Currency.CurrencyCode;
                q.OrderId = _id;

                q.WarehouseId = q.Warehouse?.WarehouseId;
                q.VariantId = q.Variant?.VariantId;
            });
            return detail.Select(q => q as OrderDetail).ToList();
        }

        private async void frmNewOrder_Load(object sender, EventArgs e)
        {
            if (_id > 0)
            {
                OpenLoader();
                await LoadOrder();
                CloseLoader();
                kbtnPrint.Enabled = true;
            }
        }

        private void kbtnAddLine_Click(object sender, EventArgs e)
        {
            var p = GetNewOrderDetail();
            LoadDataGrid();
            functionDictionary[0].Invoke(ref p);
            kdgvProductDetail.Refresh();
            CalculateTotal();
        }

        private void kbtnDelete_Click(object sender, EventArgs e)
        {
            if ((this.ActiveControl == kdgvProductDetail) || (kdgvProductDetail.CurrentCell != null && !kdgvProductDetail.CurrentCell.IsInEditMode))
            {
                if (kdgvProductDetail.CurrentRow == null)
                    return;
                if (MessageBox.Show("Silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) !=
                    DialogResult.Yes)
                    return;
                var currentRow = kdgvProductDetail.CurrentRow.DataBoundItem as OrderDetailHelper;
                kdgvProductDetail.Rows.Remove(kdgvProductDetail.CurrentRow);
                detail.Remove(currentRow);

                kdgvProductDetail.Refresh();
                CalculateTotal();
            }
        }

        int counter = 0; // end-to-end row number in an array of strings that are output
        int curPage; // current page

        private void kbtnPrint_Click(object sender, EventArgs e)
        {
            var printDialog1 = new PrintDialog();
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printDialog1.PrinterSettings;
                    pd.BeginPrint += Pd_BeginPrint;
                    pd.PrintPage += Pd_PrintPage;
                    pd.Print();
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Yazdırırken Hata Oluştu.{Environment.NewLine}{exception.Message}");
                }

                
            }
        }




        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {




            var richTextBox1 = new RichTextBox();
            richTextBox1.Text = $" deneme {Environment.NewLine} deneme{Environment.NewLine} fatih";

            Font myFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);

            OrderDetailHelper curLine; // current output string

            // Padding inside page
            float leftMargin = e.MarginBounds.Left-20; // padding on the left in the document
            float topMargin = e.MarginBounds.Top; // padding on top of the document
            float yPos = 0; // current position Y to the output line

            int nPages; // number of pages
            int nLines; // the maximum possible number of lines per page
            int i; // current line number to display on page

            // Calculate the maximum number of lines per page
            nLines = (int)(e.MarginBounds.Height / myFont.GetHeight(e.Graphics));

            // Calculate the number of pages to print.
            nPages = (richTextBox1.Lines.Length - 1) / nLines + 1;
            i = 0;
            if (curPage == 1)
            {
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawString($"Sipariş Kodu   : {ktxtOrderCode.Text}", myFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());

                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawString($"Müşteri Kodu   : {ktxtCustomerCode.Text}", myFont, Brushes.Black,
                    leftMargin+400, yPos, new StringFormat());

                i++;
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawString($"Belge Numarası : {ktxtDocNumber.Text}", myFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                e.Graphics.DrawString($"Firma Adı      : {ktxtCompanyName.Text}", myFont, Brushes.Black,
                    leftMargin + 400, yPos, new StringFormat());
                i++;
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawString($"Sipariş Terihi : {kdtpOrderDate.Value.ToString("dd.MM.yyyy")}", myFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                i+=3;
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawString($"Ürün Kodu", myFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                e.Graphics.DrawString($"Barkod", myFont, Brushes.Black,
                    leftMargin+100, yPos, new StringFormat());
                e.Graphics.DrawString($"Ürün Adı", myFont, Brushes.Black,
                    leftMargin + 220, yPos, new StringFormat());
                e.Graphics.DrawString($"Varyant", myFont, Brushes.Black,
                    leftMargin + 420, yPos, new StringFormat());
                e.Graphics.DrawString($"Adet", myFont, Brushes.Black,
                    leftMargin + 640, yPos, new StringFormat());
                i++;
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawLine(Pens.Black,leftMargin,yPos, leftMargin+700, yPos);
                i++;
            }

            // Printing cycle of one page

            while ((i < nLines) && (counter < detail.Count))
            {
                // Get line for output from richTextBox1
                curLine = detail[counter];

                // Calculate the current position on the Y axis
                yPos = topMargin + i * myFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(curLine.ProductCode, myFont, Brushes.Black,
                    leftMargin, yPos, new StringFormat());
                e.Graphics.DrawString(curLine.Barcode, myFont, Brushes.Black,
                    leftMargin + 100, yPos, new StringFormat());
                e.Graphics.DrawString(curLine.ProductName, myFont, Brushes.Black,
                    leftMargin + 220, yPos, new StringFormat());
                e.Graphics.DrawString(curLine.VariantName??"-", myFont, Brushes.Black,
                    leftMargin + 420, yPos, new StringFormat());
                e.Graphics.DrawString($"{Convert.ToInt32(curLine.Quantity)} {curLine.UnitName}", myFont, Brushes.Black,
                    leftMargin + 640, yPos, new StringFormat());
               

                counter++;
                i++;
            }

            // If all the text does not fit on 1 page,
            // then you need to add an additional page for printing
            e.HasMorePages = false;

            if (curPage < nPages)
            {
                curPage++;
                e.HasMorePages = true;
            }
        }

        private void Pd_BeginPrint(object sender, PrintEventArgs e)
        {
            counter = 0;
            curPage = 1;
        }


    }
}
