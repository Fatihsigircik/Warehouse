using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseXamarin.Forms;
using SimpleWarehouseXamarin.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleWarehouseXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterContentMaster : ContentPage
    {
        public ListView ListView;

        public MainMasterContentMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterContentMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterContentMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMasterContentMasterMenuItem> MenuItems { get; set; }

            public MainMasterContentMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMasterContentMasterMenuItem>(new[]
                {
                    new MainMasterContentMasterMenuItem { Id = 0, Title = "Ürünler",TargetType = typeof(ApplicationPage),Image = ImageSource.FromResource("SimpleWarehouseXamarin.Resources.blank.png")},
                    new MainMasterContentMasterMenuItem { Id = 1, Title = "Siparişler",TargetType = typeof(OrderPage),Image = ImageSource.FromResource("SimpleWarehouseXamarin.Resources.cart.png")},
                    new MainMasterContentMasterMenuItem { Id = 2, Title = "Ürün Girişi",TargetType = typeof(ProductInPage),Image = ImageSource.FromResource("SimpleWarehouseXamarin.Resources.in.png") },
                    new MainMasterContentMasterMenuItem { Id = 3, Title = "Ürün Çıkışı",TargetType = typeof(ProductOutPage),Image = ImageSource.FromResource("SimpleWarehouseXamarin.Resources.out.png") },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

       
    }
}