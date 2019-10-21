using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class TelecomunicationServicesViewModel : ServicesViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string PacketType { get; set; }
        public string PacketLimit { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }
        public string UnitProvit { get; set; }

        public TelecomunicationServicesViewModel()
        {

        }
        public char delimiter(char? deli)
        {
            return deli != null ? Convert.ToChar(deli) : '|';

        }
        public TelecomunicationServicesViewModel (Product product, char? deli)
        {
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter(deli));

                this.ProductDescription = productDetail[0];
                this.PacketType = productDetail[1];
                this.PacketLimit = productDetail[2];
                this.CostCalculationMethod = productDetail[4];
                this.CostRate = productDetail[5];
                this.UnitProvit = productDetail[6];

            }
        }
        public string convertServiceToString(char? deli)
        {
            return this.ProductDescription + delimiter(deli) +
                this.PacketType + delimiter(deli) +
                this.PacketLimit + delimiter(deli) +
                this.CostCalculationMethod + delimiter(deli) +
                this.CostRate + delimiter(deli) +
                this.UnitProvit;
        }

        public Dictionary<string, object> convertServiceToDictionary()
        {

            Dictionary<string, object> dictProduct = new Dictionary<string, object>();
            dictProduct.Add("ProductID", this.ProductID);
            dictProduct.Add("ProductDescription", this.ProductDescription);
            dictProduct.Add("PacketType", this.PacketType);
            dictProduct.Add("PacketLimit", this.PacketLimit);
            dictProduct.Add("CostCalculationMethod", this.CostCalculationMethod);
            dictProduct.Add("CostRate", this.CostRate);
            dictProduct.Add("UnitProvit", this.UnitProvit);

            return dictProduct;
        }

        public decimal? CalculateProductUnitPrices(string condition = "", int? userDemand = null, decimal? duration = null)
        {
            decimal? valueResult = null;
            decimal decCostRate = decimal.Parse(CostRate);

            if (CostCalculationMethod.Equals("PerSecond"))
            {
                valueResult = decCostRate * duration;
            }
            else if (CostCalculationMethod.Equals("PerPacket"))
            {
                if (PacketType.Equals("Data"))
                {
                    valueResult = decimal.Parse(PacketLimit) * decCostRate;
                }
                else
                {
                    valueResult = (decCostRate * duration) * decCostRate;
                }
            }
            else
            {
                valueResult = 0;
            }

            return valueResult * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
        
    }
}