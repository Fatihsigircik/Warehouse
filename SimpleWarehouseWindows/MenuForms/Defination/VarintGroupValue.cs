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
    public partial class VariantGroupValue : BaseForm
    {

        private List<VariantGroup> _groupList = new List<VariantGroup>();
        private List<VariantProperty> _propertyList = new List<VariantProperty>();

        private int _selectedGroupId;
        public VariantGroupValue()
        {
            InitializeComponent();
            dgvValues.AutoGenerateColumns = false;
        }

        private async void VariantGroupValue_Load(object sender, EventArgs e)
        {
            await LoadGroup();
        }

        private async Task LoadGroup()
        {
            lvGroup.Items.Clear();
            OpenLoader();
            _groupList = await ApiHelper.GetVariantGroupList();
            CloseLoader();
            if(_groupList.Count>0)
            {
                _groupList.ForEach(q => lvGroup.Items.Add(q.VariantGroupId.ToString(), q.Name,""));
                lvGroup.Items[0].Selected = true;
            }
           
            
        }

        private async Task LoadValue(int groupId)
        {
            dgvValues.Rows.Clear();
            OpenLoader();
            _propertyList = await ApiHelper.GetVariantPropertyListByGroupId(groupId);
            dgvValues.DataSource = new BindingSource() { DataSource = _propertyList };
            CloseLoader();
        }

        private async void lvGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvGroup.SelectedItems.Count==0)
                return;
            _selectedGroupId=Convert.ToInt32(lvGroup.SelectedItems[0].Name);
            await LoadValue(_selectedGroupId);
        }

        private async void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new frmMultiField(typeof(VariantProperty));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OpenLoader();
                    var variantProperty = frm.GetObject as VariantProperty;
                    variantProperty.VariantGroupId = _selectedGroupId;
                    await ApiHelper.AddVariantProperty(variantProperty);
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

                await LoadValue(_selectedGroupId);
            }
        }

        private async void dgvValues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            var item = dgvValues.Rows[e.RowIndex].DataBoundItem as VariantProperty;
            if (e.ColumnIndex == 2)
            {

                var frm = new frmMultiField(typeof(VariantProperty), item);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    await ApiHelper.UpdateVariantProperty(item);
                    dgvValues.Refresh();
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
                        await ApiHelper.DeleteVariantProperty(item.VariantPropertyId);
                        await LoadValue(_selectedGroupId);
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
