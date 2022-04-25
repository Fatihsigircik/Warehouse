using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWarehouseWindows.Models
{
    public class WebImage
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string Base64String { get; set; }
        public byte LineNumber { get; set; }
        public bool IsDefault { get; set; }

    }
}
