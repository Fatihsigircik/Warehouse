using System;
using System.Collections.Generic;
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
    public partial class OrderItemDetail : ContentView
    {
        public static readonly BindableProperty OrderProperty = BindableProperty.Create("Order", typeof(VwOrder), typeof(OrderItemDetail), default(VwOrder), propertyChanged: OnOrderPropertyChanged);

        private static void OnOrderPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((OrderItemDetail)bindable).Order = (VwOrder)newvalue;
        }

        public VwOrder Order
        {
            get => (VwOrder)GetValue(OrderProperty);
            set
            {
                SetValue(OrderProperty, value);
                SetControls(value);
            }
        }
        public OrderItemDetail()
        {
            InitializeComponent();
        }
        private async void SetControls(VwOrder order)
        {
            lvLineDetail.ItemsSource = await ApiHelper.GetOrderDetailsView(order.OrderId);
            
        }
    }
}