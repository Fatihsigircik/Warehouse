using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderListItem : ContentView
    {
        public delegate void ClickedHandler(VwOrder order);

        public event ClickedHandler Clicked;

        public static readonly BindableProperty OrderProperty = BindableProperty.Create("Order", typeof(VwOrder), typeof(OrderListItem), default(VwOrder), propertyChanged: OnOrderPropertyChanged);

        private static void OnOrderPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((OrderListItem)bindable).Order = (VwOrder)newvalue;
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

        public OrderListItem()
        {
            InitializeComponent();
        }
        

        private void SetControls(VwOrder order)
        {
            lblCustomer.Text = order.CompanyName;
            lblDate.Text = string.Format("{0:dd.MM.yyyy}", order.CreatedDate);
            lblOrderCode.Text = order.OrderCode;
            lblPrice.Text= $"{order.TotalPrice:F} {order.CurrencyCode:3}";
        }


        private void MenuItem_OnClicked(object sender, EventArgs e)
        {
            Clicked?.Invoke(this.Order);
        }
    }
}