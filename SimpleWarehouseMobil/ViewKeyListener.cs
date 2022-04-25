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
    internal class ViewKeyListener : Java.Lang.Object, IDialogInterfaceOnKeyListener
    {

        public bool OnKey(IDialogInterface dialog, Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back)
                dialog.Dismiss();
            return false;
        }
    }
}