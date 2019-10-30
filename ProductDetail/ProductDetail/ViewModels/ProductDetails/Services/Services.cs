using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels.ProductDetails.Services
{
    public abstract class Service : ProductsDetails
    {
        public ProductDetailCalculatorParameter parameter { get; set; }

        public Service(char Delimeter = ';') : base(Delimeter)
        {
            
        }

        public string CostCalculationMethod { get; set; }

        public override void setAdditionalParameter(ProductDetailCalculatorParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}