using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.MenuForms.Setup
{
    public partial class frmSetupOrderStatus : BaseForm
    {
        private List<OrderStatus> _list = new List<OrderStatus>();
        public frmSetupOrderStatus()
        {
            InitializeComponent();
            dgvStatus.AutoGenerateColumns = false;
        }

        private void frmSetupOrderStatus_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }
        private async void LoadStatus()
        {
            dgvStatus.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetOrderStatusList();
            //dgvStatus.DataSource = list;
            dgvStatus.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }

        private async void kbtnNew_Click(object sender, EventArgs e)
        {
            var frm = new frmMultiField(typeof(OrderStatus));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenLoader();
                    var orderStatus = frm.GetObject as OrderStatus;
                    await ApiHelper.AddOrderStatus(orderStatus);


                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                finally
                {
                    CloseLoader();
                }
                LoadStatus();
            }

        }

        private async void dgvStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            var item = dgvStatus.Rows[e.RowIndex].DataBoundItem as OrderStatus;
            if (e.ColumnIndex == 2)
            {

                var frm = new frmMultiField(typeof(OrderStatus), item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await ApiHelper.UpdateOrderStatus(item);
                    dgvStatus.Refresh();
                }

            }
            else if (e.ColumnIndex == 3)
            {
                try
                {
                    var msg = MessageBox.Show("Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    if (msg == DialogResult.Yes)
                    {
                        await ApiHelper.DeleteOrderStatus(item.OrderStatusId);
                        LoadStatus();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}
