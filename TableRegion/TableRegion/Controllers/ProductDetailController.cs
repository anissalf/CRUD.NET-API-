﻿using System;
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
        public IHttpActionResult ReadAll(int? productID = null, char? deli = null)
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
                            ProductDetailViewModel productDet = new ProductDetailViewModel(item, deli);

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
        public IHttpActionResult CreateItems( [FromBody] ProductDetailViewModel databody, string condition = "", int? userDemand = 0, decimal? duration = 0, char? deli=null)
        {
            using(var db = new DB_Context())
            {
                try
                {
                    ProductDetailViewModel prodDetail = new ProductDetailViewModel();
                    Product product = databody.convertToProduct(condition, userDemand, duration, deli);
                    db.Products.Add(product);
                    db.SaveChanges();

                    return Ok("Insert Data Success");
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