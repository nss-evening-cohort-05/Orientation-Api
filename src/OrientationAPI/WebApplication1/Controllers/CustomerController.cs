using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using Dapper;

namespace WebApplication1.Controllers
{
	[RoutePrefix("api/customer")]
	public class CustomerController : ApiController
    {
		[HttpPut, Route("edit")]
		public HttpResponseMessage Put(CustomerListResult customer)
		{
			using (var connection =
				new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
			{
				try
				{
					var customerData = new CustomerDataAccess();
					customerData.Update(customer);
					return Request.CreateResponse(HttpStatusCode.Accepted);

				}
				catch (Exception ex)
				{
					return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);

				}
			}
		}
	}
}
