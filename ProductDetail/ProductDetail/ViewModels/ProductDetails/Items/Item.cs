using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels.ProductDetails.Items
{
    public abstract class Item : ProductsDetails
    {
        public Item(char Delimeter = '|') : base(Delimeter)
        {
        }

        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string UnitOfMeasurement { get; set; }

        public override void setAdditionalParameter(ProductDetailCalculatorParameter parameter)
        {
        }

        public override decimal calculateProductCost()
        {
            return decimal.Parse(this.CostRate);
        }
    }
}