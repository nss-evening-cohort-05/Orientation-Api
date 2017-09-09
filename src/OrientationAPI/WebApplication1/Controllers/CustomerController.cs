using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {

        // PUT api/values/5
        [HttpPut, Route("{id}")]
        public HttpResponseMessage InactivateCustomer(int id)
        {
            var customerDataAccess = new CustomerDataAccess();
            var MakeInactive = customerDataAccess.InactivateCustomer(id);
            
            if(MakeInactive)
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);

        }
    }
}
