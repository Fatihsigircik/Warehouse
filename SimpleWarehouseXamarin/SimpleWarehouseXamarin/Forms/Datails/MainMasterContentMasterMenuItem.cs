using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SimpleWarehouseXamarin
{

    public class MainMasterContentMasterMenuItem
    {
        public MainMasterContentMasterMenuItem()
        {
            TargetType = typeof(MainMasterContentMasterMenuItem); 
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
        public ImageSource Image { get; set; }
    }
}