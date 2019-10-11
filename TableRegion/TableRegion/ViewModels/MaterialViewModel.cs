using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class MaterialViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string IsConsumable { get; set; }

        public MaterialViewModel()
        {

        }

        public MaterialViewModel( Product product)
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
                this.MaterialsType = productDetail[4];
                this.UnitOfMeasurement = productDetail[5];
                this.IsConsumable = productDetail[6];
                
            }
        }
        
        public string convertToString()
        {
            return this.ProductDescription + "|" +
                this.ProductionCode + "|" +
                this.ProductionDate + "|" +
                this.ExpiredDate + "|" +
                this.MaterialsType + "|" +
                this.UnitOfMeasurement + "|" +
                this.IsConsumable;
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

            return dictProduct;
        }
    }

    
}