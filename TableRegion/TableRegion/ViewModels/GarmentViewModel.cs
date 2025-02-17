﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class GarmentViewModel : ItemsViewModel
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
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }
        public string UnitProvit { get; set; }
        public GarmentViewModel()
        {

        }
        public char delimiter(char? deli)
        {
            return deli != null ? Convert.ToChar(deli) : '|';

        }
        public GarmentViewModel( Product product, char? deli)
        {
            this.ProductID = product.ProductID;

            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                String[] productDetail = product.ProductDetail.Split(delimiter(deli));

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
                this.UnitOfMeasurement = productDetail[10];
                this.CostRate = productDetail[11];
                this.UnitProvit = productDetail[12];
            }
        }
        public string convertToString(char? deli)
        {
            return this.ProductDescription + delimiter(deli) +
                this.ProductionCode + delimiter(deli) +
                this.ProductionDate + delimiter(deli) +
                this.GarmentsType + delimiter(deli) +
                this.Fabrics + delimiter(deli) +
                this.GenderRelated + delimiter(deli) +
                this.IsWaterProof + delimiter(deli) +
                this.Color + delimiter(deli) +
                this.Size + delimiter(deli) +
                this.AgeGroup + delimiter(deli) +
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
            dictProduct.Add("GarmentsType", this.GarmentsType);
            dictProduct.Add("Fabrics", this.Fabrics);
            dictProduct.Add("GenderRelated", this.GenderRelated);
            dictProduct.Add("IsWaterProof", this.IsWaterProof);
            dictProduct.Add("Color", this.Color);
            dictProduct.Add("Size", this.Size);
            dictProduct.Add("AgeGroup", this.AgeGroup);
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