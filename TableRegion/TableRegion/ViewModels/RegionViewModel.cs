using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class RegionViewModel
    {
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionLongitude { get; set; }
        public string RegionLatitude { get; set; }
        public string Country { get; set; }

        public RegionViewModel()
        {

        }

        public RegionViewModel(Region entity)
        {
            string tamp = entity.RegionDescription;
            RegionID = entity.RegionID;
            

            if (tamp.Contains("|"))
            {
                var spl = tamp.Split('|');

                RegionName = spl[0].Trim();
                RegionLongitude = spl[1].Trim();
                RegionLatitude = spl[2].Trim();
                Country = spl[3].Trim();
            }
            else
            {
                RegionName = entity.RegionDescription.Trim();
                RegionLongitude = null;
                RegionLatitude = null;
                Country = null;
            }
        }
    }
}