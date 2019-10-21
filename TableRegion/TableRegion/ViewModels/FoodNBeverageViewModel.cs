using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class FoodNBeverageViewModel : ItemsViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string NetWeight { get; set; }
        public string Ingredients { get; set; }
        public string DailyValue { get; set; }
        public string Certification { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }
        public string UnitProvit { get; set; }

        public FoodNBeverageViewModel()
        {
            
        }
        public char delimiter(char? deli)
        {
            return deli != null ? Convert.ToChar(deli) : '|';

        }
        public FoodNBeverageViewModel(Product product, char? deli)
        {
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter(deli));

                this.ProductDescription = productDetail[0];
                this.ProductionCode = productDetail[1];
                this.ProductionDate = productDetail[2];
                this.ExpiredDate = productDetail[3];
                this.NetWeight = productDetail[4];
                this.Ingredients = productDetail[5];
                this.DailyValue = productDetail[6];
                this.Certification = productDetail[7];
                this.UnitOfMeasurement = productDetail[8];
                this.CostRate = productDetail[9];
                this.UnitProvit = productDetail[10];

            }
        }

        public string convertToString(char? deli )
        {
            return this.ProductDescription + delimiter(deli) + 
                this.ProductionCode + delimiter(deli) + 
                this.ProductionDate + delimiter(deli) + 
                this.ExpiredDate + delimiter(deli) + 
                this.NetWeight + delimiter(deli) + 
                this.Ingredients + delimiter(deli) + 
                this.DailyValue + delimiter(deli) +
                this.Certification + delimiter(deli) +
                this.UnitOfMeasurement + delimiter(deli) +
                this.CostRate + delimiter(deli) +
                this.UnitProvit;
        }

        public Dictionary<string, object> convertToDictionary()
        {
            
            Dictionary<string, object> dictProduct = new Dictionary<string, object>();
            dictProduct.Add("ProductID", this.ProductID);
            dictProduct.Add("ProductDescription", this.ProductDescription);
            dictProduct.Add("ProductionCode", this.ProductionCode);
            dictProduct.Add("ProductionDate", this.ProductionDate);
            dictProduct.Add("ExpiredDate", this.ExpiredDate);
            dictProduct.Add("NetWeight", this.NetWeight);
            dictProduct.Add("Ingredients", this.Ingredients);
            dictProduct.Add("DailyValue", this.DailyValue);
            dictProduct.Add("Certification", this.Certification);
            dictProduct.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            dictProduct.Add("CostRate", this.CostRate);
            dictProduct.Add("UnitProvit", this.UnitProvit);

            return dictProduct;
        }

        public decimal CalculateProductUnitPrice()
        {

            var cost = Decimal.Parse(CostRate);
            decimal hasil = cost * (Convert.ToDecimal(110) / Convert.ToDecimal(100));

            return hasil;
        }
    }
}