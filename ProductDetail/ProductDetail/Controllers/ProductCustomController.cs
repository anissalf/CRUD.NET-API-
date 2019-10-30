using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using ProductDetail.ViewModels;
using ProductDetail.ViewModels.Calculation;
using ProductDetail.EntityFrameworks;
using ProductDetail.ViewModels.ProductDetails;

namespace ProductDetail.Controllers
{
    [RoutePrefix("api/ProductDetail")]
    public class ProductCustomController : ApiController
    {
       
        [Route("calculateProductUnitPrice")]
        [HttpPost]
        public IHttpActionResult calculateProductUnitPrice([FromBody] ProductDetailCalculatorParameter parameter)
        {
            try
            {
                using (var db = new DB_context())
                {
                    var temp = db.Products.AsQueryable();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var listProduct = db.Products.OrderByDescending(data => data.ProductID).ToList();

                    ProductCalculator calculator = new ProductCalculator(';');
                    foreach (var item in listProduct)
                    {
                        calculator.calculateProductUnitPrice(item, parameter);
                    }

                    db.SaveChanges();
                    return Ok("Data Saved Successfully");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Route("countInvalid")]
        //[HttpGet]
        //public IHttpActionResult countInvalidProductDetail()
        //{
        //    try
        //    {
        //        using (var db = new DB_context())
        //        {
        //            var temp = db.Products.AsQueryable().ToList();
        //            Dictionary<string, object> result = new Dictionary<string, object>();
        //            ProductValidator productValid = new ProductValidator();
        //            var val = temp.Where(productValid.isValidProductDetail() == false)
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        [Route("createString")]
        [HttpPost]
        public IHttpActionResult CreateProductWithStringProductDetail([FromBody] CreateNReadModel databody)
        {
            using (var db = new DB_context())
            {
                try
                {
                    ProductValidator val = new ProductValidator();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Product product = databody.createProductString();
                    db.Products.Add(product);
                    db.SaveChanges();

                    if (val.isValidProductDetail(product.ProductDetail, product.ProductType) == true)
                    {
                        result.Add("Message", "Insert Data Success");
                    }
                    else
                    {
                        result.Add("Message", "Data is invalid ");
                    }

                    return Ok(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [Route("createDictionary")]
        [HttpPost]
        public IHttpActionResult CreateProductWithProductDetail([FromBody] CreateNReadModel databody)
        {
            using (var db = new DB_context())
            {
                try
                {
                    ProductValidator val = new ProductValidator();
                    //Dictionary<string, ProductViewModel> dict = new Dictionary<string, ProductViewModel>();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    //Product product = dict.Add(, databody);
                    Product product = databody.CreateProductDictionary();
                    db.Products.Add(product);
                    db.SaveChanges();

                    if (val.isValidProductDetail(product.ProductDetail, product.ProductType) == true)
                    {
                        result.Add("Message", "Insert Data Success");
                    }
                    else
                    {
                        result.Add("Message", "Data is invalid ");
                    }

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