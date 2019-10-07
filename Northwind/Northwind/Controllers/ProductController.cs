using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Northwind.EntityFrameworks;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public object Categories { get; private set; }

        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            using (var db = new DB_Context())
            {
                try
                {
                    var listProductEntity = db.Products.ToList();
                    List<ProductViewModel> listProduct = new List<ProductViewModel>();
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    foreach (var item in listProductEntity)
                    {
                        ProductViewModel product = new ProductViewModel()
                        {
                            ProductID = item.ProductID,
                            ProductName = item.ProductName,
                            SupplierID = item.SupplierID,
                            CategoryID = item.CategoryID,
                            QuantityPerUnit = item.QuantityPerUnit,
                            UnitPrice = item.UnitPrice,
                            UnitsInStock = item.UnitsInStock,
                            UnitsOnOrder = item.UnitsOnOrder,
                            ReorderLevel = item.ReorderLevel,
                            Discontinued = item.Discontinued
                        };

                        listProduct.Add(product);

                    };
                    result.Add("Message", "Read Data Success");
                    result.Add("Data", listProduct);

                    return Ok(result);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [Route("create")]
        [HttpPost]

        public IHttpActionResult Create([FormBody] ProductViewModel databody)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Product newProduct = new Product()
                    {
                        ProductID = databody.ProductID,
                        ProductName = databody.ProductName,
                        SupplierID = databody.SupplierID,
                        CategoryID = databody.CategoryID,
                        QuantityPerUnit = databody.QuantityPerUnit,
                        UnitPrice = databody.UnitPrice,
                        UnitsInStock = databody.UnitsInStock,
                        UnitsOnOrder = databody.UnitsOnOrder,
                        ReorderLevel = databody.ReorderLevel,
                        Discontinued = databody.Discontinued
                    };

                    db.Products.Add(newProduct);
                    db.SaveChanges();

                    result.Add("Message", "Insert Data Success");
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

        public IHttpActionResult Update([FormBody] ProductViewModel databody)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Product product = db.Products.Find(databody.ProductID);

                    product.ProductID = databody.ProductID;
                    product.ProductName = databody.ProductName;
                    product.SupplierID = databody.SupplierID;
                    product.CategoryID = databody.CategoryID;
                    product.QuantityPerUnit = databody.QuantityPerUnit;
                    product.UnitPrice = databody.UnitPrice;
                    product.UnitsInStock = databody.UnitsInStock;
                    product.UnitsOnOrder = databody.UnitsOnOrder;
                    product.ReorderLevel = databody.ReorderLevel;
                    product.Discontinued = databody.Discontinued;
                   
                    db.SaveChanges();

                    result.Add("Message", "Update Data Success");
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

        public IHttpActionResult Delete(int prodID)
        {
            var db = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                Product product = db.Products.Where(data => data.ProductID == prodID).FirstOrDefault();
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

        [Route("CustomRead")]
        [HttpGet]
        public IHttpActionResult CustomRead()
        {
            using (var db = new DB_Context())
            {
                //try
                //{
                //    Dictionary<string, object> result = new Dictionary<string, object>();
                //    //var prod_mahal = db.Products.Max(data => data.UnitPrice);
                //    //Product product = db.Products.Where(data => data.UnitPrice == prod_mahal).FirstOrDefault();
                //    Product product = db.Products.OrderByDescending(i => i.UnitPrice).FirstOrDefault();
                //    var prod = new ProductViewModel()
                //    {
                //        ProductID = product.ProductID,
                //        ProductName = product.ProductName,
                //        SupplierID = product.SupplierID,
                //        CategoryID = product.CategoryID,
                //        QuantityPerUnit = product.QuantityPerUnit,
                //        UnitPrice = product.UnitPrice,
                //        UnitsInStock = product.UnitsInStock,
                //        UnitsOnOrder = product.UnitsOnOrder,
                //        ReorderLevel = product.ReorderLevel,
                //        Discontinued = product.Discontinued
                //    };

                //    Product murah = db.Products.OrderBy(i => i.UnitPrice).FirstOrDefault();
                //    var mu = new ProductViewModel()
                //    {
                //        ProductID = murah.ProductID,
                //        ProductName = murah.ProductName,
                //        SupplierID = murah.SupplierID,
                //        CategoryID = murah.CategoryID,
                //        QuantityPerUnit = murah.QuantityPerUnit,
                //        UnitPrice = murah.UnitPrice,
                //        UnitsInStock = murah.UnitsInStock,
                //        UnitsOnOrder = murah.UnitsOnOrder,
                //        ReorderLevel = murah.ReorderLevel,
                //        Discontinued = murah.Discontinued
                //    };

                //    result.Add("Message", "Read Data Success");
                //    result.Add("Produk Termahal", prod);


                //    return Ok(result);

                //}
                //catch (Exception)
                //{

                //    throw;
                //}

                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var mahal = db.Products.Max(data => data.UnitPrice);
                    var prod_mahal = db.Products.Where(mhl => mhl.UnitPrice == mahal).ToList().Select(data => new ProductViewModel(data));

                    IEnumerable<ProductViewModel> prod_murah = db.Products.Where(mrh => mrh.UnitPrice == db.Products.Min(item => item.UnitPrice)).ToList().Select(data => new ProductViewModel(data));
                    IEnumerable<ProductViewModel> prodUnderAvg = db.Products.Where(und => und.UnitPrice < db.Products.Average(item => item.UnitPrice)).ToList().Select(data => new ProductViewModel(data));

                    result.Add("Produk Termahal", prod_mahal);
                    result.Add("Produk Termurah", prod_murah);
                    result.Add("Produk Dibawah Rata-rata", prodUnderAvg);

                    return Ok(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        [Route("filterBy")]
        [HttpGet]
        public IHttpActionResult FilterBy(string ProductName = null, string CategoryName = null, decimal? UnitPrice = null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var temp = db.Products.AsQueryable();

                    if (ProductName != null)
                    {
                        temp = temp.Where(data => data.ProductName.Contains(ProductName.ToLower()));
                    }
                    if (CategoryName !=null)
                    {
                        temp = temp.Where(data => data.Category.CategoryName.ToLower().Contains(CategoryName.ToLower()));
                    }
                    if (UnitPrice != null)
                    {
                        temp = temp.Where(data => data.UnitPrice < UnitPrice);
                    }

                    var listProduct = temp.ToList().Select(data => new ProductViewModel(data));
                    result.Add("Message", "Read Data Success");
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