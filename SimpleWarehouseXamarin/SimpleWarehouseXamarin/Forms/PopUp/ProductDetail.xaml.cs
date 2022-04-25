using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.Forms.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetail : ContentPage
    {
        private readonly string _productCode;

        public ProductDetail( string productCode)
        {
            _productCode = productCode;
            InitializeComponent();
            LoadProductDetail();
        }

        private async Task LoadProductDetail()
        {
            UserDialogs.Instance.ShowLoading("Yükleniyor");
            var product = await ApiHelper.GetProductByCode(_productCode);
            if (product == null)
            {
                await UserDialogs.Instance.AlertAsync("Ürün Bulunamadı...", "Uyarı", "Tamam");
                return;
            }
            lblBarcode.Text = ": " +product.Barcode;
            lblCode.Text = ": " + product.ProductCode;
            lblName.Text = ": " + product.ProductName;
            LoadProductImage(product);
            LoadProductPrice(product.ProductId);
            LoadProductStock(product.ProductId);
            UserDialogs.Instance.HideLoading();
        }

        private async void LoadProductStock(int productId)
        {
            var retVal = await ApiHelper.GetProductStockInWarehouse(productId);
            lvStock.ItemsSource = retVal;
        }

        private async void LoadProductPrice(int productId)
        {
            var retVal = await ApiHelper.GetProductPriceList(productId);
            lvPrice.ItemsSource = retVal;
        }

        private async void LoadProductImage(Product product)
        {
            var retVal=await ApiHelper.GetProductImage(product.ProductCode);
            if(retVal==null || retVal.Count==0)
                return;

            imgProduct.Source = ImageSource.FromStream(() =>
            {
                var imgBase64 = retVal.FirstOrDefault()?["Base64String"].ToString();
                byte[] imageBytes = Convert.FromBase64String(imgBase64);
                var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                return ms;
            });


        }

       

    }
}