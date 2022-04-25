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

namespace SimpleWarehouseWindows.NewForm.Order
{
    public partial class frmOrderList : BaseForm
    {
        private static frmOrderList productList;

        List<VwOrder> _list = new List<VwOrder>();

        public static frmOrderList GetInstance()
        {
            return productList ?? (productList = new frmOrderList());
        }

        public static void RemoveInstance(frmOrderList frm)
        {
            productList = null;
            frm.Close();
            frm.Dispose();
        }

        public frmOrderList()
        {
            IsOnlyOne = true;
            InitializeComponent();
            SetDefaultDate();
            kdgvList.AutoGenerateColumns = false;
        }

        private async void frmOrderList_Load(object sender, EventArgs e)
        {
            await LoadOrders();
        }
        private void SetDefaultDate()
        {
            kdtpStartDate.Value = new DateTime(2010, 1, 1);
            kdtpEndDate.Value = DateTime.Now.Date.AddDays(1);
        }
        private async Task LoadOrders()
        {
            kdgvList.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetOrderList();
            //dgvStatus.DataSource = list;
            kdgvList.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
                LoadOrders();
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
            if (kdgvList.DataSource == null)
                return;
            await Task.Run(() =>
            {
                kdgvList.Invoke(new Action(() =>
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[kdgvList.DataSource];
                    currencyManager1.SuspendBinding();
                    foreach (DataGridViewRow row in kdgvList.Rows)
                    {
                        var productDetails = row.DataBoundItem as VwOrder;

                        row.Visible = (ktxtOrderCode.Text == "" || productDetails.OrderCode.ToLower().StartsWith(ktxtOrderCode.Text.ToLower())) &&
                                      (productDetails.OrderDate >= kdtpStartDate.Value.Date) &&
                                      (productDetails.OrderDate < kdtpEndDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59)) &&

                                      (ktxtDocumentNumber.Text == "" || productDetails.DocNumber.ToLower().StartsWith(ktxtDocumentNumber.Text.ToLower())) &&

                                      (string.IsNullOrEmpty(ktxtCustomer.Text) || (productDetails.CustomerTitle ?? "").ToLower().StartsWith(ktxtCustomer.Text.ToLower())) &&

                                      ((kcbOrderType.SelectedIndex == 0 || kcbOrderType.SelectedIndex==-1) || productDetails.OrderTypeName.ToLower().StartsWith(kcbOrderType.SelectedItem.ToString().ToLower()));
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

            kcbOrderType.SelectedIndex = 0;

            SetDefaultDate();
        }




        private void tsmiNewOrder_Click(object sender, EventArgs e)
        {
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewOrder>(0);
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {

            UpdateOrder();
        }

        private void UpdateOrder()
        {
            var order = kdgvList.SelectedRows[0].DataBoundItem as VwOrder;
            if(order.OrderTypeId==2)
            {
                var tab = this.ParentForm as frmMain2;
                tab.OpenForm<frmNewOrder>(order.OrderId);
            }
            else if (order.OrderTypeId == 1)
            {
                var tab = this.ParentForm as frmMain2;
                tab.OpenForm<frmNewRetailOrder>(order.OrderId);
            }
            else if (order.OrderTypeId == 3)
            {
                var tab = this.ParentForm as frmMain2;
                tab.OpenForm<frmNewInternetOrder>(order.OrderId);
            }

        }

        private async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if(kdgvList.CurrentRow == null || kdgvList.CurrentRow.Index==-1)
                return;

            if (MessageBox.Show("Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    var order = kdgvList.SelectedRows[0].DataBoundItem as VwOrder;
                    await ApiHelper.DeleteOrder(order.OrderId);

                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private async void kcbOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await FilterData();
        }

        private void tsmiNewRetailOrder_Click(object sender, EventArgs e)
        {
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewRetailOrder>(0);
        }

        private void tsmiNewInternetOrder_Click(object sender, EventArgs e)
        {
            var tab = this.ParentForm as frmMain2;
            tab.OpenForm<frmNewInternetOrder>(0);
        }
    }
}
