using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [HttpGet, Route("all")]
        public HttpResponseMessage Get()
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("")]
        public HttpResponseMessage Put()
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Post()
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage Delete()
        {
            throw new NotImplementedException();
        }
		[HttpGet, Route("status")]
		public HttpResponseMessage GetProductStatus(int id)
		{
			using (var connection =
				new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
			{
				try
				{

					var ProductData = new ProductDataAccess();
					var ProductStatus = ProductData.CheckStock(id);
					
					return Request.CreateResponse(HttpStatusCode.OK, ProductStatus);
				}
				catch (Exception ex)
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
				}
			}
		}
	}
}
