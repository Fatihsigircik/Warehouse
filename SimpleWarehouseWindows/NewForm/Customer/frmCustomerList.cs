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
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.NewForm.Customer
{
    public partial class frmCustomerList : BaseForm
    {
        private static frmCustomerList customerList;
        List<VwCustomer> _list = new List<VwCustomer>();


        public static frmCustomerList GetInstance()
        {
            return customerList ?? (customerList = new frmCustomerList());
        }
        public static void RemoveInstance(frmCustomerList frm)
        {

            customerList = null;
            frm.Close();
            frm.Dispose();
        }
        private frmCustomerList()
        {
            IsOnlyOne = true;
            InitializeComponent();
            kdgvList.AutoGenerateColumns = false;
        }

        private async void frmCustomerList_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
        }
        private async Task LoadCustomers()
        {
            kdgvList.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetCustomerList();
            //dgvStatus.DataSource = list;
            kdgvList.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }

        private void frmCustomerList_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private async Task FilterData()
        {
            await Task.Run(() =>
            {
                kdgvList.Invoke(new Action(() =>
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[kdgvList.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvList.Rows)
                    {
                        var cus = row.DataBoundItem as VwCustomer;

                        row.Visible = (ktxtCustomerCode.Text == "" ||
                                       cus.CustomerCode.ToLower().StartsWith(ktxtCustomerCode.Text.ToLower())) &&
                                      (ktxtCompanyName.Text == "" || cus.CompanyName.ToLower()
                                           .StartsWith(ktxtCompanyName.Text.ToLower())) &&
                                      (ktxtName.Text == "" ||
                                       cus.CustomerName.ToLower().StartsWith(ktxtName.Text.ToLower())) &&
                                      (ktxtSurname.Text == "" ||
                                       cus.CustomerSurname.ToLower().StartsWith(ktxtSurname.Text.ToLower())) &&
                                      (ktxtPhone.Text == "" || cus.Phone.Contains(ktxtPhone.Text)) &&
                                      (ktxtCity.Text == "" || cus.CityName.ToLower().StartsWith(ktxtCity.Text.ToLower()));
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
                LoadCustomers();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void kdgvList_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvList.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvList.Rows[test.RowIndex].Selected = true;
        }

        private void tsmiNewCustomer_Click(object sender, EventArgs e)
        {
            
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewCustomer>(0);
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            var customer = kdgvList.SelectedRows[0].DataBoundItem as VwCustomer;
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewCustomer>(customer.CustomerId);
        }

        private void kdgvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var test = kdgvList.HitTest(e.X, e.Y);
            //if (test.RowIndex == -1)
            //    return;
            //kdgvList.Rows[test.RowIndex].Selected = true;
            UpdateCustomer();
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kaydı Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var customer = kdgvList.SelectedRows[0].DataBoundItem as VwCustomer;
                await ApiHelper.DeleteCustomer(customer.CustomerId);
                await LoadCustomers();
            }
        }
    }
}
