using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableRegion.EntityFrameworks;

namespace TableRegion.ViewModels
{
    public class RegDetailViewModel
    {
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionLongitude { get; set; }
        public string RegionLatitude { get; set; }
        public string Country { get; set; }

        public RegDetailViewModel()
        {

        }

        public RegDetailViewModel (Region region)
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

        public Territory insTeritory(DB_Context db)
        {
                if (this.Country.Contains("INA"))
                {
                    var tet = db.Regions.Where(data => data.RegionID == this.RegionID).AsEnumerable().ToList();
                    Territory desc_terito = new Territory()
                    {
                        TerritoryID = "INA-01",
                        TerritoryDescription = "Bandung salah satunya",
                        RegionID = RegionID
                    };

                    db.Territories.Add(desc_terito);
                    db.SaveChanges();
                }
            return new Territory();
        }


      }
     }
    
