using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationPage : ContentPage
    {
        private int _currentPage = 0;
        private bool _lastPage;
        private bool _isSearch;

        private short _inorout;
        public short InOrOut
        {
            get => _inorout;
            set => _inorout = value;
        }

        public ApplicationPage()
        {
            InitializeComponent();
            LoadProduct();

        }

        private async Task<bool> LoadProduct()
        {
            UserDialogs.Instance.ShowLoading("Ürünler Getiriliyor");
            var products = await ApiHelper.GetProductListBySkipAndTake(_currentPage * 100, 101);
            lvProducts.ItemsSource = products.Take(100);
            UserDialogs.Instance.HideLoading();
            _isSearch = false;
            return products.Count == 101;

        }

        private async void LoadSearchProduct()
        {
            UserDialogs.Instance.ShowLoading("Ürünler Getiriliyor");
            var products = await ApiHelper.GetProductWithLike("ProductCode", sbProductCode.Text);
            lvProducts.ItemsSource = products;
            UserDialogs.Instance.HideLoading();
            pathNext.Fill = Brush.Gray;
            pathPrevious.Fill = Brush.Gray;
            _isSearch = true;
        }


        private async void Next(object sender, EventArgs e)
        {
            if (_lastPage || _isSearch)
                return;

            _currentPage++;
            var response = await LoadProduct();
            if (!response)
            {
                pathNext.Fill = Brush.Gray;
                _lastPage = true;
            }
            pathPrevious.Fill = new SolidColorBrush(Color.FromHex("00c2ff"));

        }

        private async void Previous(object sender, EventArgs e)
        {
            if (_currentPage == 0 || _isSearch)
            {
                return;
            }

            _currentPage--;
            var response = await LoadProduct();
            if (_currentPage == 0)
                pathPrevious.Fill = Brush.Gray;
            if (response)
            {
                pathNext.Fill = new SolidColorBrush(Color.FromHex("00c2ff"));
                _lastPage = false;
            }
        }

        private void SearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            if (sbProductCode.Text.Length < 3)
            {
                UserDialogs.Instance.Toast("En Az 3 Karakter Girin...", TimeSpan.FromSeconds(3));
                return;
            }
            LoadSearchProduct();

        }

        private async void SbProductCode_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sbProductCode.Text.Length > 0)
                return;
            _isSearch = false;
            _currentPage = 0;
            _lastPage = !(await LoadProduct());
            if (!_lastPage)
            {
                pathNext.Fill = new SolidColorBrush(Color.FromHex("00c2ff"));
            }
            sbProductCode.Unfocus();
            lvProducts.Focus();
        }
    }


    class ProductsList : INotifyPropertyChanged
    {

        public event EventHandler LoadComplated;
        public event EventHandler LoadCycleComplated;

        public ObservableCollection<VwProduct> Products { get; set; }
        public ObservableCollection<VwProduct> ProductsTemps { get; set; }

        public ProductsList()
        {

        }

        public async Task LoadProducts()
        {
            Products = new ObservableCollection<VwProduct>();
            var productsList = await ApiHelper.GetProductList();
            productsList.ForEach(q => Products.Add(q));
            LoadComplated?.Invoke(this, EventArgs.Empty);
        }

        public async Task LoadFirstTen()
        {
            Products = new ObservableCollection<VwProduct>();
            var productsList = await ApiHelper.GetProductListBySkipAndTake(0, 10);
            productsList.ForEach(q => Products.Add(q));
        }

        public async void LoadOtherProducts()
        {
            ProductsTemps = new ObservableCollection<VwProduct>();
            await Device.InvokeOnMainThreadAsync(async () =>
            {
                while (true)
                {

                    ProductsTemps.Clear();
                    var lst = await ApiHelper.GetProductListBySkipAndTake(Products.Count, 100);
                    if (lst.Count == 0)
                    {
                        break;
                    }

                    lst.ForEach(q => ProductsTemps.Add(q));
                    LoadCycleComplated?.Invoke(this, EventArgs.Empty);
                }
                LoadComplated?.Invoke(this, EventArgs.Empty);
            });


        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}