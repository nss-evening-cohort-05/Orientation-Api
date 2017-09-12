using Orientation_Api.DataAccess;
using Orientation_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orientation_Api.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        
        // POST: Add new product  Route: api/Product/newProduct 
        [HttpPost, Route("newProduct")]
        public HttpResponseMessage AddNewProduct(Product product)
        {
            try
            {
                var productDatabase = new ProductDatabase();
                if (productDatabase.newProduct(product) > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, "New product added");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error add new product"); 
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Server Error" , ex);
            }

        }
               
    }
}
