using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Northwind.EntityFrameworks;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoryController : ApiController
    {
        //endpoint get
        [Route("readAll")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            //membuat koneksi database
            var db = new DB_Context();
            try
            {
                //mengambil data dan merubah menjadi list
                var listCategoryEntity = db.Categories.ToList();
                List<CategoryViewModel> listProduct = new List<CategoryViewModel>();
                Dictionary<string, object> result = new Dictionary<string, object>();

                foreach (var item in listCategoryEntity)
                {
                    CategoryViewModel product = new CategoryViewModel()
                    {
                        CategoryID = item.CategoryID,
                        CategoryName = item.CategoryName,
                        Description = item.Description,
                        Picture = item.Picture
                    };

                    listProduct.Add(product);
                };

                result.Add("Message", "Read Data Success");
                result.Add("Data", listProduct);

                db.Dispose();

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("create")]
        [HttpPost]

        public IHttpActionResult Create([FormBody] CategoryViewModel databody)
        {
            var db = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                Category newCategory = new Category()
                {
                    CategoryID = databody.CategoryID,
                    CategoryName = databody.CategoryName,
                    Description = databody.Description,
                    Picture = databody.Picture
                };

                db.Categories.Add(newCategory);
                db.SaveChanges();

                db.Dispose();

                result.Add("Message", "Insert Data Success");
                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("update")]
        [HttpPut]
        public IHttpActionResult Update([FormBody] CategoryViewModel databody)
        {
            var db = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                Category category = db.Categories.Find(databody.CategoryID);

                category.CategoryID = databody.CategoryID;
                category.CategoryName = databody.CategoryName;
                category.Description = databody.Description;
                category.Picture = databody.Picture;

                db.SaveChanges();

                db.Dispose();

                result.Add("Message", "Update Data Success");
                return Ok(result);
             
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("delete")]
        [HttpDelete]

        public IHttpActionResult Delete(int categoryID)
        {
            var db = new DB_Context();
            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                Category category = db.Categories.Where(data => data.CategoryID == categoryID).FirstOrDefault();
                db.Categories.Remove(category);

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
}