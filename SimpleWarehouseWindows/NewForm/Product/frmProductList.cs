using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.MenuForms.Product;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.NewForm.Product
{
    public partial class frmProductList : BaseForm
    {
        private static frmProductList productList;
        List<VwProduct> _list = new List<VwProduct>();


        public static frmProductList GetInstance()
        {
            return productList ?? (productList = new frmProductList());
        }

        public static void RemoveInstance(frmProductList frm)
        {

            productList = null;
            frm.Close();
            frm.Dispose();
        }

        public frmProductList()
        {
            IsOnlyOne = true;
            InitializeComponent();
            kdgvList.AutoGenerateColumns = false;
        }

        private async void frmProductList_Load(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            kdgvList.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetProductList();
            //dgvStatus.DataSource = list;
            kdgvList.DataSource = new BindingSource() {DataSource = _list};
            CloseLoader();
        }

        private async Task FilterData()
        {
            await Task.Run(() =>
            {
                kdgvList.Invoke(new Action(() =>
                {
                    CurrencyManager currencyManager1 = (CurrencyManager) BindingContext[kdgvList.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvList.Rows)
                    {
                        var product = row.DataBoundItem as VwProduct;

                        row.Visible = (ktxtProductCode.Text == "" ||
                                       product.ProductCode.ToLower().StartsWith(ktxtProductCode.Text.ToLower())) &&
                                      (ktxtProductName.Text == "" || product.ProductName.ToLower()
                                           .StartsWith(ktxtProductName.Text.ToLower())) &&
                                      (ktxtBarcode.Text == "" ||
                                       product.Barcode.ToLower().StartsWith(ktxtBarcode.Text.ToLower()));
                    }

                    currencyManager1.ResumeBinding();
                }));
            });

        }

        private async void txtFilter_TextChanged(object sender, EventArgs e)
        {
            await FilterData();
        }

        private void kbtnClearFilter_Click(object sender, EventArgs e)
        {
            var txts = kgbFilter.Panel.Controls.Cast<Control>().Where(q => q.GetType() == typeof(KryptonTextBox));
            foreach (Control txt in txts)
            {
                txt.Text = String.Empty;

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
                LoadProducts();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void kdgvList_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvList.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvList.Rows[test.RowIndex].Selected = true;
        }

        private void tsmiNewProduct_Click(object sender, EventArgs e)
        {
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewProduct>(0);
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void UpdateProduct()
        {
            var product = kdgvList.SelectedRows[0].DataBoundItem as VwProduct;
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewProduct>(product.ProductId);
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kaydı Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var product = kdgvList.SelectedRows[0].DataBoundItem as VwProduct;
                await ApiHelper.DeleteProduct(product.ProductId);
                await LoadProducts();
            }
        }

        private void kdgvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UpdateProduct();
        }

        private void tsmiProductImage_Click(object sender, EventArgs e)
        {
            var product = kdgvList.SelectedRows[0].DataBoundItem as VwProduct;
            if(product==null)
                return;
            new ProductImages(product).ShowDialog();
        }
    }
}
