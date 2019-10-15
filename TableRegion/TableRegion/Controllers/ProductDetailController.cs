using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TableRegion.EntityFrameworks;
using TableRegion.ViewModels;

namespace TableRegion.Controllers
{
    [RoutePrefix("productDetail")]
    public class ProductDetailController : ApiController
    {
        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll(int? productID = null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    try
                    {
                        var temp = db.Products.AsQueryable();
                        List<ProductDetailViewModel> listProduct = new List<ProductDetailViewModel>();
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        if (productID != null)
                        {
                            temp = temp.Where(data => data.ProductID == productID);
                        }
                        
                        foreach (var item in temp)
                        {
                            ProductDetailViewModel productDet = new ProductDetailViewModel(item);

                            listProduct.Add(productDet);
                        };
                        result.Add("Data", listProduct);

                        return Ok(result);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult CreateItems( [FromBody] ProductDetailViewModel databody, string condition = "", int? userDemand = 0, decimal? duration = 0)
        {
            using(var db = new DB_Context())
            {
                try
                {
                    Product product = databody.convertToProduct();
                    if (condition != "" && userDemand != 0)
                    {
                        product = databody.convertToProduct(condition, userDemand, 0);
                    }
                    else if (duration != 0)
                    {
                        product = databody.convertToProduct("", 0, duration);
                    }
                    else
                    {
                        product = databody.convertToProduct("", 0, 0);
                    }
                    db.Products.Add(product);
                    db.SaveChanges();

                    return Ok("sip");
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult DeleteItems(int? ProductID)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Product product = db.Products.Where(data => data.ProductID == ProductID).FirstOrDefault();

                    db.Products.Remove(product);
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

        [Route("getCostCalculation")]
        [HttpGet]

        public IHttpActionResult GetCostCalculation(string condition, int userDemand)
        {
            using(var db = new DB_Context())
            {
                try
                {
                        var temp = db.Products.AsQueryable();
                        List<CostCalculationViewModel> listProduct = new List<CostCalculationViewModel>();
                        Dictionary<string, object> result = new Dictionary<string, object>();
                        temp = temp.Where(data => data.ProductType.Contains("TransportationServices"));
                        
                        var listCostEntity = temp.AsEnumerable().ToList();
                        foreach (var item in listCostEntity)
                        {
                            CostCalculationViewModel productDet = new CostCalculationViewModel(item, condition, userDemand );

                            listProduct.Add(productDet);
                        };
                        result.Add("Data", listProduct);

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