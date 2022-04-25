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
    class CustomAlert:AlertDialog.Builder
    {
        protected CustomAlert(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomAlert(Context context) : base(context)
        {
            var listener = new ViewKeyListener();
            this.SetOnKeyListener(listener);
        }

        public CustomAlert(Context context, int themeResId) : base(context, themeResId)
        {
        }
    }
}