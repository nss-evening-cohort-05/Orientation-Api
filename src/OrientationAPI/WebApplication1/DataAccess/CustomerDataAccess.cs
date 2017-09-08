﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class CustomerDataAccess : IRepository<CustomerListResult>
    {
        public List<CustomerListResult> GetAll()
        {
            using (var connection =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["Bangazon"].ConnectionString))
            {

                connection.Open();

                var result = connection.Query< CustomerListResult>
                                              ("select * from Customer");

                return result.ToList();
            }
        }
    }

    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}