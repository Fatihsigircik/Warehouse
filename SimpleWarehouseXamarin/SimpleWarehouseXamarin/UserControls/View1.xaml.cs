using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Rg.Plugins.Popup.Pages;
using SimpleWarehouseMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Application;

namespace SimpleWarehouseXamarin.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View1 : ContentView
    {
        public static readonly BindableProperty CodeProperty = BindableProperty.Create("Code", typeof(string), typeof(View1), default(string), propertyChanged: OnBarcodePropertyChanged);

        private static void OnBarcodePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((View1)bindable).Code = newvalue.ToString();
        }

        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(View1), default(string), propertyChanged: OnNamePropertyChanged);
        private static void OnNamePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            ((View1)bindable).Name = newvalue.ToString();
        }

        public string Code
        {
            get => (string)GetValue(CodeProperty);
            set
            {
                SetValue(CodeProperty, value);
                lblCode.Text = value;
            }
        }

        public string Name
        {
            get => (string)GetValue(NameProperty);
            set
            {
                SetValue(NameProperty, value);
                lblName.Text = value;
            }
        }

        public View1()
        {
            InitializeComponent();
            //lblBarcode.Text = product.Barcode;
            //lblCode.Text = "product.ProductCode;";
            lblName.Text = "product.ProductName";
        }

        private async void ImageButton_OnClicked(object sender, EventArgs e)
        {
            
             await (Application.Current.MainPage  as NavigationPage).PushAsync(new SimpleWarehouseXamarin.Forms.PopUp.ProductDetail(Code));
        }

        private void SwipeItem_OnInvoked(object sender, EventArgs e)
        {
            ImageButton_OnClicked(sender, e);
        }
    }
}