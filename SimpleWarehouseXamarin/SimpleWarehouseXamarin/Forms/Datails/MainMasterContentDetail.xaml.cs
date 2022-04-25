using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseXamarin.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterContentDetail : ContentPage
    {
        private Dictionary<string, Type> TypeToPage;
        private Dictionary<string, string> TypeToName;
        public MainMasterContentDetail()
        {
            InitializeComponent();
            TypeToPage = new Dictionary<string, Type>()
            {
                {"Product",typeof(ApplicationPage)},
                {"ProductIn",typeof(ProductInPage)},
                {"ProductOut",typeof(ProductInPage)},
                {"Order",typeof(OrderPage)}
            };

            TypeToName = new Dictionary<string, string>()
            {
                {"Product","Ürün Listesi"},
                {"ProductIn","Ürün Girişi"},
                {"ProductOut","Ürün Çıkışı"},
                {"Order","Siparişler"}
            };

        }


        private void StackLayoutTapped(object sender, EventArgs e)
        {
            var x = (e as TappedEventArgs).Parameter.ToString();
            var item = TypeToPage[x];
            var page = (Page)Activator.CreateInstance(item);
            page.Title = TypeToName[x];
            var index = TypeToName.Keys.Cast<string>().IndexOf(x);

            page.GetType().GetProperty("InOrOut")?.SetValue(page,(short)(3-(2*index)));
            var mainPage = (Application.Current.MainPage as NavigationPage);
            (mainPage).PushAsync(page);
        // = new NavigationPage(page);
           // mainPage.IsPresented = false;
        }
    }
}