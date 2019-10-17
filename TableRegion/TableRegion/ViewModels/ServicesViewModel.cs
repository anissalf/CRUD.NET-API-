using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableRegion.ViewModels
{
    public interface ServicesViewModel
    {
        char delimiter();
        string convertServiceToString();
        Dictionary<string, object> convertServiceToDictionary();
        decimal? CalculateProductUnitPrices(string condition = null, int? userDemand = null, decimal? duration = null);
    }
}