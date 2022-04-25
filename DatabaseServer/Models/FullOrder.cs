using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace DatabaseServer.Models
{
    public class FullOrder:Order
    {
        public List<OrderDetail> OrderDetails { get; set; }
    }
}