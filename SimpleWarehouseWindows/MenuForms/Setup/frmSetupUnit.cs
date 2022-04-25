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
    public partial class frmSetupUnit : BaseForm
    {
        private List<Unit> _list = new List<Unit>();
        public frmSetupUnit()
        {
            InitializeComponent();
            kdgvUnit.AutoGenerateColumns = false;
        }

        private void frmSetupUnit_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }
        private async void LoadStatus()
        {
            kdgvUnit.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetUnitList();
            //dgvStatus.DataSource = list;
            kdgvUnit.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }

        private async void kbtnNew_Click(object sender, EventArgs e)
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

        private async void kdgvUnit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            var item = kdgvUnit.Rows[e.RowIndex].DataBoundItem as Unit;
            if (e.ColumnIndex == 2)
            {

                var frm = new frmMultiField(typeof(Unit), item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await ApiHelper.UpdateUnit(item);
                    kdgvUnit.Refresh();
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
    }
}
