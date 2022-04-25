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

namespace SimpleWarehouseWindows.NewForm.Supplier
{
    public partial class frmSupplierDetail : BaseForm
    {
        private readonly int _detailId;
        public event EventHandler Saved;
        private static frmSupplierDetail supplierDetail;
        private Models.Supplier _currentSupplier;

        public static frmSupplierDetail GetInstance(int supplierDetailCode)
        {
            return supplierDetail ?? (supplierDetail = new frmSupplierDetail());
        }
        public static void RemoveInstance(frmSupplierDetail frm)
        {

            supplierDetail = null;
            frm.Close();
            frm.Dispose();
        }
        public frmSupplierDetail(int detailId = 0)
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
            var detail = await ApiHelper.GetSupplierDetail(_detailId);
            if (detail == null)
            {
                MessageBox.Show($"{_detailId} Id Numaralı Kayıt Bulunamadı...", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var supplier = await ApiHelper.GetSupplier(detail.SupplierId);
            LoadSupplierInfo(supplier);
            LoadDetailInfo(detail);
            CloseLoader();
        }
        private void LoadSupplierInfo(Models.Supplier supplier)
        {
            _currentSupplier = supplier;
            ktxtCustomerCode.Text = _currentSupplier.SupplierCode;
            ktxtCompanyName.Text = _currentSupplier.CompanyName;
            ktxtCustomerSurname.Text = _currentSupplier.SupplierSurname;
            ktxtCustomerName.Text = _currentSupplier.SupplierName;
        }
        private void LoadDetailInfo(SupplierDetail supplierDetail)
        {
            ktxtDetailCode.Text = supplierDetail.DetailCode;
            kdtpDetailDate.Value = supplierDetail.DetailDate ?? DateTime.Now;
            ktxtCredit.Text = supplierDetail.Credit.Value.ToString("#0.00");
            ktxtDebt.Text = supplierDetail.Debt.Value.ToString("#0.00");
            ktxtDetail.Text = supplierDetail.Detail;
            kcbDetailType.SelectedValue = supplierDetail.DetailTypeId;
        }

        private void LoadDetailType()
        {
            kcbDetailType.DataSource = ApiHelper.GetCustomerDetailsSynchronous();
            kcbDetailType.DisplayMember = "DetailTypeName";
            kcbDetailType.ValueMember = "CustomerDetailTypeId";
        }

        private void kbtnSelectSupplier_Click(object sender, EventArgs e)
        {
            OpenSelectSupplierForm();
        }
        private void OpenSelectSupplierForm()
        {
            FormHelper.frmSupplierList frm = new FormHelper.frmSupplierList(ktxtCustomerCode.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadSupplierInfo(frm.SelectedSupplier);
            }
        }

        private string[] _numericChars = ("1|2|3|4|5|6|7|8|9|0|-|\b|" + CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator).Split('|');
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
                    await ApiHelper.AddSupplierDetail(detail);
                else
                {
                    detail.SupplierDetailId = _detailId;
                    await ApiHelper.UpdateSupplierDetail(detail);
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

        private SupplierDetail GetDetail()
        {
            return new SupplierDetail()
            {
                DetailCode = ktxtDetailCode.Text,
                SupplierId = _currentSupplier.SupplierId,
                DetailDate = kdtpDetailDate.Value,
                CreateDate = DateTime.Now,
                Credit = Convert.ToDecimal(ktxtCredit.Text),
                Debt = Convert.ToDecimal(ktxtDebt.Text),
                Detail = ktxtDetail.Text,
                DetailTypeId = (kcbDetailType.SelectedItem as CustomerDetailType).CustomerDetailTypeId
            };
        }

    }
}
