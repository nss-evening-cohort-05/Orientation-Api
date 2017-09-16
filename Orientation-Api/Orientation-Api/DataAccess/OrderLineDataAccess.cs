using Orientation_Api.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Configuration;

namespace Orientation_Api.DataAccess
{
    public class OrderLineDataAccess
    {
        //---------------------------------------------------------------------
        //creating order for muliple products
        public int CreateOrderLine(List <LineItem> lineitems)
        {
            var linecnt = 0;
            string ConnectionString = ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString;

            var sql = @"insert into lineitem ( orderid ,productid , quantity) values( @orderid, @productid , @quantity)";
            using (var Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                foreach (var lineitem in lineitems) {

                    linecnt += Connection.Execute(sql, new { orderid = lineitem.OrderId, productid = lineitem.ProductId, quantity = lineitem.Quantity });
                }
                return linecnt;
            }
        }
    };

    //---------------------------------------------------------------------

}
