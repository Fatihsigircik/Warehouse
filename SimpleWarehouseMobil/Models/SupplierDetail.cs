//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleWarehouseMobil.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplierDetail
    {
        public int SupplierDetailId { get; set; }
        public int SupplierId { get; set; }
        public string DetailCode { get; set; }
        public Nullable<int> DetailTypeId { get; set; }
        public string Detail { get; set; }
        public Nullable<decimal> Debt { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<System.DateTime> DetailDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
