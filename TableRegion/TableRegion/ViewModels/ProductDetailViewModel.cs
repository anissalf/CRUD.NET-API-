using AutoMapper;
using TableRegion.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TableRegion.ViewModels
{
    public class ProductDetailViewModel : ProductViewModel
    { 
        public ProductDetailViewModel()
        {

        }

        public ProductDetailViewModel (Product product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            SupplierID = product.SupplierID;
            CategoryID = product.CategoryID;
            QuantityPerUnit = product.QuantityPerUnit;
            UnitPrice = product.UnitPrice;
            UnitsInStock = product.UnitsInStock;
            UnitsOnOrder = product.UnitsOnOrder;
            ReorderLevel = product.ReorderLevel;
            Discontinued = product.Discontinued;
            ProductType = product.ProductType;

                
            if (ProductType != null)
            {
                if (ProductType.Contains("FoodAndBeverageItems"))
                {
                    FoodNBeverageViewModel Foods = new FoodNBeverageViewModel(product);
                    ProductDetail = Foods.convertToDictionary();
                    
                }
                if (ProductType.Contains("GarmentItems"))
                {
                    GarmentViewModel Garment = new GarmentViewModel(product);
                    ProductDetail = Garment.convertToDictionary();
                }
                if (ProductType.Contains("MaterialItems"))
                {
                    MaterialViewModel Material = new MaterialViewModel(product);
                    ProductDetail = Material.convertToDictionary();
                }
                if (ProductType.Contains("TransportationServices"))
                {
                    TransportationServicesViewModel Transport = new TransportationServicesViewModel(product);
                    ProductDetail = Transport.convertServiceToDictionary();
                }
            }
            
        }
        
        
        

        public Product convertToProduct(string condition = "", int? userDemand = 0, decimal? duration = 0)
        {
            var description = "";
            decimal? price = 0;
            var config = new MapperConfiguration(con => { });
            var mapper = new Mapper(config);

            if (this.ProductType.Contains("FoodAndBeverageItems"))
            {
                FoodNBeverageViewModel Foods = mapper.Map<FoodNBeverageViewModel>(this.ProductDetail);
                description = Foods.convertToString();
                price = Foods.CalculateProductUnitPrice();
            }
            else if (this.ProductType.Contains("MaterialItems"))
            {
                MaterialViewModel material = mapper.Map<MaterialViewModel>(this.ProductDetail);
                description = material.convertToString();
                price = material.CalculateProductUnitPrice();
            }
            else if (this.ProductType.Contains("GarmentItems"))
            {
                GarmentViewModel garment = mapper.Map<GarmentViewModel>(this.ProductDetail);
                description = garment.convertToString();
                price = garment.CalculateProductUnitPrice();
            }
            else if (this.ProductType.Contains("TransportationServices"))
            {
                TransportationServicesViewModel transport = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                description = transport.convertServiceToString();
                price = transport.CalculateProductUnitPrices(condition, userDemand, 0);
            }
            else if (this.ProductType.Contains("TelecommunicationServices"))
            {
                TelecomunicationServicesViewModel telecommunications = mapper.Map<TelecomunicationServicesViewModel>(this.ProductDetail);
                description = telecommunications.convertServiceToString();
                price = telecommunications.CalculateProductUnitPrices("", 0, duration);
            }

            return new Product()
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                SupplierID = this.SupplierID,
                CategoryID = this.CategoryID,
                QuantityPerUnit = this.QuantityPerUnit,
                UnitPrice = price,
                UnitsInStock = this.UnitsInStock,
                UnitsOnOrder = this.UnitsOnOrder,
                ReorderLevel = this.ReorderLevel,
                Discontinued = this.Discontinued,
                ProductType = this.ProductType,
                ProductDetail = description
            };
        }
    }
}