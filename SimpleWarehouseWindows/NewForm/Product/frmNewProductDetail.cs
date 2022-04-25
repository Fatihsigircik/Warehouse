using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.NewForm.Product
{
    public partial class frmNewProductDetail : BaseForm
    {

        private readonly int _detailId;
        public event EventHandler Saved;
        private static frmNewProductDetail customerDetail;
        private Models.Product _currentProduct;

        public static frmNewProductDetail GetInstance(int customerDetailCode)
        {
            return customerDetail ?? (customerDetail = new frmNewProductDetail());
        }
        public static void RemoveInstance(frmNewProductDetail frm)
        {

            customerDetail = null;
            frm.Close();
            frm.Dispose();
        }


        public frmNewProductDetail(int detailId = 0)
        {
            _detailId = detailId;
            InitializeComponent();
            LoadComboBoxes();
            if (_detailId > 0)
                LoadDetail();
        }

        private async void LoadDetail()
        {
            OpenLoader();
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
            CloseLoader();
        }

        private async void LoadComboBoxes()
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            await Task.Run(async () =>
            {
                await LoadCurrency();
                await LoadStokUnit();
                await LoadWarehouse();
            });


            Control.CheckForIllegalCrossThreadCalls = true;
        }

        private async Task LoadWarehouse()

        {
            try
            {
                kcbWarehouse.DataSource = await ApiHelper.GetWarehouseList();
                kcbWarehouse.DisplayMember = "WarehouseName";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private async Task LoadStokUnit()
        {
            try
            {
                kcbStokUnit.DataSource = await ApiHelper.GetUnitList();
                kcbStokUnit.DisplayMember = "UnitName";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private async Task LoadCurrency()
        {
            try
            {
                kcbCurrency.DataSource = await ApiHelper.GetCurrencyList();
                kcbCurrency.DisplayMember = "CurrencyCode";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_currentProduct == null)
            {
                MessageBox.Show("Lütfen Ürün Seçimini Yapınız...", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (_currentProduct.HasVariant && klbVariants.CheckedItems.Count == 0)
            {
                MessageBox.Show("Lütfen Giriş İçin Varyant Seçin", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            OpenLoader();
            var productDetail = new ProductDetail()
            {
                ProductId = _currentProduct.ProductId,
                Price = Convert.ToDecimal(ktxtPrice.Text),
                CreatedDate = DateTime.Now,
                CreatedId = SettingsHelper.UserName.UserGroupId,
                CurrencyId = (kcbCurrency.SelectedItem as Currency).CurrencyId,
                CustomerId = -1,
                DocumentCode = ktxtDocumentNumber.Text,
                InOrOut = Convert.ToSByte(krbIn.Checked ? 1 : -1),
                IsApproved = true,
                Stock = Convert.ToDecimal(ktxtStok.Text),
                UnitId = (kcbStokUnit.SelectedItem as Unit).UnitId,
                VatPercent = Convert.ToByte(ktxtVat.Text),
                WarehouseId = (kcbWarehouse.SelectedItem as Warehouse).WarehouseId,
                VariantId = 0
            };

            if (_currentProduct.HasVariant)
            {
                foreach (var item in klbVariants.CheckedItems)
                {
                    var tmpProduct = (ProductDetail)productDetail.Clone();
                    tmpProduct.VariantId = (item as ProductVariant).VariantId;
                    await ApiHelper.AddProductDetail(tmpProduct);
                }
            }
            else
            {
                await ApiHelper.AddProductDetail(productDetail);
            }

            CloseLoader();
        }
    }
}
