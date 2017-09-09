using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using WebApplication1.DataAccess;
using WebApplication1.Models;
//using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    //customer
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        //public object Request { get; private set; }

        //customers
        [HttpGet, Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var customerData = new CustomerDataAccess();
                var customers = customerData.GetAll();

                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Query didn't work ...");
            }
        }
    }
}