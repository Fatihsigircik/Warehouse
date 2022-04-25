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
    public partial class frmSupplierList : BaseForm
    {
        private static frmSupplierList supplierList;
        List<VwSupplier> _list = new List<VwSupplier>();


        public static frmSupplierList GetInstance()
        {
            return supplierList ?? (supplierList = new frmSupplierList());
        }
        public static void RemoveInstance(frmSupplierList frm)
        {

            supplierList = null;
            frm.Close();
            frm.Dispose();
        }
        public frmSupplierList()
        {
            IsOnlyOne = true;
            InitializeComponent();
            kdgvList.AutoGenerateColumns = false;
        }

        private async void frmSupplierList_Load(object sender, EventArgs e)
        {
            await LoadSupplier();
        }
        private async Task LoadSupplier()
        {
            kdgvList.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetSupplierList();
            //dgvStatus.DataSource = list;
            kdgvList.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
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
                        var sup = row.DataBoundItem as VwSupplier;

                        row.Visible = (ktxtSupplierCode.Text == "" ||
                                       sup.SupplierCode.ToLower().StartsWith(ktxtSupplierCode.Text.ToLower())) &&
                                      (ktxtCompanyName.Text == "" || sup.CompanyName.ToLower()
                                           .StartsWith(ktxtCompanyName.Text.ToLower())) &&
                                      (ktxtName.Text == "" ||
                                       sup.SupplierName.ToLower().StartsWith(ktxtName.Text.ToLower())) &&
                                      (ktxtSurname.Text == "" ||
                                       sup.SupplierSurname.ToLower().StartsWith(ktxtSurname.Text.ToLower())) &&
                                      (ktxtPhone.Text == "" || sup.Phone.Contains(ktxtPhone.Text)) &&
                                      (ktxtCity.Text == "" || sup.CityName.ToLower().StartsWith(ktxtCity.Text.ToLower()));
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
        }
        private async void txtFilter_TextChanged(object sender, EventArgs e)
        {
            await FilterData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
                LoadSupplier();
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void kdgvList_MouseDown(object sender, MouseEventArgs e)
        {
            var test = kdgvList.HitTest(e.X, e.Y);
            if (test.RowIndex == -1)
                return;
            kdgvList.Rows[test.RowIndex].Selected = true;
        }

        private void tsmiNewSupplier_Click(object sender, EventArgs e)
        {

            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewSupplier>(0);
        }


        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            UpdateSupplier();
        }

        private void UpdateSupplier()
        {
            var supplier = kdgvList.SelectedRows[0].DataBoundItem as VwSupplier;
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewSupplier>(supplier.SupplierId);
        }

        private void kdgvList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //var test = kdgvList.HitTest(e.X, e.Y);
            //if (test.RowIndex == -1)
            //    return;
            //kdgvList.Rows[test.RowIndex].Selected = true;
            UpdateSupplier();
        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kaydı Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var supplier = kdgvList.SelectedRows[0].DataBoundItem as VwSupplier;
                await ApiHelper.DeleteSupplier(supplier.SupplierId);
                await LoadSupplier();
            }
        }

    }
}
