using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class TransportationServicesViewModel : ServicesViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string VehicleType { get; set; }
        public string RoutePath { get; set; }
        public string RouteMilleage { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }
        public string UnitProvit { get; set; }

        public TransportationServicesViewModel()
        {

        }
        public char delimiter(char? deli)
        {
            return deli != null ? Convert.ToChar(deli) : '|';

        }
        public TransportationServicesViewModel (Product product, char? deli)
        {
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))

            {
                String[] productDetail = product.ProductDetail.Split(delimiter(deli));

                this.ProductDescription = productDetail[0];
                this.VehicleType = productDetail[1];
                this.RoutePath = productDetail[2];
                this.RouteMilleage = productDetail[3];
                this.CostCalculationMethod = productDetail[4];
                this.CostRate = productDetail[5];
                this.UnitProvit = productDetail[6];
                
            }
        }
        public string convertServiceToString(char? deli)
        {
            return this.ProductDescription + delimiter(deli) +
                this.VehicleType + delimiter(deli) +
                this.RoutePath + delimiter(deli) +
                this.RouteMilleage + delimiter(deli) +
                this.CostCalculationMethod + delimiter(deli) +
                this.CostRate + delimiter(deli) +
                this.UnitProvit;
        }

        public Dictionary<string, object> convertServiceToDictionary()
        {

            Dictionary<string, object> dictProduct = new Dictionary<string, object>();
            dictProduct.Add("ProductID", this.ProductID);
            dictProduct.Add("ProductDescription", this.ProductDescription);
            dictProduct.Add("VehicleType", this.VehicleType);
            dictProduct.Add("RoutePath", this.RoutePath);
            dictProduct.Add("RouteMilleage", this.RouteMilleage);
            dictProduct.Add("CostCalculationMethod", this.CostCalculationMethod);
            dictProduct.Add("CostRate", this.CostRate);
            dictProduct.Add("UnitProvit", this.UnitProvit);
            
            return dictProduct;
        }

        
        public decimal? CalculateProductUnitPrices(string condition = "", int? userDemand = 0, decimal? duration = 0)
        {
            int? hasil = null;
            if (CostCalculationMethod.Equals("FixPerRoute"))
            {
                hasil = 1 * Int32.Parse(CostRate);
            }
            if (CostCalculationMethod.Equals("PerMiles"))
            {
                hasil = Int32.Parse(RouteMilleage) * (Int32.Parse(CostRate) / 2);
            }
            if (CostCalculationMethod.Equals("PerMilesWithCondition"))
            {
                var nilai = 0;
                if (condition == "GoodWeather")
                {
                    nilai = 5;
                }
                else if (condition == "BadWeather")
                {
                    nilai = 15;
                }
                hasil = (Int32.Parse(RouteMilleage) * Int32.Parse(CostRate) / 2) * (((nilai + (userDemand / 50)) + 95)) / 100;
            }
            return hasil * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
    }
}