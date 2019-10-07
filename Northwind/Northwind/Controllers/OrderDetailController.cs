using Northwind.EntityFrameworks;
using Northwind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Northwind.Controllers
{
    [RoutePrefix("orderDetail")]
    public class OrderDetailController : ApiController
    {
        [Route("filterOrder")]
        [HttpGet]
        public IHttpActionResult OrderDetail(int? OrderID = null)
        {
           

            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    List<OrderDetailViewModel> productDetail = new List<OrderDetailViewModel>();
                    var dataOrders = db.Orders.AsQueryable();
                    if(OrderID != null)
                    {
                        dataOrders = dataOrders.Where(data => data.OrderID == OrderID);
                    }

                    var listOrder = dataOrders.AsEnumerable().ToList();

                    foreach (var item in listOrder)
                    {
                        OrderDetailViewModel productList = new OrderDetailViewModel()
                        {
                            OrderID = item.OrderID,
                            ContactName = item.Customer.ContactName,
                            ProductList = item.Order_Details.ToList().Select(data => new ProductListViewModel(data)).ToList(),
                            GrandTotal = item.Order_Details.ToList().Select(data => new ProductListViewModel(data)).ToList().Sum(data => data.Total)
                        };
                        productDetail.Add(productList);
                      
                    }
                    
                    result.Add("Message", "Read Data Success");
                    result.Add("Data", productDetail);

                    return Ok(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    internal class OrderDetailViewModels
    {
        public OrderDetailViewModels()
        {
        }
    }
}