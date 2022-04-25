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
    public partial class frmSupplierList : BaseForm
    {
        private readonly string _code;
        private VwSupplier _selectedsSupplier;
        public VwSupplier SelectedSupplier => _selectedsSupplier;
        public frmSupplierList(string code = "")
        {
            _code = code;
            InitializeComponent();
            kdgvCustomers.AutoGenerateColumns = false;
        }

        private async void frmSupplierList_Load(object sender, EventArgs e)
        {
            await LoadSupplier();
            if (!string.IsNullOrEmpty(_code))
            {
                ktxtCusromarCode.Text = _code;
                //await FilterData();
            }
        }
        private async Task LoadSupplier()
        {
            kdgvCustomers.DataSource = await ApiHelper.GetSupplierList();
        }
        private async Task FilterData()
        {
            await Task.Run(() =>
            {
                kdgvCustomers.Invoke(new Action(() =>
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[kdgvCustomers.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvCustomers.Rows)
                    {
                        var supplier = row.DataBoundItem as VwSupplier;

                        row.Visible = (ktxtCusromarCode.Text == "" ||
                                       supplier.SupplierCode.ToLower().StartsWith(ktxtCusromarCode.Text.ToLower())) &&
                                      (ktxtCompanyName.Text == "" || supplier.CompanyName.ToLower()
                                           .StartsWith(ktxtCompanyName.Text.ToLower())) &&
                                      (ktxtName.Text == "" ||
                                       supplier.SupplierName.ToLower().StartsWith(ktxtName.Text.ToLower())) &&
                                      (ktxtSurname.Text == "" ||
                                       supplier.SupplierSurname.ToLower().StartsWith(ktxtSurname.Text.ToLower()));
                    }
                    currencyManager1.ResumeBinding();
                }));
            });
        }


        private async void ktxtFilter_TextChanged(object sender, EventArgs e)
        {
            await FilterData();
        }

        private void kdgvCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvCustomers.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvCustomers.Rows[test.RowIndex].Selected = true;
        }

        private void kdgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedsSupplier = kdgvCustomers.CurrentRow?.DataBoundItem as VwSupplier;

            this.DialogResult = DialogResult.OK;
        }

    }
}
