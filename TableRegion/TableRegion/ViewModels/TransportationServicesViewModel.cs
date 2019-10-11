using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class TransportationServicesViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string VehicleType { get; set; }
        public string RoutePath { get; set; }
        public string RouteMilleage { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }

        public TransportationServicesViewModel()
        {

        }

        public TransportationServicesViewModel (Product product)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter);

                this.ProductDescription = productDetail[0];
                this.VehicleType = productDetail[1];
                this.RoutePath = productDetail[2];
                this.RouteMilleage = productDetail[3];
                this.CostCalculationMethod = productDetail[4];
                this.CostRate = productDetail[5];
                
            }
        }
        public string convertToString()
        {
            return this.ProductDescription + "|" +
                this.VehicleType + "|" +
                this.RoutePath + "|" +
                this.RouteMilleage + "|" +
                this.CostCalculationMethod + "|" +
                this.CostRate;
        }

        public Dictionary<string, object> convertToDictionary()
        {

            Dictionary<string, object> dictProduct = new Dictionary<string, object>();
            dictProduct.Add("ProductID", this.ProductID);
            dictProduct.Add("ProductDescription", this.ProductDescription);
            dictProduct.Add("VehicleType", this.VehicleType);
            dictProduct.Add("RoutePath", this.RoutePath);
            dictProduct.Add("RouteMilleage", this.RouteMilleage);
            dictProduct.Add("CostCalculationMethod", this.CostCalculationMethod);
            dictProduct.Add("CostRate", this.CostRate);
            
            return dictProduct;
        }
    }
}