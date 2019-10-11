using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TableRegion.EntityFrameworks;
using TableRegion.ViewModels;

namespace TableRegion.Controllers
{
    [RoutePrefix("region")]
    public class RegionController : ApiController
    {
        [Route("create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] RegDetailViewModel databody){
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<RegDetailViewModel> listRegion = new List<RegDetailViewModel>();
                    var temp = databody.convertToRegion();
                    db.Regions.Add(temp);
                    db.SaveChanges();
                    var reg = db.Regions.Where(data => data.RegionID == databody.RegionID).AsEnumerable().ToList();
                    foreach (var item in reg)
                    {
                        RegDetailViewModel regView = new RegDetailViewModel(item);
                        listRegion.Add(regView);
                    }

                    databody.insTeritory(db);
                    result.Add("Data", listRegion);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Update ([FromBody] RegDetailViewModel databody)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<RegDetailViewModel> regUpdate = new List<RegDetailViewModel>();
                    Region region = db.Regions.Find(databody.RegionID);
                    databody.updateRegion(region);
                    var reg = db.Regions.Where(data => data.RegionID == databody.RegionID).AsEnumerable().ToList();
                    foreach (var item in reg)
                    {
                        RegDetailViewModel regView = new RegDetailViewModel(item);
                        regUpdate.Add(regView);
                    }
                    db.SaveChanges();
                    result.Add("Data", regUpdate);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("delete")]
        [HttpDelete]

        public IHttpActionResult Delete(int regionID)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Region region = db.Regions.Where(data => data.RegionID == regionID).FirstOrDefault();

                    db.Regions.Remove(region);
                    db.SaveChanges();

                    result.Add("Message", "Delete data success");
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll(int? regionID = null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    var temp = db.Regions.AsQueryable();
                    List<RegionViewModel> listRegion = new List<RegionViewModel>();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    if (regionID != null)
                    {
                        temp = temp.Where(data => data.RegionID == regionID);
                    }
                    var listRegionEntity = temp.AsEnumerable().ToList();
                    foreach (var item in listRegionEntity)
                    {
                        RegionViewModel regionDesc = new RegionViewModel(item);

                        listRegion.Add(regionDesc);
                    };
                    result.Add("Data", listRegion);
                    return Ok(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


    }
}