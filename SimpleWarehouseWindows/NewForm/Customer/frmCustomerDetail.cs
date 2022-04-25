using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace SimpleWarehouseWindows.NewForm.Customer
{
    public partial class frmCustomerDetail : BaseForm
    {
        private readonly int _detailId;
        public event EventHandler Saved;
        private static frmCustomerDetail customerDetail;
        private Models.Customer _currentCustomer;

        public static frmCustomerDetail GetInstance(int customerDetailCode)
        {
            return customerDetail ?? (customerDetail = new frmCustomerDetail());
        }
        public static void RemoveInstance(frmCustomerDetail frm)
        {

            customerDetail = null;
            frm.Close();
            frm.Dispose();
        }


        public frmCustomerDetail(int detailId = 0)
        {
            _detailId = detailId;
            InitializeComponent();
            LoadDetailType();
            if (_detailId > 0)
                LoadDetail();
        }

        private async void LoadDetail()
        {
            OpenLoader();
            var detail = await ApiHelper.GetCustomerDetail(_detailId);
            if (detail == null)
            {
                MessageBox.Show($"{_detailId} Id Numaralı Kayıt Bulunamadı...", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var customer = await ApiHelper.GetCustomer(detail.CustomerId);
            LoadCustomerInfo(customer);
            LoadDetailInfo(detail);
            CloseLoader();
        }

        private void LoadDetailInfo(CustomerDetail customerDetail)
        {
            ktxtDetailCode.Text = customerDetail.DetailCode;
            kdtpDetailDate.Value = customerDetail.DetailDate ?? DateTime.Now;
            ktxtCredit.Text = customerDetail.Credit.Value.ToString("#0.00");
            ktxtDebt.Text = customerDetail.Debt.Value.ToString("#0.00");
            ktxtDetail.Text = customerDetail.Detail;
            kcbDetailType.SelectedValue = customerDetail.DetailTypeId;
        }

        private void LoadDetailType()
        {
            kcbDetailType.DataSource = ApiHelper.GetCustomerDetailsSynchronous();
            kcbDetailType.DisplayMember = "DetailTypeName";
            kcbDetailType.ValueMember = "CustomerDetailTypeId";
        }

        private void kbtnSelectCustomer_Click(object sender, EventArgs e)
        {
            OpenSelectCustomerForm();
        }

        private void OpenSelectCustomerForm()
        {
            FormHelper.frmCustomerList frm = new FormHelper.frmCustomerList(ktxtCustomerCode.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadCustomerInfo(frm.SelectedCustomer);
            }
        }

        private void LoadCustomerInfo(Models.Customer customer)
        {
            _currentCustomer = customer;
            ktxtCustomerCode.Text = _currentCustomer.CustomerCode;
            ktxtCompanyName.Text = _currentCustomer.CompanyName;
            ktxtCustomerSurname.Text = _currentCustomer.CustomerSurname;
            ktxtCustomerName.Text = _currentCustomer.CustomerName;
        }

        private string[] _numericChars = ("1|2|3|4|5|6|7|8|9|0|-|\b|"  + CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator).Split('|');
        //private bool _isNumber;
        private void ktxt_KeyDown(object sender, KeyEventArgs e)
        {


        }

        private void ktxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_numericChars.Contains((e.KeyChar).ToString()))
                e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDetail();
        }

        private async void SaveDetail()
        {
            try
            {
                var detail = GetDetail();
                if (_detailId == 0)
                    await ApiHelper.AddCustomerDetail(detail);
                else
                {
                    detail.CustomerDetailId = _detailId;
                    await ApiHelper.UpdateCustomerDetail(detail);
                }

                Saved?.Invoke(this, null);
                MessageBox.Show("Kayıt Yapıldı...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Hata Alındı... {Environment.NewLine}{e.Message}", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private CustomerDetail GetDetail()
        {
            return new CustomerDetail()
            {
                DetailCode = ktxtDetailCode.Text,
                CustomerId = _currentCustomer.CustomerId,
                DetailDate = kdtpDetailDate.Value,
                CreateDate = DateTime.Now,
                Credit = Convert.ToDecimal(ktxtCredit.Text),
                Debt = Convert.ToDecimal(ktxtDebt.Text),
                Detail = ktxtDetail.Text,
                DetailTypeId = (kcbDetailType.SelectedItem as CustomerDetailType).CustomerDetailTypeId
            };
        }


        private void ktxtCredit_Enter_1(object sender, EventArgs e)
        {
            ktxtCredit.SelectAll();
        }
    }
}
