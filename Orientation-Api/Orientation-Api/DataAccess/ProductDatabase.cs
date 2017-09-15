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
                                   ,Inventory
                                   ,Stock)
                             VALUES
                                   (@ProductName
                                   ,@ProductPrice
                                   ,@ProductDescription
                                   ,@Invetory
                                   ,@Stock)";


            using (var connection = new SqlConnection(connectionString))
            {

                return connection.Execute(sql, new
                {
                    ProductName = product.ProductName
                   ,
                    ProductPrice = product.ProductPrice
                   ,
                    ProductDescrition = product.ProductDescription
                   ,
                    Inventory = product.Inventory
                   ,
                    Stock = product.Stock
                });

            }
        }

        public int ProductStock(int ProductId)
        {
            using (var Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {
                Connection.Open();
                var ReturnValue =  Connection.ExecuteScalar<int>("update Product set Stock = ( Case Stock When 'true' Then 'false' " +
                    "                           When 'false' Then 'true' End)" +
                    "                           OUTPUT inserted.Stock" +
                    "                           Where ProductId = ProductId");
                return ReturnValue;
            }
        }
    }
}


