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
    public partial class frmCustomerDetailList : BaseForm
    {
        private static frmCustomerDetailList customerList;
        //List<VwCustomer> _list = new List<VwCustomer>();


        public static frmCustomerDetailList GetInstance()
        {
            return customerList ?? (customerList = new frmCustomerDetailList());
        }
        public static void RemoveInstance(frmCustomerDetailList frm)
        {

            customerList = null;
            frm.Close();
            frm.Dispose();
        }
        public frmCustomerDetailList()
        {
            IsOnlyOne = true;
            InitializeComponent();
            kdgvList.AutoGenerateColumns = false;

        }

        private void frmCustomerDetailList_Load(object sender, EventArgs e)
        {
            LoadCustomerDetail();
            SetDefaultDate();
        }

        private void SetDefaultDate()
        {
            kdtpStartDate.Value = new DateTime(2010, 1, 1);
            kdtpEndDate.Value = DateTime.Now.Date.AddDays(1);
        }

        private async void LoadCustomerDetail()
        {
            OpenLoader();
            var list = await ApiHelper.GetCustomerDetailList();
            kdgvList.DataSource = list;
            CloseLoader();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
                LoadCustomerDetail();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void kdgvList_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvList.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvList.Rows[test.RowIndex].Selected = true;
        }

        private async void ktxtFilter_TextChanged(object sender, EventArgs e)
        {
            await FilterData();
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
                        var cus = row.DataBoundItem as VwCustomerDetail;

                        row.Visible = (ktxtCustomerDetailCode.Text == "" || cus.DetailCode.ToLower().StartsWith(ktxtCustomerDetailCode.Text.ToLower())) &&
                                      (cus.DetailDate >= kdtpStartDate.Value.Date) &&
                                      (cus.DetailDate < kdtpEndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) &&

                                      (ktxtCustomerCode.Text == "" || cus.CustomerCode.ToLower().StartsWith(ktxtCustomerCode.Text.ToLower())) &&
                                      (ktxtNane.Text == "" || cus.CustomerName.ToLower().StartsWith(ktxtNane.Text.ToLower())) &&
                                      (ktxtSurname.Text == "" || cus.CustomerSurname.ToLower().StartsWith(ktxtSurname.Text.ToLower())) &&
                                      (ktxtCompanyName.Text == "" || cus.CompanyName.ToLower().StartsWith(ktxtCompanyName.Text.ToLower()));
                    }
                    currencyManager1.ResumeBinding();
                }));
            });
        }
        private void kbtnClearFilter_Click(object sender, EventArgs e)
        {
            var txts = kgbFilter.Panel.Controls.Cast<Control>().Where(q => q.GetType() == typeof(KryptonTextBox));
            foreach (Control txt in txts)
            {
                txt.Text = String.Empty;

            }
            SetDefaultDate();
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            var detail = kdgvList.SelectedRows[0].DataBoundItem as VwCustomerDetail;
            var frm = new frmCustomerDetail(detail.CustomerDetailId);
            frm.ShowDialog();
            LoadCustomerDetail();
        }

        private void tsmiNewCustomerDetail_Click(object sender, EventArgs e)
        {
            var frm = new frmCustomerDetail(0);
            frm.ShowDialog();
            LoadCustomerDetail();
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var detail = kdgvList.SelectedRows[0].DataBoundItem as VwCustomerDetail;
                    await ApiHelper.DeleteCustomerDetail(detail.CustomerDetailId);
                    LoadCustomerDetail();
                    MessageBox.Show("Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Hata Oluştu...{Environment.NewLine}{exception.Message}", "Hata",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
