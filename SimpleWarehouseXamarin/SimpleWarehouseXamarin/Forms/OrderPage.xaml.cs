using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using SimpleWarehouseXamarin.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        private short _inorout;
        public short InOrOut
        {
            get => _inorout;
            set => _inorout = value;
        }
        public OrderPage()
        {
            InitializeComponent();
            LoadOrders();
        }

        private async void LoadOrders()
        {
            var orders =await ApiHelper.GetOrdersLast100();
            lvOrders.ItemsSource = orders;
        }

        private async void OrderPage_OnAppearing(object sender, EventArgs e)
        {
           
        }

 

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            popupOverlay.IsVisible = false;
        }

        private void OrderListItem_OnClicked(VwOrder order)
        {
            //orderItemDetail.Order = order;
            orderItemDetail.BindingContext = order;
            popupOverlay.IsVisible = true;
        }

        private async void OrderItemDetail_OnBindingContextChanged(object sender, EventArgs e)
        {
            orderItemDetail.Order= orderItemDetail.BindingContext as VwOrder;  //await ApiHelper.GetOrderDetailsView(orderItemDetail.Order.OrderId);
        }

        private void ImageButton_OnClicked(object sender, EventArgs e)
        {
       


            var config = new ActionSheetConfig();
            
            config.Title = "Sipariş Türünü Seçiniz";
            config.Add("Toptan", () => OpenNewOrder(1),"c1.png");
            config.Add("Perakende", () => OpenNewOrder(2),"retail.png");
            config.Cancel = new ActionSheetOption("İptal");
            UserDialogs.Instance.ActionSheet(config);

        }

        async void OpenNewOrder(int orderType)
        {
            var page = new NewOrderPage(orderType);
            await(Application.Current.MainPage as NavigationPage).PushAsync(page);
        }

        private void PopupOverlay_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            if (e.PropertyName == "IsVisible")
            {
                NavigationPage.SetHasBackButton(this, !popupOverlay.IsVisible);
            }
        }

        private void AbsoluteLayoutTapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            sbSearch.Unfocus();
        }

        private async void SbSearch_OnSearchButtonPressed(object sender, EventArgs e)
        {
            if (sbSearch.Text.Length < 4)
            {
                UserDialogs.Instance.Alert("En Az 4 Karakter Giriniz...", "Uyarı", "Tamam");
                return;
            }
            var orders = await ApiHelper.GetOrderCodeStartWith(sbSearch.Text);
            lvOrders.ItemsSource = orders;
        }

        private void SbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if(sbSearch.Text.Length==0)
                LoadOrders();
        }
    }
}