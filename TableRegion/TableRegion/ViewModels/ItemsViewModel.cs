﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableRegion.ViewModels
{
    public interface ItemsViewModel 
    {
        char delimiter();
        string convertToString();
        Dictionary<string, object> convertToDictionary();
        decimal CalculateProductUnitPrice();

    }
}