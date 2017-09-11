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
    public class OrderDatabase 
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString;

        public int newOrder (Order order)
        {
             var sql = @"Insert into [dbo].[Order]
                                (CustomerId
                                ,OrderDate
                                ,TotalPrice
                                ,Paid
                                )
                                values
                                (@customerId
                                ,CURRENT_TIMESTAMP
                                ,@totalPrice
                                ,@paid)";


            using (var connection = new SqlConnection(connectionString))
            {

                var rowsInsert = connection.Execute(sql, new {customerId = order.CustomerId
                                                            , totalPrice = order.TotalPrice
                                                            , paid       = order.Paid
                                                              });

                return rowsInsert;

            }
        }

        public Order viewOrder(int orderId)
        {
            var sqlOrder = @"SELECT OrderId
                      , CustomerId
                      , OrderDate
                      , TotalPrice
                      , Paid
                   FROM [dbo].[Order]
                  WHERE [Order].OrderId = @orderId";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Order>(sqlOrder, new { orderId = orderId }).FirstOrDefault();
            }
        }

        public List<Order> listOrder()
        {
            var sqlOrder = @"SELECT OrderId
                      , CustomerId
                      , OrderDate
                      , TotalPrice
                      , Paid
                   FROM [dbo].[Order]";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Order>(sqlOrder).ToList();
            }
        }

        public List<Order> outstandingOrders()
        {
            var sqlOrder = @"SELECT OrderId
                      , CustomerId
                      , OrderDate
                      , TotalPrice
                      , Paid
                   FROM [dbo].[Order]
                  WHERE Paid = 'false'";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Order>(sqlOrder).ToList();
            }
        }
    }
}