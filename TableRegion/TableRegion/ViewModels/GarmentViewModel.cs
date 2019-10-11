using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class GarmentViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string GarmentsType { get; set; }
        public string Fabrics { get; set; }
        public string GenderRelated { get; set; }
        public string IsWaterProof { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string AgeGroup { get; set; }

        public GarmentViewModel()
        {

        }

        public GarmentViewModel( Product product)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter);

                this.ProductDescription = productDetail[0];
                this.ProductionCode = productDetail[1];
                this.ProductionDate = productDetail[2];
                this.GarmentsType = productDetail[3];
                this.Fabrics = productDetail[4];
                this.GenderRelated = productDetail[5];
                this.IsWaterProof = productDetail[6];
                this.Color = productDetail[7];
                this.Size = productDetail[8];
                this.AgeGroup = productDetail[9];
            }
        }
        public string convertToString()
        {
            return this.ProductDescription + "|" +
                this.ProductionCode + "|" +
                this.ProductionDate + "|" +
                this.GarmentsType + "|" +
                this.Fabrics + "|" +
                this.GenderRelated + "|" +
                this.IsWaterProof + "|" +
                this.Color + "|" +
                this.Size + "|" +
                this.AgeGroup;
        }

        public Dictionary<string, object> convertToDictionary()
        {

            Dictionary<string, object> dictProduct = new Dictionary<string, object>();
            dictProduct.Add("ProductID", this.ProductID);
            dictProduct.Add("ProductDescription", this.ProductDescription);
            dictProduct.Add("ProductionCode", this.ProductionCode);
            dictProduct.Add("ProductionDate", this.ProductionDate);
            dictProduct.Add("GarmentsType", this.GarmentsType);
            dictProduct.Add("Fabrics", this.Fabrics);
            dictProduct.Add("GenderRelated", this.GenderRelated);
            dictProduct.Add("IsWaterProof", this.IsWaterProof);
            dictProduct.Add("Color", this.Color);
            dictProduct.Add("Size", this.Size);
            dictProduct.Add("AgeGroup", this.AgeGroup);

            return dictProduct;
        }
    }


}