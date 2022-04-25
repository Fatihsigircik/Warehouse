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
    public partial class frmSetupVariantGroup : BaseForm
    {
        private List<VariantGroup> _list = new List<VariantGroup>();
        public frmSetupVariantGroup()
        {
            InitializeComponent();
            kdgvVariantGroup.AutoGenerateColumns = false;
        }

        private void frmSetupVariantGroup_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }
        private async void LoadStatus()
        {
            kdgvVariantGroup.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetVariantGroupList();
            //dgvStatus.DataSource = list;
            kdgvVariantGroup.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }

        private async void kbtnNew_Click(object sender, EventArgs e)
        {
            var frm = new frmMultiField(typeof(VariantGroup));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenLoader();
                    var variantGroup = frm.GetObject as VariantGroup;
                    await ApiHelper.AddVariantGroup(variantGroup);


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

        private async void kdgvVariantGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            var item = kdgvVariantGroup.Rows[e.RowIndex].DataBoundItem as VariantGroup;
            if (e.ColumnIndex == 2)
            {

                var frm = new frmMultiField(typeof(VariantGroup), item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await ApiHelper.UpdateVariantGroup(item);
                    kdgvVariantGroup.Refresh();
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
                        await ApiHelper.DeleteVariantGroup(item.VariantGroupId);
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
