using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views.InputMethods;
using SimpleWarehouseXamarin.Droid.Helper;
using SimpleWarehouseXamarin.Helper;
using Xamarin.Forms;

[assembly: Dependency(typeof(KeyboardHelper))]
namespace SimpleWarehouseXamarin.Droid.Helper
{
    [Preserve(AllMembers = true)]
    public class KeyboardHelper: IKeyboardHelper
    {
        static Context _context;
 
        public KeyboardHelper()
        {
 
        }
 
        public static void Init(Context context)
        {
            _context = context;
        }
 
        public void HideKeyboard()
        {
            var inputMethodManager = _context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null && _context is Activity)
            {
                var activity = _context as Activity;
                var token = activity.CurrentFocus?.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

                //activity.Window.DecorView.ClearFocus();
            }
        }

        public void ShowKeyboard()
        {
            InputMethodManager imm = (InputMethodManager)_context.GetSystemService(Context.InputMethodService);
            imm.ShowSoftInput((_context as Activity).CurrentFocus, 0);
        }
    }
}