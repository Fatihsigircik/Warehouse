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

namespace SimpleWarehouseWindows.NewForm.Supplier
{
    public partial class frmSupplierDetailList : BaseForm
    {
        private static frmSupplierDetailList supplierDetailList;
        


        public static frmSupplierDetailList GetInstance()
        {
            return supplierDetailList ?? (supplierDetailList = new frmSupplierDetailList());
        }
        public static void RemoveInstance(frmSupplierDetailList frm)
        {
            supplierDetailList = null;
            frm.Close();
            frm.Dispose();
        }
        public frmSupplierDetailList()
        {
            IsOnlyOne = true;
            InitializeComponent();
            kdgvList.AutoGenerateColumns = false;
        }

        private void frmSupplierDetailList_Load(object sender, EventArgs e)
        {
            LoadSupplierDetail();
            SetDefaultDate();
        }

        private void SetDefaultDate()
        {
            kdtpStartDate.Value = new DateTime(2010, 1, 1);
            kdtpEndDate.Value = DateTime.Now.Date.AddDays(1);
        }

        private async void LoadSupplierDetail()
        {
            OpenLoader();
            var list = await ApiHelper.GetSupplierDetailList();
            kdgvList.DataSource = list;
            CloseLoader();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
                LoadSupplierDetail();
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
                    if(kdgvList.DataSource==null)
                        return;
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[kdgvList.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvList.Rows)
                    {
                        var supplierDetail = row.DataBoundItem as VwSupplierDetail;

                        row.Visible = (ktxtSupplierDetailCode.Text == "" || supplierDetail.DetailCode.ToLower().StartsWith(ktxtSupplierDetailCode.Text.ToLower())) &&
                                      (supplierDetail.DetailDate >= kdtpStartDate.Value.Date) &&
                                      (supplierDetail.DetailDate < kdtpEndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) &&

                                      (ktxtSupplierCode.Text == "" || supplierDetail.SupplierCode.ToLower().StartsWith(ktxtSupplierCode.Text.ToLower())) &&
                                      (ktxtNane.Text == "" || supplierDetail.SupplierName.ToLower().StartsWith(ktxtNane.Text.ToLower())) &&
                                      (ktxtSurname.Text == "" || supplierDetail.SupplierSurname.ToLower().StartsWith(ktxtSurname.Text.ToLower())) &&
                                      (ktxtCompanyName.Text == "" || supplierDetail.CompanyName.ToLower().StartsWith(ktxtCompanyName.Text.ToLower()));
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
            var detail = kdgvList.SelectedRows[0].DataBoundItem as VwSupplierDetail;
            var frm = new frmSupplierDetail(detail.SupplierDetailId);
            frm.Saved += Frm_Saved;
            frm.ShowDialog();
           
        }

        private void Frm_Saved(object sender, EventArgs e)
        {
            LoadSupplierDetail();
        }

        private void tsmiNewCustomerDetail_Click(object sender, EventArgs e)
        {
            var frm = new frmSupplierDetail(0);
            frm.Saved += Frm_Saved;
            frm.ShowDialog();
            LoadSupplierDetail();
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var detail = kdgvList.SelectedRows[0].DataBoundItem as VwSupplierDetail;
                    await ApiHelper.DeleteSupplierDetail(detail.SupplierDetailId);
                    LoadSupplierDetail();
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
