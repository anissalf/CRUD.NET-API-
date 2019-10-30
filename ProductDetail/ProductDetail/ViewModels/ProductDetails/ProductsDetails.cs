using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductDetail.ViewModels;

namespace ProductDetail.ViewModels.ProductDetails
{
    public abstract class ProductsDetails : IProductDetail, IProductDetailCalculator
    {
        public readonly decimal RateCalculation = (decimal)(110.00 / 100.00);
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string CostRate { get; set; }
        public char Delimeter { get; set; }

        public ProductsDetails()
        {

        }
        public ProductsDetails(char Delimeter)
        {
            this.Delimeter = Delimeter;
        }

        public decimal getDecCostRate()
        {
            return this.RateCalculation;
        }

        public string appendWithDelimiter(params object[] listParam)
        {
            string result = "";
            char delimiter = (char)0;

            foreach (object param in listParam)
            {
                result += delimiter + param.ToString();
                delimiter = this.Delimeter;
            }

            return result;
        }

        public abstract string ConvertToString();
        public abstract Dictionary<string, object> ConvertToDictionary();
        public abstract void setAdditionalParameter(ProductDetailCalculatorParameter parameter);
        public abstract decimal calculateProductCost();
    }
}