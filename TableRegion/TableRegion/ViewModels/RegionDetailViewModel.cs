using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class RegionDetailViewModel
    {
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionLongitude { get; set; }
        public string RegionLatitude { get; set; }
        public string Country { get; set; }


        private RegionDetailViewModel()
        {

        }
        public RegionDetailViewModel(Region region)
        {
            char[] delimiter = { '|' };
            this.RegionID = region.RegionID;

            if (!string.IsNullOrEmpty(region.RegionDescription))
            {
                String[] regionDetailData = region.RegionDescription.Split(delimiter);

                if (regionDetailData.Length == 4)
                {
                    this.RegionName = regionDetailData[0];
                    this.RegionLongitude = regionDetailData[1];
                    this.RegionLatitude = regionDetailData[2];
                    this.Country = regionDetailData[3];
                }
            }
        }
        public Region convertToRegion()
        {
            char[] delimiter = { '|' };
            return new Region()
            {
                RegionID = this.RegionID,
                RegionDescription =
                    this.RegionName + delimiter[0] +
                    this.RegionLongitude + delimiter[0] +
                    this.RegionLatitude + delimiter[0] +
                    this.Country,
            };
        }
    }
}