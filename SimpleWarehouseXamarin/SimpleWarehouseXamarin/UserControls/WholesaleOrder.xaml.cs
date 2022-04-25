using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using SimpleWarehouseXamarin.Forms;
using SimpleWarehouseXamarin.Forms.PopUp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WholesaleOrder : ContentView
    {
        private VwCustomer _currentCustomer;
        internal VwCustomer CurrentCustomer => _currentCustomer;

        internal string DocNumber => txtDocNumber.Text;
        internal string OrderNumber => txtOrderNumber.Text;
        internal DateTime OrderDate => dpOrderDate.Date;
        public WholesaleOrder()
        {
            InitializeComponent();
            txtOrderNumber.Text = "TS.";
            BtnPrefix_OnClicked(null, null);
        }


        private async void BtnPrefix_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var currentCode = await ApiHelper.GetCurrentOrderCode(txtOrderNumber.Text);
                if (string.IsNullOrEmpty(currentCode))
                {
                    throw new Exception($"{txtOrderNumber.Text} Prefixi İle Başlayan Kayıt Bulunamadı...");
                }
                txtOrderNumber.Text = currentCode;
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.Alert(exception.Message, "Hata", "Tamam");
            }
        }

        private void WholesaleOrder_OnBindingContextChanged(object sender, EventArgs e)
        {
            (this.BindingContext as Order).OrderDate = DateTime.Now;
        }

        private async void BtnCustomer_OnClicked(object sender, EventArgs e)
        {
            var frm = new SelectCustomer();
            frm.Closed += Frm_Closed;
            await Navigation.PushModalAsync(frm,true);
            
        }

        private void Frm_Closed(object sender, EventArgs e)
        {
            var frm = sender as SelectCustomer;
            if (frm.DialogResult && frm.SelectedCustomer != null)
            {
                LoadCustomerInfo(frm.SelectedCustomer);

            }
        }

        private void LoadCustomerInfo(VwCustomer selectedCustomer)
        {
            _currentCustomer = selectedCustomer;
            slDelivery.BindingContext = slInfo.BindingContext = slInvoice.BindingContext = _currentCustomer;
        }

    }
}