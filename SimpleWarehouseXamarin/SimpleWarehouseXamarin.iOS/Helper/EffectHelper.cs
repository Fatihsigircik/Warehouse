using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWarehouseXamarin.Helper;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace SimpleWarehouseXamarin.iOS.Helper
{
    class EffectHelper
    {
    }
    [Assembly: ResolutionGroupName("ControlSamples.Effects")]
    [Assembly: ExportEffect(typeof(NoKeyboardEffect_iOS), nameof(NoKeyboardEffect))]
    public class NoKeyboardEffect_iOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                if (Control is UITextField textField)
                {
                    // dummy view to override the soft keyboard
                    textField.InputView = new UIView();
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