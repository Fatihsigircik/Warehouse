using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.Helpers.Models
{
    public class FullOrder:Order
    {
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
