using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.FormHelper
{
    public partial class frmProductList : Form
    {
        private readonly string _code;
        public VwProduct SelectedProduct { get; private set; }
        public frmProductList(string code = "")
        {
            _code = code;
            InitializeComponent();
            kdgvProduct.AutoGenerateColumns = false;
        }

        private async void frmProductList_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
            if (!string.IsNullOrEmpty(_code))
            {
                ktxtProductCode.Text = _code;
                //await FilterData();
            }
        }


        private async Task FilterData()
        {
            await Task.Run(() =>
            {
                kdgvProduct.Invoke(new Action(() =>
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[kdgvProduct.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvProduct.Rows)
                    {
                        var product = row.DataBoundItem as VwProduct;

                        row.Visible = (ktxtProductCode.Text == "" ||
                                       product.ProductCode.ToLower().StartsWith(ktxtProductCode.Text.ToLower())) &&
                                      (ktxtName.Text == "" ||
                                       product.ProductName.ToLower().StartsWith(ktxtName.Text.ToLower())) &&
                                      (ktxtBarcode.Text == "" ||
                                       product.Barcode.ToLower().StartsWith(ktxtBarcode.Text.ToLower()));
                    }
                    currencyManager1.ResumeBinding();
                }));
            });
        }

        private async Task LoadCustomers()
        {
            kdgvProduct.DataSource = await ApiHelper.GetProductList();
        }

        private async void ktxtFilter_TextChanged(object sender, EventArgs e)
        {
            await FilterData();
        }

        private void kdgvCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvProduct.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvProduct.Rows[test.RowIndex].Selected = true;
        }

        private void kdgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedProduct = kdgvProduct.CurrentRow?.DataBoundItem as VwProduct;

            this.DialogResult = DialogResult.OK;
        }
    }
}
