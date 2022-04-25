using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SimpleWarehouseMobil.Models;

namespace SimpleWarehouseMobil.Helpers
{
    public class ViewHelper
    {
        //public static async Task<View> GetAddedProductLayout(Product product, Activity activity, decimal quantity, string docNumber, Warehouse warehouse, short inOrOut)
        //{
        //    View view = activity.LayoutInflater.Inflate(Resource.Layout.AddedProductLayout, null);
        //    var mainLayout = view.FindViewById<LinearLayout>(Resource.Id.mainLayout);
        //    var linearLayoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.FillParent,
        //        ViewGroup.LayoutParams.FillParent);
        //    linearLayoutParams.SetMargins(0, 10, 0, 0);
        //    mainLayout.LayoutParameters = linearLayoutParams;
        //    view.FindViewById<TextView>(Resource.Id.lblName).Text = product.ProductName;
        //    view.FindViewById<TextView>(Resource.Id.lblQuantity).Text = quantity.ToString(CultureInfo.InvariantCulture);
        //    view.FindViewById<TextView>(Resource.Id.lblStockCode).Text = product.ProductCode;
        //    view.FindViewById<TextView>(Resource.Id.lblBarcode).Text = product.Barcode;
        //    view.FindViewById<ImageView>(Resource.Id.imgClose).Click += delegate
        //    {
        //        var alertDialog = new AlertDialog.Builder(activity);

        //        alertDialog.SetTitle("Uyarı");
        //        alertDialog.SetMessage("Silmek İstediğinizden Emin misiniz?");
        //        alertDialog.SetCancelable(false);
        //        alertDialog.SetPositiveButton("Evet", delegate
        //        {
        //            var dc = docNumber;
        //            var productId = product.ProductId;
        //            ApiHelper.DeleteDetail(dc, productId);
        //            var parent = (view.Parent as LinearLayout);
        //            //parent.RemoveViewInLayout(view);
        //            parent.RemoveView(view);
        //        });
        //        alertDialog.SetNegativeButton("Hayır", delegate
        //        {

        //        });
        //        alertDialog.Show();

        //        //mainLayout.ClearChildFocus(view);
        //    };
        //    var productDetail = new ProductDetail()
        //    {
        //        CreatedDate = DateTime.Now,
        //        ProductId = product.ProductId,
        //        CreatedId = SettingsHelper.UserName.UserGroupId,
        //        CurrencyId = product.CurrencyId,
        //        DocumentCode = docNumber,
        //        IsApproved = false,
        //        Stock = quantity,
        //        UnitId = product.UnitId,
        //        VatPercent = product.VatPercent,
        //        WarehouseId = warehouse.WarehouseId,
        //        InOrOut = inOrOut,
        //        Price = product.Price
        //    };
        //    await ApiHelper.AddProductDetail(productDetail);
        //    return view;
        //}




        public static async Task GetDetail(List<ProductDetail> details, Activity activity, string docNumber, short inOrOut, LinearLayout lv)
        {
            foreach (var detail in details)
            {
                var product = await ApiHelper.GetProductById(detail.ProductId);

                View view = activity.LayoutInflater.Inflate(Resource.Layout.AddedProductLayout, null);
                view.Tag = detail.ProductDetailId;
                var mainLayout = view.FindViewById<LinearLayout>(Resource.Id.mainLayout);
                var linearLayoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.FillParent,
                    ViewGroup.LayoutParams.FillParent);
                linearLayoutParams.SetMargins(0, 10, 0, 0);
                mainLayout.LayoutParameters = linearLayoutParams;
                view.Id = new Random().Next(1000, 100_000_000);
                view.FindViewById<TextView>(Resource.Id.lblName).Text = product.ProductName;
                view.FindViewById<TextView>(Resource.Id.lblQuantity).Text =
                    detail.Stock.Value.ToString(CultureInfo.InvariantCulture);
                view.FindViewById<TextView>(Resource.Id.lblStockCode).Text = product.ProductCode;
                view.FindViewById<TextView>(Resource.Id.lblBarcode).Text = product.Barcode;
                if (!(detail.IsApproved.HasValue && detail.IsApproved.Value))

                {
                    view.SetBackgroundColor( Color.LightYellow);
                    view.FindViewById<ImageView>(Resource.Id.imgClose).Click += delegate
                    {
                        var alertDialog = new AlertDialog.Builder(activity);

                        alertDialog.SetTitle("Uyarı");
                        alertDialog.SetMessage("Silmek İstediğinizden Emin misiniz?");
                        alertDialog.SetCancelable(false);
                        alertDialog.SetPositiveButton("Evet", async delegate
                        {
                            //var dc = docNumber;
                            //var productId = product.ProductId;
                            //ApiHelper.DeleteDetailByDocNumberAndProductId(dc, productId);
                            await ApiHelper.DeleteDetail(detail.ProductDetailId);
                            var parent = (view.Parent as LinearLayout);
                            parent.RemoveView(view);
                        });
                        alertDialog.SetNegativeButton("Hayır", delegate { });
                        alertDialog.Show();

                        //mainLayout.ClearChildFocus(view);
                    };
                }
                else
                {
                    view.SetBackgroundColor(Color.LightGreen);
                    var mainRelativ = mainLayout.FindViewById<RelativeLayout>(Resource.Id.mainRelative);
                    mainRelativ.RemoveView(view.FindViewById<ImageView>(Resource.Id.imgClose));
                }
                lv.AddView(view);
            }
        }
    }
}