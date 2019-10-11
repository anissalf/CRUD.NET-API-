using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class CostCalculationViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CostCalculationMethod { get; set; }
        public int CostCalculation { get; set; }
        private int CostRate { get; set; }
        private int RouteMilleage { get; set; }

        public CostCalculationViewModel()
        {

        }

        public CostCalculationViewModel(Product product, string condition, int userDemand)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;
            
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter);

                this.ProductName = product.ProductName;
                this.RouteMilleage = Int32.Parse(productDetail[3]);
                this.CostCalculationMethod = productDetail[4];
                this.CostRate = Int32.Parse(productDetail[5]);
                this.CostCalculation = RateCostCalculation(condition, userDemand);

            }

        }

        public int RateCostCalculation (string condition, int userDemand)
        {
            var hitung = 0;

            if (CostCalculationMethod.Equals("FixPerRoute"))
            {
                hitung = 1 * this.CostRate;
            }
            if (CostCalculationMethod.Equals("PerMiles"))
            {
                hitung = (this.RouteMilleage * this.CostRate)/2;
            }
            if (CostCalculationMethod.Equals("PerMilesWithCondition"))
            {
                var tamp = 0;
                if (condition == "GoodWeather")
                {
                    tamp = 5;
                }
                else if (condition == "BadWeather")
                {
                    tamp = 15;
                }
                hitung = (RouteMilleage * CostRate / 2) * (((tamp + (userDemand / 50)) + 95))/100;
            }

            return hitung;
        }
    }
}