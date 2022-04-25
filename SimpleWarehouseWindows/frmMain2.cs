using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.MenuForms.Setup;
using SimpleWarehouseWindows.NewForm.Customer;

namespace SimpleWarehouseWindows
{
    public partial class frmMain2 : BaseForm
    {
        private bool isLogin;
        Dictionary<BaseForm, KryptonPage> FormToTab = new Dictionary<BaseForm, KryptonPage>();
        public frmMain2()
        {
            InitializeComponent();
            var result = new frmLogin().ShowDialog();
            if (result != DialogResult.OK)
                return;
            isLogin = true;
        }

        internal void OpenForm<T>(params object[] prm) where T : BaseForm
        {
            var frm = (BaseForm)typeof(T).GetMethod("GetInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null, prm);
            if (frm.IsOnlyOne && FormToTab.ContainsKey(frm))
            {
                var tab = FormToTab[frm];
                kdnMain.SelectedPage=tab;//.Pages[tab.Name].Select();
                
                return;
            }
            var kp = new KryptonPage(frm.Text);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            kp.Controls.Add(frm);
            //frm.Dock = DockStyle.Fill;
            kdnMain.Pages.Add(kp);
            kdnMain.SelectedPage = kp;
           
            frm.Show();
            if (frm.IsOnlyOne)
            {
                FormToTab[frm] = kp;
                kp.Disposed += Kp_Disposed;
                kp.Tag = frm;
            }
        }

        private void Kp_Disposed(object sender, EventArgs e)
        {
            var frm = (sender as Control).Tag as BaseForm;
            (sender as Control).Tag.GetType().GetMethod("RemoveInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null,new object[]{ frm });
            FormToTab.Remove(frm);
        }



        private void krgbCustomerList_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Customer.frmCustomerList>();

        }
        private void krgbNewCustomer_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Customer.frmNewCustomer>(0);
        }

        private void frmMain2_Load(object sender, EventArgs e)
        {
            if (!isLogin)
                this.Close();
        }

        private void frmMain2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void krgbCustomerDetail_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Customer.frmCustomerDetailList>();
        }

        private void krgbNewCustomerDetail_Click(object sender, EventArgs e)
        {
            //OpenForm<NewForm.Customer.frmCustomerDetail>(0);
            var frm = new NewForm.Customer.frmCustomerDetail(0);
            frm.ShowDialog();
        }

        private void krgbNewSuplayer_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Supplier.frmNewSupplier>(0);
        }

        private void krgbSuplayerList_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Supplier.frmSupplierList>();
        }

        private void krgbSuplayerDetail_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Supplier.frmSupplierDetailList>();
        }

        private void krgbNewSupplierDetail_Click(object sender, EventArgs e)
        {
            var frm = new NewForm.Supplier.frmSupplierDetail();
            frm.ShowDialog();
        }

        private void krgbProductList_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Product.frmProductList>();
        }

        private void krgbNewProduct_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Product.frmNewProduct>(0);
        }

        private void krgbProductDetails_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Product.frmProductDetails>();
        }

        private void krgbNewProductDetail_Click(object sender, EventArgs e)
        {
            var frm = new NewForm.Product.frmNewProductDetail();
            frm.ShowDialog();
        }

        private void krgbOrderList_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Order.frmOrderList>();
        }

        private void kryptonRibbonGroupButton6_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Order.frmNewOrder>(0);
        }

        private void krgbNewRetailOrder_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Order.frmNewRetailOrder>(0);
        }

        private void krgbNewInternetOrder_Click(object sender, EventArgs e)
        {
            OpenForm<NewForm.Order.frmNewInternetOrder>(0);
        }

        private void krgbStokUnit_Click(object sender, EventArgs e)
        {
            new frmSetupUnit().ShowDialog();
        }

        private void krgbOrderStatus_Click(object sender, EventArgs e)
        {
            new frmSetupOrderStatus().ShowDialog();
        }

        private void krgbVariantGroup_Click(object sender, EventArgs e)
        {
            new frmSetupVariantGroup().ShowDialog();
        }

        private void krgbVariantGroupValue_Click(object sender, EventArgs e)
        {
            new frmSetupVariantGroupValue().ShowDialog();
        }
    }
}
