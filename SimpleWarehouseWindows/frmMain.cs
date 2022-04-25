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
using SimpleWarehouseWindows.MenuForms;
using SimpleWarehouseWindows.MenuForms.Product;

namespace SimpleWarehouseWindows
{
    public partial class frmMain : BaseForm
    {
        private bool isLogin;
        public frmMain()
        {
            InitializeComponent();
            var result = new frmLogin().ShowDialog();
            if (result != DialogResult.OK)
                return;
            isLogin = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!isLogin)
                this.Close();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isLogin)
                return;
            if (MessageBox.Show("'Kolay Depo' Programını Kapatmak İstiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return;
            }

            e.Cancel = true;
        }

        #region Defination Menu Events
        private void btnDefinitions_Click(object sender, EventArgs e)
        {
            var p = this.PointToScreen(new Point(btnDefinitions.Right, btnDefinitions.Top));
            cmsDefinition.Show(p.X + 15, p.Y);
        }

        private void tsmiOrderStatus_Click(object sender, EventArgs e)
        {
            LoadForm<frmOrderStatus>();
        }

        private void tsmiUnits_Click(object sender, EventArgs e)
        {
            LoadForm<frmUnit>();
        }

        private void tsmiVariantGroup_Click(object sender, EventArgs e)
        {
            LoadForm<frmVariantGroup>();
        }
        private void tsmiVariantGroupValues_Click(object sender, EventArgs e)
        {
            LoadForm<VariantGroupValue>();
        }
        #endregion

        private void LoadForm<T>(params object[] paramArray) where T : BaseForm
        {
            pnlMain.Controls.Clear();
            var frm = (T)Activator.CreateInstance(typeof(T),args:paramArray);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            new Helpers.Helper().CenterForm(frm);
            frm.Show();
        }



        private void btnCustomer_Click(object sender, EventArgs e)
        {
            //LoadForm<frmCustomer>();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            var p = this.PointToScreen(new Point(btnProduct.Right, btnProduct.Top));
            cmsProduct.Show(p.X + 15, p.Y);
        }

        private void tsmiProduct_Click(object sender, EventArgs e)
        {
            //LoadForm<frmProduct>();
        }

        private void tsmiProductIn_Click(object sender, EventArgs e)
        {
            LoadForm<frmProductOutlet>((short)1);
        }

        private void tsmiProductOut_Click(object sender, EventArgs e)
        {
            LoadForm<frmProductOutlet>((short)-1);
        }
    }
}
