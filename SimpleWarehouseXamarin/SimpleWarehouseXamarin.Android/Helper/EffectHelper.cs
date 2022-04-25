using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SimpleWarehouseXamarin.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SimpleWarehouseXamarin.Droid.Helper
{
    class EffectHelper
    {
    }
    [Assembly: ResolutionGroupName("ControlSamples.Effects")]
    [Assembly: ExportEffect(typeof(NoKeyboardEffect_Droid), nameof(NoKeyboardEffect))]
    public class NoKeyboardEffect_Droid : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control is EditText editText)
                {
                    // cursor shown, but keyboard will not be displayed
                    if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                    {
                        editText.ShowSoftInputOnFocus = false;
                    }
                    else
                    {
                        editText.SetTextIsSelectable(true);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{nameof(NoKeyboardEffect)} failed to attached: {ex.Message}");
            }
        }

        protected override void OnDetached()
        {
        }
    }
}