using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableRegion.ViewModels
{
    public interface ServicesViewModel
    {
        string convertServiceToString();
        Dictionary<string, object> convertServiceToDictionary();
        decimal? CalculateProductUnitPrices(string condition = "", int? userDemand = 0, decimal? duration = 0);
    }
}