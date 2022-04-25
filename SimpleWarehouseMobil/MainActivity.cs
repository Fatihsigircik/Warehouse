using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SimpleWarehouseMobil.Helpers;

namespace SimpleWarehouseMobil
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LineerTest);


            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += BtnLogin_Click;

            //var imageView = FindViewById<ImageView>(Resource.Id.imageView2);
            //int id = (int)typeof(Resource.Drawable).GetField("login").GetValue(null);
            //imageView.SetImageResource(id);


            //    //Inflate layout
            //    View view = LayoutInflater.Inflate(Resource.Layout.pp, null);
            //Android.App.AlertDialog builder = new Android.App.AlertDialog.Builder(this).Create();
            //    builder.SetView(view);
            //    builder.SetCanceledOnTouchOutside(false);
            //    //Button button = view.FindViewById<Button>(Resource.Id);
            //    //button.Click += delegate {
            //    //    builder.Dismiss();
            //    //    Toast.MakeText(this, "Alert dialog dismissed!", ToastLength.Short).Show();
            //    //};
            //    builder.Show();

        }

        [Obsolete]
        private async void BtnLogin_Click(object sender, System.EventArgs e)
        {
            ProgressDialog dialog = ProgressDialog.Show(this, "Giriş",
                "Bilgiler Kontrol Ediliyor", true);
            //this.Title = "Deneme";
            var txtUserName = FindViewById<EditText>(Resource.Id.txtUsername);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(txtPassword.WindowToken, 0);
            //return base.OnTouchEvent(e);

            if (await CheckUserInfo(txtUserName.Text, txtPassword.Text))
            {
                var NxtAct = new Intent(this, typeof(GrandActivity));
                StartActivity(NxtAct);
            }
            else
            {
                _ = Task.Run(async () =>
                  {
                      try
                      {

                          this.RunOnUiThread(async () =>
                          {
                            //Inflate layout
                            View view = LayoutInflater.Inflate(Resource.Layout.HataMessage, null);
                              Android.App.AlertDialog builder = new Android.App.AlertDialog.Builder(this).Create();
                              builder.SetView(view);
                              builder.SetCanceledOnTouchOutside(false);
                            //Button button = view.FindViewById<Button>(Resource.Id);
                            //button.Click += delegate {
                            //    builder.Dismiss();
                            //    Toast.MakeText(this, "Alert dialog dismissed!", ToastLength.Short).Show();
                            //};
                            builder.Show();
                              await Task.Delay(2 * 1000);
                              builder.Hide();
                          });

                      }
                      catch (Exception exception)
                      {
                          Console.WriteLine(exception);
                          throw;
                      }

                  });
            }
            dialog.Dismiss();
        }

        private async Task<bool> CheckUserInfo(string userName, string password)
        {
            try
            {
                string token = await ApiHelper.GetToken(userName, password);
                SettingsHelper.Token = token;
                SettingsHelper.UserName = await ApiHelper.getUserByUserName(userName);


                return true;
            }
            catch (Exception e)
            {
                Toast.MakeText(this, $"{e.Message}", ToastLength.Short).Show();
                return false;
            }


        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}