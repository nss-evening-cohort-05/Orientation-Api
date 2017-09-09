using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : ApiController
    {

        // PUT api/values/5
        [HttpPut, Route("{id}")]
        public HttpResponseMessage InactivateCustomer(int id, CustomerListResult customer)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName} and {customer.Active}");

            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
