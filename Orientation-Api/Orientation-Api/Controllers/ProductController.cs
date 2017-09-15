using Orientation_Api.DataAccess;
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
        // GET: api/Product
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        [HttpPost, Route("newProduct")]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product
        [HttpPut, Route("Stock/{Id}")]
        public HttpResponseMessage Put(int Id)
        {
            try
            {
                var productDatabase = new ProductDatabase();
                var ZeroStock = productDatabase.ProductStock(Id);
                if (ZeroStock == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Product with the ProductId {Id} was not found");
                }
                else 
                {
                    return Request.CreateResponse(HttpStatusCode.OK, $"Product with the ProductId {Id} is in Stock");

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}