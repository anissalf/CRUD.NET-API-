using AutoMapper;
using ProductDetail.EntityFrameworks;
using ProductDetail.ViewModels.ProductDetails.Items.Details;
using ProductDetail.ViewModels.ProductDetails.Services.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProductDetail.ViewModels
{
    public class CreateNReadModel : ProductViewModel
    {
        public Product createProductString()
        {
            var description = "";
            var config = new MapperConfiguration(con => { });
            var mapper = new Mapper(config);

            if (this.ProductType.Equals("FoodAndBeverageItems"))
            {
                FoodAndBeverage Foods = mapper.Map<FoodAndBeverage>(this.ProductDetail);
                description = Foods.ConvertToString();
            }
            else if (this.ProductType.Equals("MaterialItems"))
            {
                Material material = mapper.Map<Material>(this.ProductDetail);
                description = material.ConvertToString();
            }
            else if (this.ProductType.Equals("GarmentItems"))
            {
                Garment garment = mapper.Map<Garment>(this.ProductDetail);
                description = garment.ConvertToString();
            }
            else if (this.ProductType.Contains("TransportationServices"))
            {
                Transportation transport = mapper.Map<Transportation>(this.ProductDetail);
                description = transport.ConvertToString();
            }
            else if (this.ProductType.Contains("TelecommunicationServices"))
            {
                Telecommunication telecommunications = mapper.Map<Telecommunication>(this.ProductDetail);
                description = telecommunications.ConvertToString();
            }

            return new Product()
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                SupplierID = this.SupplierID,
                CategoryID = this.CategoryID,
                QuantityPerUnit = this.QuantityPerUnit,
                UnitPrice = this.UnitPrice,
                UnitsInStock = this.UnitsInStock,
                UnitsOnOrder = this.UnitsOnOrder,
                ReorderLevel = this.ReorderLevel,
                Discontinued = this.Discontinued,
                ProductType = this.ProductType,
                ProductDetail = description
            };
        }

        public Dictionary<string, object> CreateProductDictionary()
        {
            
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ProductID", this.ProductID);
            dict.Add("ProductName", this.ProductID);
            dict.Add("SupplierID", this.ProductID);
            dict.Add("CategoryID", this.ProductID);
            dict.Add("QuantityPerUnit", this.ProductID);
            dict.Add("UnitPrice", this.ProductID);
            dict.Add("UnitsInStock", this.ProductID);
            dict.Add("UnitsOnOrder", this.ProductID);
            dict.Add("ReorderLevel", this.ProductID);
            dict.Add("ProductID", this.ProductID);

            return dict;

        }

    }
}