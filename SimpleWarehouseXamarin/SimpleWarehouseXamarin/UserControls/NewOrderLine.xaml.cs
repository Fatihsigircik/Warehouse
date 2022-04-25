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

namespace SimpleWarehouseXamarin.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderLine : ContentView
    {

        public delegate void NewOrderDeletedHandler(NewOrderLine orderLine, VwOrderDetails orderDetails);

        public event NewOrderDeletedHandler Deleted;


        public delegate void NewOrderUpdateHandler(NewOrderLine orderLine, VwOrderDetails orderDetails);

        public event NewOrderUpdateHandler Updated;

        public static readonly BindableProperty OrderDetailProperty = BindableProperty.Create("OrderDetail", typeof(VwOrderDetails), typeof(NewOrderLine), default(VwOrder), propertyChanged: OnOrderPropertyChanged);

        private static void OnOrderPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((NewOrderLine)bindable).OrderDetail = (VwOrderDetails)newvalue;
        }

        public VwOrderDetails OrderDetail
        {
            get => (VwOrderDetails)GetValue(OrderDetailProperty);
            set
            {
                SetValue(OrderDetailProperty, value);
                SetControls(value);
            }
        }
        public NewOrderLine()
        {
            InitializeComponent();
            
        }

        private async void SetControls(VwOrderDetails order)
        {
            //lvLineDetail.ItemsSource = await ApiHelper.GetOrderDetailsView(order.OrderId);
            BindingContext = OrderDetail;
            //UserDialogs.Instance.Alert($"{OrderDetail.ProductName} ürünü eklendi");

            var retVal = await ApiHelper.GetProductImage(OrderDetail.ProductCode);
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

        private void RemoveItem(object sender, EventArgs e)
        {
           Deleted?.Invoke(this,OrderDetail);
        }

        private void UpdateItem(object sender, EventArgs e)
        {
            //UserDialogs.Instance.Alert("Güncelle");
            Updated?.Invoke(this, OrderDetail);
        }

        private bool isRun = false;
        private async void NewOrderLine_OnBindingContextChanged(object sender, EventArgs e)
        {
            if(isRun || BindingContext==null)
                return;
            isRun = true;
            var variantId = (BindingContext as VwOrderDetails)?.VariantId;
            if(variantId==null)
                return;
            var variant = await ApiHelper.GetVariant(variantId);
            lblVariantName.Text = variant?.ToString();
            isRun = false;

        }
    }
}