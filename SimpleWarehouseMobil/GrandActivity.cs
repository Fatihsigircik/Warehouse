using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SimpleWarehouseMobil
{
    [Activity(Label = "GrandActivity")]
    public class GrandActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            var btnAddStock = FindViewById<Button>(Resource.Id.btnAddStock);
            btnAddStock.Click += BtnAddStock_Click;
            var btnRemoveStock = FindViewById<Button>(Resource.Id.btnRemoveStock);
            btnRemoveStock.Click += BtnRemoveStock_Click;
        }

        private void BtnAddStock_Click(object sender, EventArgs e)
        {
            var NxtAct = new Intent(this, typeof(AddStock));
            short s = 1;
            NxtAct.PutExtra("inOrOut", s);
            StartActivity(NxtAct);
        }     
        private void BtnRemoveStock_Click(object sender, EventArgs e)
        {
            var NxtAct = new Intent(this, typeof(AddStock));
            short s = -1;
            NxtAct.PutExtra("inOrOut", s);
            StartActivity(NxtAct);
        }
    }
}