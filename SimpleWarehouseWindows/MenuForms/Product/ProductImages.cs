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

namespace SimpleWarehouseWindows.MenuForms.Product
{
    public partial class ProductImages : BaseForm
    {
        private readonly Models.Product _product;
        private List<WebImage> _images;

        public ProductImages(Models.Product product)
        {
            _product = product;
            InitializeComponent();
            LoadProductInfo();
            LoadImages();
        }

        private async Task LoadImages()
        {
            try
            {
                OpenLoader();
                lvImages.Items.Clear();
                _images = await ApiHelper.GetProductImage(_product.ProductCode);
                if (_images == null || _images.Count == 0)
                {
                    goto LABEL;
                }
                var imageList = new ImageList { ImageSize = new Size(100, 100) };
                foreach (var image in _images)
                {
                    imageList.Images.Add(GetImage(image));
                }

                lvImages.LargeImageList = imageList;
                for (var i = 0; i < imageList.Images.Count; i++)
                {
                    lvImages.Items.Add(i.ToString(), "", i);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        LABEL:
            CloseLoader();
        }

        private Image GetImage(WebImage image)
        {
            var tmp = string.IsNullOrEmpty(image.Base64String)?GetEmptyImage(image): Helper.Base64ToImage(image.Base64String);
            var rate = 0d;
            if (tmp.Height > tmp.Width)
            {
                rate = 100d / tmp.Height;
            }
            else
            {
                rate = 100d / tmp.Width;
            }

            var resizeImage = Helper.ResizeImage(tmp, (int)(tmp.Width * rate), (int)(tmp.Height * rate));
            var bitmap = new Bitmap(100, 100);
            var graphic = Graphics.FromImage(bitmap);
            graphic.DrawImage(resizeImage, 0, 0);
            if (image.IsDefault)
            {
                
                graphic.FillEllipse(new SolidBrush(Color.Red),0,0,12,12 );
                graphic.FillEllipse(new SolidBrush(Color.White), 3, 3, 6, 6);
                //graphic.DrawImage(check, 0, 0,
                //    new RectangleF(0, 0, 10, 10), GraphicsUnit.Pixel);
            }
            return bitmap;
        }

        private Image GetEmptyImage(WebImage image)
        {
           var bitmap= new Bitmap(100, 100);

            var graphics=Graphics.FromImage(bitmap);

            graphics.DrawString($"{image.ProductImageId} ID Numaralı",Font,new SolidBrush(Color.Red),10,10);
            graphics.DrawString("Görsel", Font, new SolidBrush(Color.Red), 10, 30);
            graphics.DrawString("Bulunamadı..", Font, new SolidBrush(Color.Red), 10, 50);
            return bitmap;
        }

        private void LoadProductInfo()
        {
            lblName.Text = _product.ProductName;
            lblBarcode.Text = _product.Barcode;
            lblCode.Text = _product.ProductCode;
        }

        private void lvImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvImages.SelectedIndices.Count == 0)
                return;
            var index = lvImages.SelectedIndices[0];
            pictureBox1.Image =string.IsNullOrEmpty(_images[index].Base64String)?GetEmptyImage(_images[index]): Helper.Base64ToImage(_images[index].Base64String);
        }

        private void btnNewImage_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            { Title = @"Fotoğrafları Seçin", Filter = @"Image File|*.jpg;*.jpeg;*.png", Multiselect = true };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OpenLoader();
                var selectedFiles = dialog.FileNames;
                pbNewImage.Maximum = selectedFiles.Length;
                pbNewImage.Value = 0;

                foreach (var file in selectedFiles)
                {
                    UploadImage(file);
                }
            }
        }

        async void PbCounter()
        {
            lock (pbNewImage)
            {
                pbNewImage.Value++;
            }

            if (pbNewImage.Value == pbNewImage.Maximum)
            {
                CloseLoader();
                await LoadImages();
                MessageBox.Show("Gönderimler Tamamlandı..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private async void UploadImage(string filePath)
        {
            try
            {
                var base64 = Helper.FileToBase64(filePath);
                WebImage webImage = new WebImage()
                {
                    ProductCode = _product.ProductCode,
                    Base64String = base64
                };
                await ApiHelper.UploadImage(webImage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            PbCounter();
        }

        private async void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if (lvImages.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bir Görsel Seçin...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenLoader();
                var index = lvImages.SelectedIndices[0];
                var deletingImage = _images[index];
                await ApiHelper.DeleteImage(deletingImage);
                CloseLoader();
                await LoadImages();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }
            finally
            {
                CloseLoader();
            }

        }

        private async void btnSetDefaultImage_Click(object sender, EventArgs e)
        {
            if (lvImages.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Bir Görsel Seçin...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenLoader();
                var index = lvImages.SelectedIndices[0];
                var image = _images[index];
                await ApiHelper.SetDefaultImage(image);
                CloseLoader();
                await LoadImages();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }
            finally
            {
                CloseLoader();
            }
        }
    }
}
