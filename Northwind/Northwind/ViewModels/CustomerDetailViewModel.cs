using Northwind.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.ViewModels
{
    public class CustomerDetailViewModel
    {
        public string CustomerID { get; set; }
        public int? SumOrder { get; set; }
        public decimal? TotalAll { get; set; } 
        public List<CustomerProductViewModel> CustomerList { get; set; }

        

    }
}