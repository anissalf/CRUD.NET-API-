using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDetail.ViewModels.ProductDetails
{
    interface IProductDetail
    {
        string ConvertToString();
        Dictionary<string, object> ConvertToDictionary();
    }
}