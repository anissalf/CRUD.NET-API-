using Northwind.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.ViewModels
{
    public class ProductListViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get; set; }
        public ProductListViewModel()
        {

        }

        public ProductListViewModel(Order_Detail entity)
        {
           
            ProductID = entity.ProductID;
            ProductName = entity.Product.ProductName;
            CategoryName = entity.Product.Category.CategoryName;
            SupplierName = entity.Product.Supplier.CompanyName;
            UnitPrice = entity.UnitPrice;
            Quantity = entity.Quantity;
            Total = (Convert.ToDecimal(entity.UnitPrice) * Convert.ToDecimal(entity.Quantity)) - (Convert.ToDecimal(entity.Discount) * Convert.ToDecimal(entity.UnitPrice) * Convert.ToDecimal(entity.Quantity));


        }

    }
}
