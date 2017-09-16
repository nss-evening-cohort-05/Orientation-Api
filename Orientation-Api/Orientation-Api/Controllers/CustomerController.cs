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


         // POST api/<controller>
        [HttpPost, Route("NewCustomer")]
        public HttpResponseMessage AddNewCustomer(Customer customer)
        {
            try
            {
                var customerDataAccess = new CustomerDataAccess();
                var rowUpdate = customerDataAccess.NewCustomer(customer);
                if (rowUpdate == 1)
                    return Request.CreateResponse(HttpStatusCode.OK, "New customer added ");
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error Add new customer");
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

            }
        }

        

        // change the customer state to InActive
        // PUT api/<controller>/5
        [HttpPut, Route("InActive/{Id}")]
        public HttpResponseMessage Put(int Id)
        {
            try
            {
                var InActiveCustomer = new CustomerDataAccess();
                var UpdatedRows = InActiveCustomer.CustomerInactive(Id);
                if (UpdatedRows == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Customer with the Id {Id} was not found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK , $"Customer with the Id {Id} is Now INACTIVE ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

    //--------------------------------------------------------
        // change the customer state back to Active
        // PUT api/<controller>/5
        [HttpPut, Route("Active/{Id}")]
        public HttpResponseMessage Put2(int Id)
        {
            try
            {
                var ActiveCustomer = new CustomerDataAccess();
                var UpdatedRows = ActiveCustomer.CustomerActive(Id);
                if (UpdatedRows == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Customer with the Id {Id} was not found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Customer with the Id {Id} is Now Active");
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