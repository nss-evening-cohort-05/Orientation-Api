using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess
    {
        public class IntRepository : IRepository<int>
        {
            public List<int> GetAll()
            {
                throw new NotImplementedException();
            }

            public void InactivateCustomer(int entitytoUpdate)
            {
                var newStatus = 0;
                using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
                {
                    connection.Open();

                    var result = connection.QueryFirstOrDefault<CustomerListResult>(
                        "Update Customer set Active = @newStatus Where CustomerId = @CustomerId",
                        new { CustomerId = @entitytoUpdate, Active = @newStatus });

                }
            }

        }
    }

    public interface IRepository<T>
    {
        List<T> GetAll();
        void InactivateCustomer(T entityToUpdate);
    }
}