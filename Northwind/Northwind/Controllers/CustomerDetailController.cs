using Northwind.EntityFrameworks;
using Northwind.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Northwind.Controllers
{
    [RoutePrefix("customer/order")]
    public class CustomerDetailController : ApiController
    {
        [Route("detail")]
        [HttpGet]
        public IHttpActionResult DetailOrder( string CustID = null )
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<CustomerDetailViewModel> custDetail = new List<CustomerDetailViewModel>();
                    var cust = db.Customers.AsQueryable();

                    if ( CustID != null )
                    {
                        cust = cust.Where(data => data.CustomerID == CustID);
                    }
                    var cust_prod = cust.AsEnumerable().ToList();

                    foreach (var item in cust_prod)
                    {
                        CustomerDetailViewModel productCust = new CustomerDetailViewModel()
                        {
                            CustomerID = item.CustomerID,
                            SumOrder = item.Orders.Select(data => data.OrderID).Count(),
                            TotalAll = item.Orders.ToList().Select(data => new CustomerProductViewModel(data)).ToList().Sum(data => data.GrandTotal),
                            CustomerList = item.Orders.ToList().Select(data => new CustomerProductViewModel(data)).ToList(),

                        };

                        custDetail.Add(productCust);

                    }

                    result.Add("Message", "Read Data Success");
                    result.Add("Data", custDetail);

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