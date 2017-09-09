using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using Dapper;


namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess : IRepository<CustomerListResult>
    {

        public List<CustomerListResult> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool InactivateCustomer(int entitytoUpdate)
        {
            var newStatus = 0;
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                connection.Open();

                var successful = connection.Execute("Update Customer set Active = @Active Where CustomerId = @CustomerId",
                    new { CustomerId = entitytoUpdate, Active = newStatus });

                if (successful == 1)
                    return true;
                else
                    return false;

            }
        }

    }

    public interface IRepository<T>
    {
        List<T> GetAll();
        bool InactivateCustomer(int entityToUpdate);
    }
}