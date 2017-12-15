﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OrderEntities : DbContext
    {
        public OrderEntities()
            : base("name=OrderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<vwCustomerDetail> vwCustomerDetail { get; set; }
        public virtual DbSet<vwOrder> vwOrder { get; set; }
        public virtual DbSet<vwOrderDetail> vwOrderDetail { get; set; }
    
        public virtual ObjectResult<Nullable<int>> DeleteRecord(string table, Nullable<int> id, Nullable<System.DateTime> updatedate, string updateby)
        {
            var tableParameter = table != null ?
                new ObjectParameter("table", table) :
                new ObjectParameter("table", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("DeleteRecord", tableParameter, idParameter, updatedateParameter, updatebyParameter);
        }
    
        public virtual ObjectResult<GetCustomerSearch_Result> GetCustomerSearch(Nullable<int> customerid, Nullable<int> zone, Nullable<int> pageIndex, Nullable<int> pageSize)
        {
            var customeridParameter = customerid.HasValue ?
                new ObjectParameter("customerid", customerid) :
                new ObjectParameter("customerid", typeof(int));
    
            var zoneParameter = zone.HasValue ?
                new ObjectParameter("zone", zone) :
                new ObjectParameter("zone", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerSearch_Result>("GetCustomerSearch", customeridParameter, zoneParameter, pageIndexParameter, pageSizeParameter);
        }
    
        public virtual ObjectResult<GetCustomerTransport_Result> GetCustomerTransport(Nullable<System.DateTime> date)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetCustomerTransport_Result>("GetCustomerTransport", dateParameter);
        }
    
        public virtual ObjectResult<GetDailyOrder_Result> GetDailyOrder(string day, Nullable<int> customer)
        {
            var dayParameter = day != null ?
                new ObjectParameter("day", day) :
                new ObjectParameter("day", typeof(string));
    
            var customerParameter = customer.HasValue ?
                new ObjectParameter("customer", customer) :
                new ObjectParameter("customer", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDailyOrder_Result>("GetDailyOrder", dayParameter, customerParameter);
        }
    
        public virtual ObjectResult<GetOrderbyDay_Result> GetOrderbyDay(Nullable<System.DateTime> date, Nullable<int> customer)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var customerParameter = customer.HasValue ?
                new ObjectParameter("customer", customer) :
                new ObjectParameter("customer", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetOrderbyDay_Result>("GetOrderbyDay", dateParameter, customerParameter);
        }
    
        public virtual ObjectResult<GetProductSearch_Result> GetProductSearch(Nullable<int> productid, Nullable<int> category, Nullable<int> pageIndex, Nullable<int> pageSize)
        {
            var productidParameter = productid.HasValue ?
                new ObjectParameter("productid", productid) :
                new ObjectParameter("productid", typeof(int));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(int));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductSearch_Result>("GetProductSearch", productidParameter, categoryParameter, pageIndexParameter, pageSizeParameter);
        }
    
        public virtual ObjectResult<GetProductTransport_Result> GetProductTransport(Nullable<System.DateTime> date, Nullable<int> zone)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var zoneParameter = zone.HasValue ?
                new ObjectParameter("zone", zone) :
                new ObjectParameter("zone", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductTransport_Result>("GetProductTransport", dateParameter, zoneParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertCustomer(string citizenid, string customername, string customerabbr, Nullable<int> zone, string address1, string address2, string phone, string description, Nullable<bool> showprice, Nullable<bool> status, Nullable<System.DateTime> updatedate, string updateby)
        {
            var citizenidParameter = citizenid != null ?
                new ObjectParameter("citizenid", citizenid) :
                new ObjectParameter("citizenid", typeof(string));
    
            var customernameParameter = customername != null ?
                new ObjectParameter("customername", customername) :
                new ObjectParameter("customername", typeof(string));
    
            var customerabbrParameter = customerabbr != null ?
                new ObjectParameter("customerabbr", customerabbr) :
                new ObjectParameter("customerabbr", typeof(string));
    
            var zoneParameter = zone.HasValue ?
                new ObjectParameter("zone", zone) :
                new ObjectParameter("zone", typeof(int));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("address1", address1) :
                new ObjectParameter("address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("address2", address2) :
                new ObjectParameter("address2", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var showpriceParameter = showprice.HasValue ?
                new ObjectParameter("showprice", showprice) :
                new ObjectParameter("showprice", typeof(bool));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertCustomer", citizenidParameter, customernameParameter, customerabbrParameter, zoneParameter, address1Parameter, address2Parameter, phoneParameter, descriptionParameter, showpriceParameter, statusParameter, updatedateParameter, updatebyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertOrder(Nullable<System.DateTime> orderdate, Nullable<System.DateTime> updatedate, Nullable<int> customerid, Nullable<int> productid, Nullable<decimal> productprice, Nullable<decimal> orderprice, Nullable<int> orderamount, Nullable<decimal> ordertotal, string description, Nullable<bool> orderStatus, string updateby)
        {
            var orderdateParameter = orderdate.HasValue ?
                new ObjectParameter("orderdate", orderdate) :
                new ObjectParameter("orderdate", typeof(System.DateTime));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var customeridParameter = customerid.HasValue ?
                new ObjectParameter("customerid", customerid) :
                new ObjectParameter("customerid", typeof(int));
    
            var productidParameter = productid.HasValue ?
                new ObjectParameter("productid", productid) :
                new ObjectParameter("productid", typeof(int));
    
            var productpriceParameter = productprice.HasValue ?
                new ObjectParameter("productprice", productprice) :
                new ObjectParameter("productprice", typeof(decimal));
    
            var orderpriceParameter = orderprice.HasValue ?
                new ObjectParameter("orderprice", orderprice) :
                new ObjectParameter("orderprice", typeof(decimal));
    
            var orderamountParameter = orderamount.HasValue ?
                new ObjectParameter("orderamount", orderamount) :
                new ObjectParameter("orderamount", typeof(int));
    
            var ordertotalParameter = ordertotal.HasValue ?
                new ObjectParameter("ordertotal", ordertotal) :
                new ObjectParameter("ordertotal", typeof(decimal));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var orderStatusParameter = orderStatus.HasValue ?
                new ObjectParameter("orderStatus", orderStatus) :
                new ObjectParameter("orderStatus", typeof(bool));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertOrder", orderdateParameter, updatedateParameter, customeridParameter, productidParameter, productpriceParameter, orderpriceParameter, orderamountParameter, ordertotalParameter, descriptionParameter, orderStatusParameter, updatebyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertProduct(string productname, string productabbr, Nullable<int> category, Nullable<decimal> productprice, Nullable<int> unit, Nullable<int> productamount, string description, Nullable<bool> status, Nullable<System.DateTime> updatedate, string updateby)
        {
            var productnameParameter = productname != null ?
                new ObjectParameter("productname", productname) :
                new ObjectParameter("productname", typeof(string));
    
            var productabbrParameter = productabbr != null ?
                new ObjectParameter("productabbr", productabbr) :
                new ObjectParameter("productabbr", typeof(string));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(int));
    
            var productpriceParameter = productprice.HasValue ?
                new ObjectParameter("productprice", productprice) :
                new ObjectParameter("productprice", typeof(decimal));
    
            var unitParameter = unit.HasValue ?
                new ObjectParameter("unit", unit) :
                new ObjectParameter("unit", typeof(int));
    
            var productamountParameter = productamount.HasValue ?
                new ObjectParameter("productamount", productamount) :
                new ObjectParameter("productamount", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertProduct", productnameParameter, productabbrParameter, categoryParameter, productpriceParameter, unitParameter, productamountParameter, descriptionParameter, statusParameter, updatedateParameter, updatebyParameter);
        }
    
        public virtual ObjectResult<SelectGridPaging_Result> SelectGridPaging(string tablename, Nullable<int> minpagesize, Nullable<int> intskip)
        {
            var tablenameParameter = tablename != null ?
                new ObjectParameter("tablename", tablename) :
                new ObjectParameter("tablename", typeof(string));
    
            var minpagesizeParameter = minpagesize.HasValue ?
                new ObjectParameter("minpagesize", minpagesize) :
                new ObjectParameter("minpagesize", typeof(int));
    
            var intskipParameter = intskip.HasValue ?
                new ObjectParameter("intskip", intskip) :
                new ObjectParameter("intskip", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectGridPaging_Result>("SelectGridPaging", tablenameParameter, minpagesizeParameter, intskipParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateCustomer(Nullable<int> customerid, string citizenid, string customername, string customerabbr, Nullable<int> zone, string address1, string address2, string phone, string description, Nullable<bool> showprice, Nullable<bool> status, Nullable<System.DateTime> updatedate, string updateby)
        {
            var customeridParameter = customerid.HasValue ?
                new ObjectParameter("customerid", customerid) :
                new ObjectParameter("customerid", typeof(int));
    
            var citizenidParameter = citizenid != null ?
                new ObjectParameter("citizenid", citizenid) :
                new ObjectParameter("citizenid", typeof(string));
    
            var customernameParameter = customername != null ?
                new ObjectParameter("customername", customername) :
                new ObjectParameter("customername", typeof(string));
    
            var customerabbrParameter = customerabbr != null ?
                new ObjectParameter("customerabbr", customerabbr) :
                new ObjectParameter("customerabbr", typeof(string));
    
            var zoneParameter = zone.HasValue ?
                new ObjectParameter("zone", zone) :
                new ObjectParameter("zone", typeof(int));
    
            var address1Parameter = address1 != null ?
                new ObjectParameter("address1", address1) :
                new ObjectParameter("address1", typeof(string));
    
            var address2Parameter = address2 != null ?
                new ObjectParameter("address2", address2) :
                new ObjectParameter("address2", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var showpriceParameter = showprice.HasValue ?
                new ObjectParameter("showprice", showprice) :
                new ObjectParameter("showprice", typeof(bool));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateCustomer", customeridParameter, citizenidParameter, customernameParameter, customerabbrParameter, zoneParameter, address1Parameter, address2Parameter, phoneParameter, descriptionParameter, showpriceParameter, statusParameter, updatedateParameter, updatebyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateOrder(Nullable<System.DateTime> orderdate, Nullable<System.DateTime> updatedate, Nullable<int> customerid, Nullable<int> productid, Nullable<decimal> productprice, Nullable<decimal> orderprice, Nullable<int> orderamount, Nullable<decimal> ordertotal, string description, Nullable<bool> status, string updateby)
        {
            var orderdateParameter = orderdate.HasValue ?
                new ObjectParameter("orderdate", orderdate) :
                new ObjectParameter("orderdate", typeof(System.DateTime));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var customeridParameter = customerid.HasValue ?
                new ObjectParameter("customerid", customerid) :
                new ObjectParameter("customerid", typeof(int));
    
            var productidParameter = productid.HasValue ?
                new ObjectParameter("productid", productid) :
                new ObjectParameter("productid", typeof(int));
    
            var productpriceParameter = productprice.HasValue ?
                new ObjectParameter("productprice", productprice) :
                new ObjectParameter("productprice", typeof(decimal));
    
            var orderpriceParameter = orderprice.HasValue ?
                new ObjectParameter("orderprice", orderprice) :
                new ObjectParameter("orderprice", typeof(decimal));
    
            var orderamountParameter = orderamount.HasValue ?
                new ObjectParameter("orderamount", orderamount) :
                new ObjectParameter("orderamount", typeof(int));
    
            var ordertotalParameter = ordertotal.HasValue ?
                new ObjectParameter("ordertotal", ordertotal) :
                new ObjectParameter("ordertotal", typeof(decimal));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateOrder", orderdateParameter, updatedateParameter, customeridParameter, productidParameter, productpriceParameter, orderpriceParameter, orderamountParameter, ordertotalParameter, descriptionParameter, statusParameter, updatebyParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateProduct(Nullable<int> productid, string productname, string productabbr, Nullable<int> category, Nullable<decimal> productprice, Nullable<int> unit, Nullable<int> productamount, string description, Nullable<bool> status, Nullable<System.DateTime> updatedate, string updateby)
        {
            var productidParameter = productid.HasValue ?
                new ObjectParameter("productid", productid) :
                new ObjectParameter("productid", typeof(int));
    
            var productnameParameter = productname != null ?
                new ObjectParameter("productname", productname) :
                new ObjectParameter("productname", typeof(string));
    
            var productabbrParameter = productabbr != null ?
                new ObjectParameter("productabbr", productabbr) :
                new ObjectParameter("productabbr", typeof(string));
    
            var categoryParameter = category.HasValue ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(int));
    
            var productpriceParameter = productprice.HasValue ?
                new ObjectParameter("productprice", productprice) :
                new ObjectParameter("productprice", typeof(decimal));
    
            var unitParameter = unit.HasValue ?
                new ObjectParameter("unit", unit) :
                new ObjectParameter("unit", typeof(int));
    
            var productamountParameter = productamount.HasValue ?
                new ObjectParameter("productamount", productamount) :
                new ObjectParameter("productamount", typeof(int));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var updatedateParameter = updatedate.HasValue ?
                new ObjectParameter("updatedate", updatedate) :
                new ObjectParameter("updatedate", typeof(System.DateTime));
    
            var updatebyParameter = updateby != null ?
                new ObjectParameter("updateby", updateby) :
                new ObjectParameter("updateby", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateProduct", productidParameter, productnameParameter, productabbrParameter, categoryParameter, productpriceParameter, unitParameter, productamountParameter, descriptionParameter, statusParameter, updatedateParameter, updatebyParameter);
        }
    }
}
