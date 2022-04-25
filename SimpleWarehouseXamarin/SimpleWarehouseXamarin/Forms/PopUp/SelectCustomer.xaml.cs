using System;
using System.Collections.Generic;
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
    public partial class SelectCustomer : ContentPage
    {
        private bool _dialogResult = false;

        public event EventHandler Closed;
        
        internal VwCustomer SelectedCustomer=>lvCustomers.SelectedItem as VwCustomer;

        internal bool DialogResult => _dialogResult;
        
        public SelectCustomer()
        {
            InitializeComponent();
            LoadCustomers();
        }

        private async void LoadCustomers()
        {
            lvCustomers.ItemsSource = await ApiHelper.GetCustomerList();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            _dialogResult = true;
            await Navigation.PopModalAsync(true);
            Closed?.Invoke(this,EventArgs.Empty);
        }
        
        private void Cell_OnTapped(object sender, EventArgs e)
        {
            (sender as Element).FindByName<RadioButton>("rb").IsChecked = true;
        }

        private void Rb_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(!e.Value)
                return;
            var rb = sender as RadioButton;
            var item = rb.BindingContext as VwCustomer;
            lvCustomers.SelectedItem = (lvCustomers.ItemsSource as List<VwCustomer>).FirstOrDefault(q => q==item);
            sbSearch.Unfocus();
        }

        private async void SbSearch_OnSearchButtonPressed(object sender, EventArgs e)
        {
            if (sbSearch.Text.Length < 3)
            {
                UserDialogs.Instance.Alert("En az 3 Harf Olmalı...", "Uyarı", "Tamam");
                return;

            }

            lvCustomers.ItemsSource = await ApiHelper.GetCustomerStartWith(sbSearch.Text);

        }

        private void SbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if(sbSearch.Text.Length==0)
                LoadCustomers();
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            _dialogResult = false;
            await Navigation.PopModalAsync(true);
            Closed?.Invoke(this, EventArgs.Empty);
        }
    }
}