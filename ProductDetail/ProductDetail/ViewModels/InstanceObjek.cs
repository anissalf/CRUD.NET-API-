using ProductDetail.EntityFrameworks;
using ProductDetail.ViewModels.ProductDetails;
using ProductDetail.ViewModels.ProductDetails.Items;
using ProductDetail.ViewModels.ProductDetails.Items.Details;
using ProductDetail.ViewModels.ProductDetails.Services;
using ProductDetail.ViewModels.ProductDetails.Services.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels
{
    public class InstanceObjek
    {
        ProductsDetails productDetail = null;
        public void objekProductDetail(Product product)
        {
            if (productDetail.GetType() == typeof(Item) && productDetail.Delimeter == '|' )
            {
                if (product.ProductType.Equals("FoodAndBeverageItems"))
                {
                    productDetail = new FoodAndBeverage();
                }
                else if (product.ProductType.Equals("MaterialItems"))
                {
                    productDetail = new Material();
                }
                else if (product.ProductType.Equals("GarmentItems"))
                {
                    productDetail = new Garment();
                }
            }
            else if (productDetail.GetType() == typeof(Service) && productDetail.Delimeter == ';')
            {
                if (product.ProductType.Equals("TransportationServices"))
                {
                    productDetail = new Transportation();
                }
                else if (product.ProductType.Equals("TelecommunicationServices"))
                {
                    productDetail = new Telecommunication();
                }
            }

            
        }


    }
}