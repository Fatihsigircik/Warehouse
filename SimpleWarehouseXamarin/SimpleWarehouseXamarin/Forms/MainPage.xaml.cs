using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseXamarin.Forms;
using SimpleWarehouseXamarin.Helper;
using Xamarin.Forms;

namespace SimpleWarehouseXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            txtUserName.Focus();
        }


        private async void ClickGestureRecognizer_OnClicked(object sender, EventArgs e)
        {
            if (!GeneralHelper.IsConnectInternet)
            {
                await DisplayAlert("Uyarı", "İnternet Bağlantınızı kontrol edin...", "Tamam");
                return;
            }

            if (!CheckControl())
            {
                await DisplayAlert("Uyarı", "Kullanıcı Adı ve Parola Alanlarını Doldurduğunuzdan Emin Olun...", "Tamam");
                return;
            }
            if (await CheckUserInfo(txtUserName.Text ?? "", txtPassword.Text ?? ""))
            {
                //await DisplayAlert("bilgi", "giriş yapıldı", "ok");
                var navigationPage = new MainMasterContentDetail(); //new NavigationPage(new ApplicationPage()) {BarBackgroundColor = Color.DarkBlue};
                 Application.Current.MainPage =new NavigationPage(navigationPage);
            }

        }



        private bool CheckControl()
        {
            return txtPassword.Text?.Length > 0 && txtUserName.Text?.Length > 0;
        }

        private void TxtUserName_OnCompleted(object sender, EventArgs e)
        {
            txtPassword.Focus();
            //Task.Run(async () =>
            //{
            //    await Task.Delay(3000);
            //    DependencyService.Get<IKeyboardHelper>().HideKeyboard();
            //    await Task.Delay(3000);
            //    DependencyService.Get<IKeyboardHelper>().ShowKeyboard();
                
            //});

        }

        private void TxtPassword_OnCompleted(object sender, EventArgs e)
        {

            ClickGestureRecognizer_OnClicked(sender, e);
        }

        private async Task<bool> CheckUserInfo(string userName, string password)
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Kontrol Ediliyor...");
                string token = await ApiHelper.GetToken(userName, password);
                SettingsHelper.Token = token;
                SettingsHelper.UserName = await ApiHelper.getUserByUserName(userName);

                UserDialogs.Instance.HideLoading();
                return true;
            }
            catch (Exception e)
            {
                
                UserDialogs.Instance.HideLoading();
                Acr.UserDialogs.UserDialogs.Instance.Alert(e.Message);
                //this.BindingContext = new ToastsViewModel(UserDialogs.Instance);
                //Toast.MakeText(this, $"{e.Message}", ToastLength.Short).Show();
                return false;
            }
            

        }
    }
}
