//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderManagement.Entity
{
    using System;
    
    public partial class GetOrderbyDay_Result
    {
        public int OrderID { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<decimal> ProductPrice { get; set; }
        public Nullable<decimal> OrderPrice { get; set; }
        public Nullable<int> OrderAmount { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
        public string Description { get; set; }
        public Nullable<bool> OrderStatus { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string WeekDay { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<int> Amount { get; set; }
    }
}
