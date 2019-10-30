using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }


        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public string ProductType { get; set; }
        public Dictionary<string, object> ProductDetail { get; set; }
    }
}