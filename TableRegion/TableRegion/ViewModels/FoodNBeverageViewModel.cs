using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class FoodNBeverageViewModel
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

        public FoodNBeverageViewModel()
        {
            
        }
        
        public FoodNBeverageViewModel(Product product)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter);

                this.ProductDescription = productDetail[0];
                this.ProductionCode = productDetail[1];
                this.ProductionDate = productDetail[2];
                this.ExpiredDate = productDetail[3];
                this.NetWeight = productDetail[4];
                this.Ingredients = productDetail[5];
                this.DailyValue = productDetail[6];
                this.Certification = productDetail[7];
            }
        }

        public string convertToString()
        {
            return this.ProductDescription + "|" + 
                this.ProductionCode + "|" + 
                this.ProductionDate + "|" + 
                this.ExpiredDate + "|" + 
                this.NetWeight + "|" + 
                this.Ingredients + "|" + 
                this.DailyValue + "|" +
                this.Certification;
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

            return dictProduct;
        }

    }
}