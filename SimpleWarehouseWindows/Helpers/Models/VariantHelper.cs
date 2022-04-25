using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.Helpers.Models
{
    internal class VariantHelper:Variant
    {
        public string PropertyName1 { get; set; }
        public string PropertyName2 { get; set; }
        public string PropertyName3 { get; set; }
        public string PropertyName4 { get; set; }
        public string PropertyName5 { get; set; }
        public override string ToString()
        {
            return $"{PropertyName1} {PropertyName2} {PropertyName3} {PropertyName4} {PropertyName5}";
        }
    }

}
