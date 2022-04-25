using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.NewForm.Product;

namespace SimpleWarehouseWindows.UserControls
{
    public partial class AddProductDetailControl : UserControl
    {
        
        public event EventHandler Saved;
        private static frmNewProductDetail customerDetail;
        private Models.Product _currentProduct;
        
        public short InOrOut { get; set; } = 1;
        public AddProductDetailControl()
        {
           
            InitializeComponent();
            LoadComboBoxes();
            //if (_detailId > 0)
            //    LoadDetail();
        }



        private async void LoadDetail()
        {
            //OpenLoader();
            //var detail = await ApiHelper.GetCustomerDetail(_detailId);
            //if (detail == null)
            //{
            //    MessageBox.Show($"{_detailId} Id Numaralı Kayıt Bulunamadı...", "Uyarı", MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning);
            //    return;
            //}

            //var customer = await ApiHelper.GetCustomer(detail.CustomerId);
            //LoadCustomerInfo(customer);
            //LoadDetailInfo(detail);
            //CloseLoader();
        }

        private async void LoadComboBoxes()
        {
            
            Control.CheckForIllegalCrossThreadCalls = false;
            await Task.Run(async () =>
            {
                await LoadCurrency();
                await LoadStockUnit();
                await LoadWarehouse();
               
            });


            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private async Task LoadWarehouse()
        {
            kcbWarehouse.DataSource = await ApiHelper.GetWarehouseList();
            kcbWarehouse.DisplayMember = "WarehouseName";
        }

        private async Task LoadStockUnit()
        {
            kcbStokUnit.DataSource = await ApiHelper.GetUnitList();
            kcbStokUnit.DisplayMember = "UnitName";
        }

        private async Task LoadCurrency()
        {
            kcbCurrency.DataSource = await ApiHelper.GetCurrencyList();
            kcbCurrency.DisplayMember = "CurrencyCode";
        }

        private void kbtnSelectProduct_Click(object sender, EventArgs e)
        {
            OpenSelectProductForm();
            var frm = new FormHelper.frmProductList(ktxtProductCode.Text);
        }
        private void OpenSelectProductForm()
        {
            var frm = new FormHelper.frmProductList(ktxtProductCode.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadProductInfo(frm.SelectedProduct);
            }
        }
        private async void LoadProductInfo(Models.Product product)
        {
            _currentProduct = product;
            ktxtProductCode.Text = _currentProduct.ProductCode;
            ktxtProductName.Text = _currentProduct.ProductName;
            ktxtBarcode.Text = _currentProduct.Barcode;
            ktxtVat.Text = _currentProduct.VatPercent.ToString();
            if (_currentProduct.HasVariant)
            {
                await LoadVariants();
            }
        }
        private async Task LoadVariants()
        {
            var variants = await ApiHelper.GetProductVariants(_currentProduct.ProductId);
            klbVariants.Items.AddRange(variants.ToArray());
        }

        private string[] _numericChars = ("1|2|3|4|5|6|7|8|9|0|-|\b|" + CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator).Split('|');
        private void ktxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_numericChars.Contains((e.KeyChar).ToString()))
                e.Handled = true;
        }
    }
}
