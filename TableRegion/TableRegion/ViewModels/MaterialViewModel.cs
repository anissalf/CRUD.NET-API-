using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class MaterialViewModel : ItemsViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string IsConsumable { get; set; }
        public string CostRate { get; set; }

        public MaterialViewModel()
        {

        }

        public MaterialViewModel( Product product)
        {
            char[] delimiter = { ';' };
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter);

                this.ProductDescription = productDetail[0];
                this.ProductionCode = productDetail[1];
                this.ProductionDate = productDetail[2];
                this.ExpiredDate = productDetail[3];
                this.MaterialsType = productDetail[4];
                this.UnitOfMeasurement = productDetail[5];
                this.IsConsumable = productDetail[6];
                this.CostRate = productDetail[7];
                
            }
        }
        
        public string convertToString()
        {
            return this.ProductDescription + ";" +
                this.ProductionCode + ";" +
                this.ProductionDate + ";" +
                this.ExpiredDate + ";" +
                this.MaterialsType + ";" +
                this.UnitOfMeasurement + ";" +
                this.IsConsumable + ";" +
                this.CostRate;
        }

        public Dictionary<string, object> convertToDictionary()
        {

            Dictionary<string, object> dictProduct = new Dictionary<string, object>();
            dictProduct.Add("ProductID", this.ProductID);
            dictProduct.Add("ProductDescription", this.ProductDescription);
            dictProduct.Add("ProductionCode", this.ProductionCode);
            dictProduct.Add("ProductionDate", this.ProductionDate);
            dictProduct.Add("ExpiredDate", this.ExpiredDate);
            dictProduct.Add("MaterialsType", this.MaterialsType);
            dictProduct.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            dictProduct.Add("IsConsumable", this.IsConsumable);
            dictProduct.Add("CostRate", this.CostRate);

            return dictProduct;
        }
        public decimal CalculateProductUnitPrice()
        {
            
            var cost = Decimal.Parse(CostRate);
            var hasil = (cost * (110 / 100));

            return hasil;
        }
    }

    
}