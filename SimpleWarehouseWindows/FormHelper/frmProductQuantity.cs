using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.FormHelper
{
    public partial class frmProductQuantity : Form
    {
        private readonly Product _product;

        public frmProductQuantity(Product product)
        {
            _product = product;
            InitializeComponent();
            LoadImage();
            LoadInfo();
        }

        public decimal? Quantity => Convert.ToInt32(txtQuantity.Text);

        private void LoadInfo()
        {
            lblBarcode.Text = _product.Barcode;
            lblProductCode.Text = _product.ProductCode;
            lblProductName.Text = _product.ProductName;
        }

        private async void LoadImage()
        {
           var image= await ApiHelper.GetDefaultImageByProductCode(_product.ProductCode);
           if( image==null || image.Count==0)
           {
               pictureBox1.Image = SimpleWarehouseWindows.Properties.Resources.open_box;
               return;
           }
           var imageByteArray= Convert.FromBase64String(image[0].Base64String);
           Image picture;
           using (MemoryStream stream=new MemoryStream(imageByteArray))
           {
               picture=Image.FromStream(stream);
           }

           pictureBox1.Image = picture;
        }

        private readonly char[] _numericChars = new[]
        {
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', (char) Keys.Back, (char) Keys.Delete, Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToCharArray()[0],
            (char) Keys.Right, (char) Keys.Left
        };
       
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Length == 0 || Convert.ToInt32(txtQuantity.Text) < 1)
            {
                MessageBox.Show("Lütfen Adet Giriniz...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!_numericChars.Contains(e.KeyChar))
                e.Handled = true;
        }
    }
}
