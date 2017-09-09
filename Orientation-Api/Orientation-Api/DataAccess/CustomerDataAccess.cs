using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using Dapper;
using Orientation_Api.Models;

namespace Orientation_Api.DataAccess
{
    public class CustomerDataAccess
    {
    //------------------------------------------------------------------------
        //get all the customer data
        public List<Customer> GetAllCustomers()
        {
            using (var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                Connection.Open();
                var result = Connection.Query<Customer>("select * from Customer where Active = 1");
                return result.ToList();
            }
        }
    //------------------------------------------------------------------------
        //update the customer state to be Inactive by passing the customerId
        public int CustomerInactive(int CustomerId)
        {
             using ( var Connection = new SqlConnection (ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
             {
                Connection.Open();
                var Result = Connection.Execute("update Customer set Active = 'false' where CustomerId = @Id",
                                                  new { Id = CustomerId });
                return Result;
             }
        }
    //--------------------------------------------------------------------------
    }
}