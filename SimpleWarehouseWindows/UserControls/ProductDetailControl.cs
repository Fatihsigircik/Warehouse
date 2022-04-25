using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWarehouseWindows.FormHelper;
using SimpleWarehouseWindows.Helpers;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.UserControls
{
    public partial class ProductDetailControl : UserControl
    {
        private readonly ProductDetail _detail;

        internal Action OpenLoader;

        internal Action CloseLoader;
        //private Product _product;

        public ProductDetailControl(ProductDetail detail)
        {
            _detail = detail;
            InitializeComponent();
            LoadProduct();
        }

        private async void LoadProduct()
        {
            var _product = await ApiHelper.GetProductById(_detail.ProductId);
            await LoadDetail(_product);
            await LoadImage(_product);
        }

        private async Task LoadImage(Product _product)
        {
            var image = await ApiHelper.GetDefaultImageByProductCode(_product.ProductCode);
            if (image == null || image.Count == 0)
            {
                pictureBox1.Image = SimpleWarehouseWindows.Properties.Resources.open_box;
                return;
            }
            var imageByteArray = Convert.FromBase64String(image[0].Base64String);
            Image picture;
            using (MemoryStream stream = new MemoryStream(imageByteArray))
            {
                picture = Image.FromStream(stream);
            }

            pictureBox1.Image = picture;
        }

        private async Task LoadDetail(Product _product)
        {
            lblProductName.Text = _product.ProductName;
            lblProductCode.Text = _product.ProductCode;
            lblBarcode.Text = _product.Barcode;
            lblQuantity.Text = _detail.Stock.Value.ToString(new CultureInfo("tr-TR"));
            SetApproveImage();
        }

        private void SetApproveImage()
        {
            btnApprove.Image = _detail.IsApproved
                ? Properties.Resources.approval__1_
                : Properties.Resources.approval;
        }


        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Coral;
        }

        private void lblClose_MouseUp(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private async void lblClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinizden Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await ApiHelper.DeleteDetail(_detail.ProductDetailId);
                Parent.Controls.Remove(this);
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                OpenLoader?.Invoke();
                await ApiHelper.ChangeApprovingForDetail(_detail.ProductDetailId,
                    _detail.IsApproved != null && !_detail.IsApproved);
                _detail.IsApproved = _detail.IsApproved != null && !_detail.IsApproved;
                SetApproveImage();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Hata Oluştu..{Environment.NewLine}{exception.Message}", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                CloseLoader?.Invoke();
            }
        }

        internal void SetApprove(bool approve)
        {
            _detail.IsApproved = approve;
            SetApproveImage();
        }
    }
}
