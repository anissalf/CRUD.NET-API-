using Northwind.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.ViewModels
{
    public class CustomerProductViewModel
    {

        public int? OrderID { get; set; }
        public string ContactName { get; set; }
        public List<ProductListViewModel> ProductList { get; set; }
        public decimal? GrandTotal { get; set; }
        public CustomerProductViewModel()
        {

        }
        public CustomerProductViewModel(Order entity)
        {
            OrderID = entity.OrderID;
            ContactName = entity.Customer.ContactName;
            ProductList = entity.Order_Details.ToList().Select(data => new ProductListViewModel(data)).ToList();
            GrandTotal = entity.Order_Details.ToList().Select(data => new ProductListViewModel(data)).ToList().Sum(data => data.Total);

        }
    }
}