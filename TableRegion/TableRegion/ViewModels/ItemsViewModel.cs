using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableRegion.ViewModels
{
    public interface ItemsViewModel 
    {
        char delimiter(char? deli);
        string convertToString(char? deli);
        Dictionary<string, object> convertToDictionary();
        decimal CalculateProductUnitPrice();

    }
}