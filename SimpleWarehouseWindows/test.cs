using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;

namespace SimpleWarehouseWindows
{
    public partial class test : KryptonForm
    {
        public test()
        {
            InitializeComponent();
            new frmLogin().ShowDialog();
        }

        private void test_Load(object sender, EventArgs e)
        {

        }

        private void krgbAddCustomer_Click(object sender, EventArgs e)
        {
            //var newCustomer = new frmNewCustomer();
            //var kp = new KryptonPage(newCustomer.Text);
            //newCustomer.TopLevel = false;
            //newCustomer.FormBorderStyle = FormBorderStyle.None;
            //kp.Controls.Add(newCustomer);
            //knMain.Pages.Add(kp);
            //newCustomer.Show();
        }

        private void krgbCustomerList_Click(object sender, EventArgs e)
        {
            //var newCustomer = new frmCustomer();
            //var kp = new KryptonPage(newCustomer.Text);
            //newCustomer.TopLevel = false;
            //newCustomer.FormBorderStyle = FormBorderStyle.None;
            //kp.Controls.Add(newCustomer);
            //knMain.Pages.Add(kp);
            //newCustomer.Show();

        }
    }
}
