//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleWarehouseWindows.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VwCustomerDetail
    {
        public int CustomerDetailId { get; set; }
        public int CustomerId { get; set; }
        public string DetailCode { get; set; }
        public Nullable<int> DetailTypeId { get; set; }
        public string Detail { get; set; }
        public Nullable<decimal> Debt { get; set; }
        public Nullable<decimal> Credit { get; set; }
        public Nullable<System.DateTime> DetailDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CustomerCode { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string DetailTypeName { get; set; }
    }
}
