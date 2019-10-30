using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels.ProductDetails
{
    interface IProductDetailCalculator 
    {
        void setAdditionalParameter(ProductDetailCalculatorParameter parameter);
        decimal calculateProductCost();
        
    }
}