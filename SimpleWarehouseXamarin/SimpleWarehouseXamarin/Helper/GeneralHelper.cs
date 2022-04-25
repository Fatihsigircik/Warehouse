using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SimpleWarehouseXamarin.Helper
{
    public class GeneralHelper
    {
        public static bool IsConnectInternet => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
