using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.FormHelper
{
    public partial class frmWerahouseSelect : Form
    {
       internal (Warehouse Warehouse,string DocNumber) Info=>(Warehouse,txtDocNumber.Text);

       private Warehouse Warehouse => cbWarehouse.SelectedItem as Warehouse;
        public frmWerahouseSelect()
        {
            InitializeComponent();
            LoadDepo();
        }

        private async void LoadDepo()
        {
           var list= await ApiHelper.GetWarehouseList();
           cbWarehouse.DataSource = list;
           cbWarehouse.DisplayMember= "WarehouseName";
           cbWarehouse.ValueMember = "WarehouseId";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtDocNumber.Text.Length == 0)
            {
                MessageBox.Show("Bir Belge Numarası Giriniz..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
