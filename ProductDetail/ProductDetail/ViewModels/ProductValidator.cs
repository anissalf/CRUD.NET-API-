using ProductDetail.EntityFrameworks;
using ProductDetail.ViewModels.ProductDetails;
using ProductDetail.ViewModels.ProductDetails.Items;
using ProductDetail.ViewModels.ProductDetails.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels
{
    public class ProductValidator
    {
        
        public bool isValidProductDetail (ProductsDetails productDetail, string productType)
        {
            InstanceObjek obj = new InstanceObjek();
            var temp = obj.objekProductDetail();
            var hasil = false;
            if (productDetail == temp)
            {
                hasil = true;
            }
            else
            {
                hasil = false;
            }

            return hasil;
        }
        public bool isValidProductDetail(Dictionary<string, object> productDetail, string productType)
        {
            var hasil = false;
            InstanceObjek obj = new InstanceObjek();
            var temp = obj.objekProductDetail();
            if (productType.Equals(temp) && productDetail.Equals(temp))
            {
                hasil = true;
            }

            return hasil;
        }
        public bool isValidProductDetail(string productDetail, string productType)
        {
            var hasil = false;

            

            return hasil;
        }

        
    }
}