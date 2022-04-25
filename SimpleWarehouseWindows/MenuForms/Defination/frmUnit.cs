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

namespace SimpleWarehouseWindows.MenuForms
{
    public partial class frmUnit : BaseForm
    {
        private List<Unit> _list = new List<Unit>();
        public frmUnit()
        {
            InitializeComponent();
            dgvStatus.AutoGenerateColumns = false;
        }

        private void frmUnit_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }

        private async void LoadStatus()
        {
            dgvStatus.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetUnitList();
            //dgvStatus.DataSource = list;
            dgvStatus.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new frmMultiField(typeof(Unit));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenLoader();
                    var orderStatus = frm.GetObject as Unit;
                    await ApiHelper.AddUnit(orderStatus);


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
            var item = dgvStatus.Rows[e.RowIndex].DataBoundItem as Unit;
            if (e.ColumnIndex == 2)
            {

                var frm = new frmMultiField(typeof(Unit), item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await ApiHelper.UpdateUnit(item);
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
                        await ApiHelper.DeleteUnit(item.UnitId);
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

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Coral;
        }

        private void lblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
