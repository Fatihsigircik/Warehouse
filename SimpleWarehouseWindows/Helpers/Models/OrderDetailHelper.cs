using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWarehouseWindows.Models;

namespace SimpleWarehouseWindows.Helpers.Models
{
    internal class OrderDetailHelper:OrderDetail
    {
        //private readonly List<Currency> _currencies;
        //private readonly List<Warehouse> _warehouses;
        //private readonly List<Unit> _units;

        //public OrderDetailHelper(List<Currency> currencies,List<Warehouse> warehouses,List<Unit> units)
        //{
        //    _currencies = currencies;
        //    _warehouses = warehouses;
        //    _units = units;
        //}
        public Currency Currency { get; set; }
        public string CurrencyCode
        {
            get => Currency?.CurrencyCode;
            set { /*Currency = _currencies.FirstOrDefault(q => q.CurrencyCode == value);*/ }
        }
        public Warehouse Warehouse { get; set; }

        public string WarehouseName
        {
            get => Warehouse?.WarehouseName;
            set {/* Warehouse = _warehouses.FirstOrDefault(q => q.WarehouseName == value);*/ }
        }

        public Unit Unit  { get; set; }
        public string UnitName
        {
            get => Unit?.UnitName;
            set { /*Unit = _units.FirstOrDefault(q => q.UnitName == value);*/ }
        }
        public ProductVariant Variant{ get; set; }

        public string VariantName => Variant?.ToString();
        public string ProductCode { get; set; }


    }
}
