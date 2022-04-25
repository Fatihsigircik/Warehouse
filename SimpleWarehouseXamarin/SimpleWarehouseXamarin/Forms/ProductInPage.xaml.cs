using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using SimpleWarehouseXamarin.Forms.PopUp;
using SimpleWarehouseXamarin.UserControls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductInPage : ContentPage
    {
        private short _inorout;
        public short InOrOut
        {
            get => _inorout;
            set => _inorout = value;
        }
        private ObservableCollection<VwProductDetails> _productDetailList = new ObservableCollection<VwProductDetails>();

        public ProductInPage()
        {
            InitializeComponent();
            lvInorOut.ItemsSource = _productDetailList;
            LoadWarehouse();
        }

        private async void LoadWarehouse()
        {
            pckWarehouse.ItemsSource = await ApiHelper.GetWarehouseList();
            pckWarehouse.SelectedIndex = 0;

        }

        private async void ImageButton_OnClicked(object sender, EventArgs e)
        {
            if (pckWarehouse.SelectedIndex == -1)
            {
                UserDialogs.Instance.Alert("Depo Seçiniz", "Uyarı", "Tamam");
                return;
            }

            if ((txtDocNumber.Text ?? "").Length == 0)
            {
                UserDialogs.Instance.Alert("Doküman Numarası Giriniz", "Uyarı", "Tamam");
                return;
            }

            var frm = new SelectInOrOutProduct(txtDocNumber.Text, pckWarehouse.SelectedItem as Warehouse, _inorout);
            frm.Closed += Frm_Closed;
            await Navigation.PushModalAsync(frm);
        }

        private void Frm_Closed(object sender, EventArgs e)
        {
            var frm = sender as SelectInOrOutProduct;
            if (frm.DialogResult)
            {
                _productDetailList.Add(frm.SelectedProductDetail);
            }
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            UserDialogs.Instance.ShowLoading("Kayıt İşlemi Sürüyor..");
            var err = "";
            foreach (var productDetails in _productDetailList)
            {
                
                try
                {
                    await ApiHelper.AddProductDetail(productDetails);
                }
                catch (Exception exception)
                {
                    err += productDetails.ProductCode+ "Kodlu Üründe =>"+ exception.Message + Environment.NewLine;
                }

            }

            UserDialogs.Instance.HideLoading();
            if (err != "")
            {
                UserDialogs.Instance.Alert("Bazı Kayıtlarda Hata Alındı..", "Hata", "Tamam");
            }
        }

        private void NewOrderLine_OnDeleted(ProductInOutLine orderline, VwProductDetails productDetails)
        {
            _productDetailList.Remove(productDetails);
        }

        private VwProductDetails updateDetails=null;
        private async void NewOrderLine_OnUpdated(ProductInOutLine orderline, VwProductDetails productDetails)
        {
            var frmUpdate = new SelectInOrOutProduct(txtDocNumber.Text, pckWarehouse.SelectedItem as Warehouse, _inorout, productDetails);
            frmUpdate.Closed += FrmUpdate_Closed;
            await Navigation.PushModalAsync(frmUpdate);
            updateDetails = productDetails;
        }

        private void FrmUpdate_Closed(object sender, EventArgs e)
        {
            if ((sender as SelectInOrOutProduct).DialogResult && updateDetails!=null)
            {
                var index = Array.IndexOf(_productDetailList.ToArray(), updateDetails);
                _productDetailList[index]= (sender as SelectInOrOutProduct).SelectedProductDetail;
            }
        }
    }
}