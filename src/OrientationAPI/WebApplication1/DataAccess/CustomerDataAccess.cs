using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
     public class CustomerDataAccess : IRepository<CustomerListResult>
		{
            /*public List<int> GetAll()
            {
                throw new NotImplementedException();
            }*/
			public void Update(CustomerListResult customer)
			{
				using (var connection =
				new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
				{
					connection.Open();
					var result = connection.Execute("Update Customer " +
																	"Set FirstName = @firstname, LastName = @lastname " +
																	"Where CustomerId = @customerId", new { FirstName = customer.FirstName, LastName = customer.LastName, CustomerId = customer.CustomerId });
					return;
				}
			}

    }

    public interface IRepository<T>
    {
       /* List<T> GetAll();*/
		void Update(T customer);
	}
}