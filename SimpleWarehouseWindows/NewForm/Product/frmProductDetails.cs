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

namespace SimpleWarehouseWindows.NewForm.Product
{
    public partial class frmProductDetails : BaseForm
    {
        private static frmProductDetails _productDetails;
        List<VwProductDetails> _list = new List<VwProductDetails>();


        public static frmProductDetails GetInstance()
        {
            return _productDetails ?? (_productDetails = new frmProductDetails());
        }
        public static void RemoveInstance(frmProductDetails frm)
        {

            _productDetails = null;
            frm.Close();
            frm.Dispose();
        }
        public frmProductDetails()
        {
            IsOnlyOne = true;
            InitializeComponent();
            SetDefaultDate();
            kdgvList.AutoGenerateColumns = false;
        }

        private async void frmProductDetails_Load(object sender, EventArgs e)
        {
            await LoadProductDetails();
            
        }
        private void SetDefaultDate()
        {
            kdtpStartDate.Value = new DateTime(2010, 1, 1);
            kdtpEndDate.Value = DateTime.Now.Date.AddDays(1);
        }
        private async Task LoadProductDetails()
        {
            kdgvList.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetProductDetails();
            //dgvStatus.DataSource = list;
            kdgvList.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
                LoadProductDetails();
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
            if(kdgvList.DataSource==null)
                return;
            await Task.Run(() =>
            {
                kdgvList.Invoke(new Action(() =>
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[kdgvList.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvList.Rows)
                    {
                        var productDetails = row.DataBoundItem as VwProductDetails;

                        row.Visible = (ktxtProductCode.Text == "" || productDetails.ProductCode.ToLower().StartsWith(ktxtProductCode.Text.ToLower())) &&
                                      (productDetails.CreatedDate >= kdtpStartDate.Value.Date) &&
                                      (productDetails.CreatedDate < kdtpEndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) &&

                                      (ktxtProductName.Text == "" || productDetails.ProductName.ToLower().StartsWith(ktxtProductName.Text.ToLower())) &&
                                      (string.IsNullOrEmpty(ktxtCompanyName.Text) || (productDetails.CompanyName??"").ToLower().StartsWith(ktxtCompanyName.Text.ToLower())) &&
                                      (ktxtDocumentNumber.Text == "" || productDetails.DocumentCode.ToLower().StartsWith(ktxtDocumentNumber.Text.ToLower())) &&
                                      (ktxtWareHouse.Text == "" || productDetails.WarehouseName.ToLower().StartsWith(ktxtWareHouse.Text.ToLower()))&&
                            
                            ((krbIn.Checked && productDetails.InOrOut==1) || (!krbIn.Checked && productDetails.InOrOut==-1) ||(!krbIn.Checked && !krbOut.Checked)) &&
                        ((krbApproved.Checked && productDetails.IsApproved ) || (!krbApproved.Checked && !productDetails.IsApproved) || (!krbApproved.Checked && !krbNotApproved.Checked));
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

            krbIn.Checked = krbApproved.Checked = krbNotApproved.Checked = krbOut.Checked = false;

            SetDefaultDate();
        }

        private void kdgvList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                kdgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    (kdgvList.Rows[e.RowIndex].DataBoundItem as VwProductDetails).InOrOut == -1 ? "Çıkış" : "Giriş";
                kdgvList.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    (kdgvList.Rows[e.RowIndex].DataBoundItem as VwProductDetails).InOrOut == -1
                        ? Color.Red
                        : Color.LightGreen;
            }
            else if(e.ColumnIndex==10)
            {
                kdgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    (kdgvList.Rows[e.RowIndex].DataBoundItem as VwProductDetails).IsApproved ? "Onaylandı" : "-";
            }
        }
    }
}
