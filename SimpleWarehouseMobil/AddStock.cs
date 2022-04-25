using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using SimpleWarehouseMobil.Helpers;
using SimpleWarehouseMobil.Models;
using ZXing.Mobile;
using Environment = System.Environment;

namespace SimpleWarehouseMobil
{
    [Activity(Label = "Stok Girişi", Theme = "@style/AppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class AddStock : AppCompatActivity
    {
        private Warehouse _warehouse;
        private string _docNumber;
        private short _inOrOut = 0;

        LinearLayout lv;
        private Button btnBarcode;

        [Obsolete]
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            // set the menu layout on Main Activity  
            MenuInflater.Inflate(Resource.Menu.mainMenu, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.mnOk:
                    {

                        var alertDialog = new Android.App.AlertDialog.Builder(this);

                        alertDialog.SetTitle("Uyarı");
                        alertDialog.SetMessage("Eklenen Ürünler Onaylansın mı?");
                        alertDialog.SetCancelable(false);
                        alertDialog.SetPositiveButton("Evet", async delegate
                        {
                            var detailIdList = new List<int>();
                            for (var i = 0; i < lv.ChildCount; i++)
                            {
                                detailIdList.Add(Convert.ToInt32(lv.GetChildAt(i).Tag.ToString()));
                            }

                            await ApiHelper.ApproveDetails(detailIdList);
                            var childCount = lv.ChildCount;
                            for (var i = 0; i < childCount; i++)
                            {
                                lv.RemoveView(lv.GetChildAt(0));
                            }

                            await LoadAddedDetails();
                        });
                        alertDialog.SetNegativeButton("Hayır", delegate { });
                        alertDialog.Show();

                        return true;
                    }
                //case Resource.Id.mnCancel:
                //    {
                //        // add your code  
                //        return true;
                //    }

            }

            return base.OnOptionsItemSelected(item);
        }

        private async Task LoadAddedDetails()
        {
            var detailList = await ApiHelper.GetProductByDocumentNumber(_docNumber);
            await ViewHelper.GetDetail(detailList, this, _docNumber, _inOrOut, lv);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        { 
            
            base.OnCreate(savedInstanceState);
            _inOrOut = Intent.GetShortExtra("inOrOut", 1);
            Title = $"Ürün Stok {(_inOrOut == 1 ? "Girişi" : "Çıkışı")}";
            SetContentView(Resource.Layout.AddStok);

           

            btnBarcode = FindViewById<Button>(Resource.Id.btnBarcode);
            var btnStockCode = FindViewById<Button>(Resource.Id.btnStockCode);
            btnStockCode.Click += BtnStockCode_Click;
            btnBarcode.Click += BtnStockCode_Click;
            var txtBarcode = FindViewById<EditText>(Resource.Id.txtBarcode);
            txtBarcode.LongClick += txtBarcode_LongClick;
            txtBarcode.EditorAction += TxtBarcode_EditorAction;
            lv = FindViewById<LinearLayout>(Resource.Id.ItemLineer);

            LoadInfoView();

        }


        [Obsolete]
        private async void LoadInfoView()
        {
            View view = LayoutInflater.Inflate(Resource.Layout.GeneralInfo, null);
            ProgressDialog progres = ProgressDialog.Show(this, "Yükleniyor",
                "Bilgiler Yükleniyor...", true);
            var warehouseList = await GetWarehouse();
            progres.Dismiss();
            // var customDialog = new CustomAlert(this);
            var dialog = new CustomAlert(this).Create();

            dialog.SetView(view);
            dialog.SetCanceledOnTouchOutside(false);
            var spinner = view.FindViewById<Spinner>(Resource.Id.spnWarehouse);

            //List<Warehouse> list = new List<Warehouse>();
            //list.Add(new Warehouse(){WarehouseName = "Merkez"});
            //list.Add(new Warehouse() { WarehouseName = "Depo1" });
            //list.Add(new Warehouse() { WarehouseName = "Dış Depo" });
            ArrayAdapter<Warehouse> dataAdapter = new ArrayAdapter<Warehouse>(this,
                 Resource.Layout.SpinnerItem, warehouseList);  //simple_spinner_item
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleDropDownItem1Line);//simple_spinner_dropdown_item

            spinner.Adapter = dataAdapter;

            dialog.DismissEvent += Dialog_DismissEvent;

            Button button = view.FindViewById<Button>(Resource.Id.btnOk);
            button.Click += async delegate
            {
                var txtDocnumber = dialog.FindViewById<EditText>(Resource.Id.txtDocNumber);
                var spnWareHouse = dialog.FindViewById<Spinner>(Resource.Id.spnWarehouse);
                if (txtDocnumber.Text.Length == 0)
                {
                    txtDocnumber.Error = "Bu Alan Boş Geçilemez...";
                    return;
                }

                _docNumber = txtDocnumber.Text;
                _warehouse = warehouseList[spnWareHouse.SelectedItemPosition];
                isDismiss = false;
                var detailList = await ApiHelper.GetProductByDocumentNumber(_docNumber);//todo burası
                await ViewHelper.GetDetail(detailList, this, _docNumber, _inOrOut, lv);
                dialog.Dismiss();

            };

            dialog.Show();
        }

        private async Task<List<Warehouse>> GetWarehouse()
        {
            return await RestSharpManager.RestSharpGet<Warehouse>("api/warehouse/get", SettingsHelper.Token);
        }

        private bool isDismiss = true;
        private void Dialog_DismissEvent(object sender, EventArgs e)
        {
            if (isDismiss)
                Finish();
        }

        private void TxtBarcode_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            if (e.Event.Action == KeyEventActions.Down && e.Event.KeyCode == Keycode.Enter)
            {
                btnBarcode.PerformClick();
                e.Handled = true;
            }

        }

        private async void BtnStockCode_Click(object sender, EventArgs e)
        {
            var name = Application.Context.Resources.GetResourceName((sender as Button).Id).Split('/')[1].Replace("btn", "");
            var txtId = Resources.GetIdentifier($"txt{name}", "id", this.PackageName);
            var txtText = FindViewById<EditText>(txtId);
            if (txtText.Text.Length == 0)
                return;
            ;
            try
            {


                var product = name == "StockCode"
                    ? await Helpers.ApiHelper.GetProductByCode(txtText.Text)
                    : await Helpers.ApiHelper.GetProductByBarcode(txtText.Text);

                View view = LayoutInflater.Inflate(Resource.Layout.ProductQuantity, null);

                Android.App.AlertDialog builder = new Android.App.AlertDialog.Builder(this).Create();
                builder.SetView(view);
                builder.SetCanceledOnTouchOutside(false);
                var txtQuantity = view.FindViewById<EditText>(Resource.Id.txtQuantity);
                txtQuantity.Selected = true;
                Button button = view.FindViewById<Button>(Resource.Id.btnAdd);

                view.FindViewById<TextView>(Resource.Id.txtProductName).Text = product.ProductName;
                view.FindViewById<TextView>(Resource.Id.txtProductCode).Text = product.ProductCode;
                view.FindViewById<TextView>(Resource.Id.txtProductBarcode).Text = product.Barcode;

                button.Click += async delegate
                {
                    builder.Dismiss();
                    //var txtQuantity builder.FindViewById<EditText>(Resource.Id.txtQuantity);
                    var quantity = Convert.ToDecimal(txtQuantity.Text);
                    //Toast.MakeText(this, "Stok Eklendi...", ToastLength.Short).Show();
                    var productDetail = new ProductDetail()
                    {
                        CreatedDate = DateTime.Now,
                        ProductId = product.ProductId,
                        CreatedId = SettingsHelper.UserName.UserGroupId,
                        //CurrencyId = product.CurrencyId,
                        DocumentCode = _docNumber,
                        IsApproved = false,
                        Stock = quantity,
                        UnitId = product.UnitId,
                        VatPercent = product.VatPercent,
                        WarehouseId = _warehouse.WarehouseId,
                        InOrOut = _inOrOut,
                        //Price = product.Price
                    };
                    var detail = await ApiHelper.AddProductDetail(productDetail);
                    //var view =await ViewHelper.GetAddedProductLayout(product, this, quantity,_docNumber,_warehouse,_inOrOut);
                    await ViewHelper.GetDetail(new List<ProductDetail>() { detail }, this, _docNumber, _inOrOut, lv);

                    //lv.AddView(view, 0);
                    txtText.Text = "";

                    Toast.MakeText(ApplicationContext, "Ürün Girişi Yapıldı", ToastLength.Long).Show();
                };

                builder.Show();
                txtQuantity.Focusable = true;
                await Task.Delay(500);
                txtQuantity.RequestFocus();

                InputMethodManager inputManager = (InputMethodManager)GetSystemService(Context.InputMethodService);
                var currentFocus = this.CurrentFocus;
                if (currentFocus != null)
                {
                    inputManager.ShowSoftInput(txtQuantity, ShowFlags.Forced);
                }
            }
            catch (Exception exception)
            {
                //Toast.MakeText(ApplicationContext, $"Hata Oldu. Giriş Yapılamadı..{Environment.NewLine}{exception.Message}", ToastLength.Long).Show();



                Android.App.AlertDialog.Builder alert = new Android.App.AlertDialog.Builder(this);
                alert.SetTitle("Hata");
                alert.SetMessage($"{exception.Message}");
                //alert.SetPositiveButton("Tamam", (senderAlert, args) => {
                //    Toast.MakeText(this, "Yeni Ürün Girişi Yapabilirsiniz", ToastLength.Short).Show();
                //});

                Dialog dialog = alert.Create();
                dialog.Window.SetType(Android.Views.WindowManagerTypes.ApplicationPanel);
                dialog.Show();
                await Task.Delay(1500);
                dialog.Dismiss();
            }

        }

        private async void txtBarcode_LongClick(object sender, View.LongClickEventArgs e)
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            scanner.TopText = "Kolay Depo";
            scanner.BottomText = "En İyi Depo Programı";
            scanner.CancelButtonText = "İptal";
            scanner.AutoFocus();
            var isClose = false;
            _ = Task.Run(async () =>
            {
                var options = MobileBarcodeScanningOptions.Default;
                //options.DisableAutofocus = true;
                var barcode = await scanner.Scan(options);
                isClose = true;
                if (barcode == null)
                    return;
                //a.RunSynchronously(TaskScheduler.Current);
                var btnBarcode = FindViewById<EditText>(Resource.Id.txtBarcode);
                btnBarcode.Text = barcode.Text;
            });
            await Task.Delay(3 * 1000);

            await Task.Delay(55 * 1000);
            if (!isClose)
                scanner.Cancel();
        }


    }
}