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
    
    public partial class Order
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public int CustomerId { get; set; }
        public string DocNumber { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> OrderStatusId { get; set; }
        public Nullable<decimal> TotalPrice { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<decimal> TotalVal { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public Nullable<int> InvoiceCountryId { get; set; }
        public Nullable<int> InvoiceRegionId { get; set; }
        public Nullable<int> InvoiceCityId { get; set; }
        public Nullable<int> InvoiceTownId { get; set; }
        public string InvoiceAddress { get; set; }
        public string InvoiceAddress2 { get; set; }
        public Nullable<int> DeliveryCountryId { get; set; }
        public Nullable<int> DeliveryRegionId { get; set; }
        public Nullable<int> DeliveryCityId { get; set; }
        public Nullable<int> DeliveryTownId { get; set; }
        public string DeliveryAddress { get; set; }
        public string DeliveryAddress2 { get; set; }
        public Nullable<int> CreatedId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> OrderTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}
