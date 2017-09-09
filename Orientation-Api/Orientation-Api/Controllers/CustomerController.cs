using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using Orientation_Api.DataAccess;
using Orientation_Api.Models;

namespace Orientation_Api.Controllers
{
    [RoutePrefix("api/Customer")]

    public class CustomerController : ApiController
    {
        //-------------------------------------------------------------------------
        // GET api/<controller>
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var CustomerData = new CustomerDataAccess();
                var AllCustomerList = CustomerData.GetAllCustomers();
                return Request.CreateResponse(HttpStatusCode.OK, AllCustomerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //-------------------------------------------------------------------------
        // GET api/<controller>/5    
        public string Get(int id)
        {
            return "value";
        }

        //--------------------------------------------------------------------------
        // PUT api/<controller>
        [HttpPut, Route("{Id}/LastName/{LastName}")]
        public HttpResponseMessage Put(int id, string LastName)
        {
            try
            {
                var customerDataAccess = new CustomerDataAccess();
                var rowUpdate = customerDataAccess.CustomerUpdateLastName(id, LastName);
                if (rowUpdate == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, "Last name update");
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        //--------------------------------------------------------------------------
        // change the customer state to InActive
        // PUT api/<controller>/5
        [HttpPut, Route("{Id}")]
        public void Put(int id)
        {
            try
            {
                var UpdatingStatus = new CustomerDataAccess();
                UpdatingStatus.CustomerInactive(id);
                Request.CreateResponse(HttpStatusCode.OK);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        //----------------------------------------------------
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}