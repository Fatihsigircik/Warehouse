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

namespace SimpleWarehouseXamarin.UserControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RetailOrderView : ContentView
    {

        internal VwCustomer CurrentCustomer => new VwCustomer()
        {
            CustomerName = txtName.Text,
            CustomerSurname = txtSurname.Text,
            Phone = txtPhone.Text,
            CustomerCode = "",
            CompanyName = $"{txtName.Text} {txtSurname.Text}"
        };

        internal string DocNumber => txtDocNumber.Text;
        internal string OrderNumber => txtOrderNumber.Text;
        internal DateTime OrderDate => dpOrderDate.Date;
        public RetailOrderView()
        {
            InitializeComponent();
            txtOrderNumber.Text = "PS.";
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

        private void RetailOrderView_OnBindingContextChanged(object sender, EventArgs e)
        {
            (this.BindingContext as Order).OrderDate = DateTime.Now;
        }
    }
}