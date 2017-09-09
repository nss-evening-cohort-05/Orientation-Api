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
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
    //--------------------------------------------------------------------------
        // change the customer state to InActive
        // PUT api/<controller>/5
        [HttpPut, Route("{Id}")]
        public HttpResponseMessage Put(int Id)
        {
            try
            {
                var UpdatingStatus = new CustomerDataAccess();
                var UpdatedRows = UpdatingStatus.CustomerInactive(Id);
                if (UpdatedRows == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Customer with the Id {Id} was not found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK , "Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
//----------------------------------------------------
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}