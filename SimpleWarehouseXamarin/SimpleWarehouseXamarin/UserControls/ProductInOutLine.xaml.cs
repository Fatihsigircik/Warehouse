using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductInOutLine : ContentView
    {
        public delegate void NewOrderDeletedHandler(ProductInOutLine orderLine, VwProductDetails orderDetails);

        public event NewOrderDeletedHandler Deleted;


        public delegate void NewOrderUpdateHandler(ProductInOutLine orderLine, VwProductDetails orderDetails);

        public event NewOrderUpdateHandler Updated;

        public static readonly BindableProperty ProductDetailProperty = BindableProperty.Create("ProductDetail", typeof(VwProductDetails), typeof(OrderLineDetail), default(VwOrderDetails), propertyChanged: OnOrderDetailPropertyChanged);

        private static void OnOrderDetailPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((ProductInOutLine)bindable).ProductDetail = (VwProductDetails)newvalue;
        }

        public VwProductDetails ProductDetail
        {
            get => (VwProductDetails)GetValue(ProductDetailProperty);
            set
            {
                SetValue(ProductDetailProperty, value);
                SetControls(value);
            }
        }

        private async void SetControls(VwProductDetails value)
        {
            var retVal = await ApiHelper.GetProductImage(ProductDetail.ProductCode);
            if (retVal == null || retVal.Count == 0)
                return;

            imgProduct.Source = ImageSource.FromStream(() =>
            {
                var imgBase64 = retVal.FirstOrDefault()?["Base64String"].ToString();
                byte[] imageBytes = Convert.FromBase64String(imgBase64);
                var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                return ms;
            });

        }

        public ProductInOutLine()
        {
            InitializeComponent();
        }

        private void RemoveItem(object sender, EventArgs e)
        {
            Deleted?.Invoke(this, ProductDetail);
        }

        private void UpdateItem(object sender, EventArgs e)
        {
            //UserDialogs.Instance.Alert("Güncelle");
            Updated?.Invoke(this, ProductDetail);
        }
    }
}