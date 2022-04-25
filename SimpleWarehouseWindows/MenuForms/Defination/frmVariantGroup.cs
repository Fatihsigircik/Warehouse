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
    public partial class frmVariantGroup : BaseForm
    {
        private List<VariantGroup> _list = new List<VariantGroup>();
        public frmVariantGroup()
        {
            InitializeComponent();
            dgvStatus.AutoGenerateColumns = false;
        }

        private void frmVariantGroup_Load(object sender, EventArgs e)
        {
            LoadStatus();
        }

        private async void LoadStatus()
        {
            dgvStatus.Rows.Clear();
            OpenLoader();
            _list = await ApiHelper.GetVariantGroupList();
            //dgvStatus.DataSource = list;
            dgvStatus.DataSource = new BindingSource() { DataSource = _list };
            CloseLoader();
        }

        private async void btnNew_Click(object sender, EventArgs e)
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

        private async void dgvStatus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            var item = dgvStatus.Rows[e.RowIndex].DataBoundItem as VariantGroup;
            if (e.ColumnIndex == 2)
            {

                var frm = new frmMultiField(typeof(VariantGroup), item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await ApiHelper.UpdateVariantGroup(item);
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
