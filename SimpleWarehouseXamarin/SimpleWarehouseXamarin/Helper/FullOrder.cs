using System;
using System.Collections.Generic;
using System.Text;
using SimpleWarehouseMobil.Models;

namespace SimpleWarehouseXamarin.Helper
{
    public class FullOrder : Order
    {
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
