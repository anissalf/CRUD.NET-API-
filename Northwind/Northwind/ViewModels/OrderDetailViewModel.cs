using Northwind.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.ViewModels
{
    public class OrderDetailViewModel
    {
        
        public int? OrderID { get; set; }
        public string ContactName { get; set; }
        public List<ProductListViewModel> ProductList { get; set; }
        public decimal? GrandTotal { get; set; }
        

    }
}