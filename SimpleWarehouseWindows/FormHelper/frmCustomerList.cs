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
    public partial class frmCustomerList : BaseForm
    {
        private readonly string _code;
        public VwCustomer SelectedCustomer { get; private set; }
        public frmCustomerList(string code="")
        {
            _code = code;
            InitializeComponent();
            kdgvCustomers.AutoGenerateColumns = false;
        }

       

        private async void frmCustomerList_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
            if (!string.IsNullOrEmpty(_code))
            {
                ktxtCusromarCode.Text = _code;
                //await FilterData();
            }
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
                        var cus = row.DataBoundItem as VwCustomer;

                        row.Visible = (ktxtCusromarCode.Text == "" ||
                                       cus.CustomerCode.ToLower().StartsWith(ktxtCusromarCode.Text.ToLower())) &&
                                      (ktxtCompanyName.Text == "" || cus.CompanyName.ToLower()
                                           .StartsWith(ktxtCompanyName.Text.ToLower())) &&
                                      (ktxtName.Text == "" ||
                                       cus.CustomerName.ToLower().StartsWith(ktxtName.Text.ToLower())) &&
                                      (ktxtSurname.Text == "" ||
                                       cus.CustomerSurname.ToLower().StartsWith(ktxtSurname.Text.ToLower()));
                    }
                    currencyManager1.ResumeBinding();
                }));
            });
        }

        private async Task LoadCustomers()
        {
            kdgvCustomers.DataSource = await ApiHelper.GetCustomerList();
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
            SelectedCustomer= kdgvCustomers.CurrentRow?.DataBoundItem as VwCustomer;
            
            this.DialogResult = DialogResult.OK;
        }
    }
}
