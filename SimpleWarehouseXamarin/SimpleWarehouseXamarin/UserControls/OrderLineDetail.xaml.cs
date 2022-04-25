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
    public partial class OrderLineDetail : ContentView
    {
        public static readonly BindableProperty OrderDetailProperty = BindableProperty.Create("OrderDetail", typeof(VwOrderDetails), typeof(OrderLineDetail), default(VwOrderDetails), propertyChanged: OnOrderDetailPropertyChanged);

        private static void OnOrderDetailPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((OrderLineDetail)bindable).OrderDetail = (VwOrderDetails)newvalue;
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

        private async void SetControls(VwOrderDetails value)
        {
            //lbl1.Text = value.ProductCode;
            //lbl2.Text = value.ProductName;

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

        public OrderLineDetail()
        {
            InitializeComponent();
        }
    }
}