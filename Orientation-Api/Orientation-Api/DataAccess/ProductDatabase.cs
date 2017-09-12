using Orientation_Api.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace Orientation_Api.DataAccess
{
    public class ProductDatabase
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString;

        public int newProduct(Product product)
        {
            var sql = @"INSERT INTO [dbo].[Product]
                                   (ProductName
                                   ,ProductPrice
                                   ,ProductDescription
                                   ,Inventory)
                             VALUES
                                   (@ProductName
                                   ,@ProductPrice
                                   ,@ProductDescription
                                   ,@Inventory)";


            using (var connection = new SqlConnection(connectionString))
            {

                return connection.Execute(sql, new
                {
                    ProductName       = product.ProductName
                   ,ProductPrice      = product.ProductPrice
                   ,ProductDescription = product.ProductDescription
                   ,Inventory         = product.Inventory
                });

            }
        }
    }
}