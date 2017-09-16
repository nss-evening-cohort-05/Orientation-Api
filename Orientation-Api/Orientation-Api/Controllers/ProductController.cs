﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using Orientation_Api.DataAccess;
using Orientation_Api.Models;

namespace Orientation_Api.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        // GET: api/Product
        [HttpGet, Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var ProductData = new ProductDatabase();
                var AllProductList = ProductData.GetAllProducts();
                return Request.CreateResponse(HttpStatusCode.OK, AllProductList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }
        // POST: Add new product  Route: api/Product/newProduct 
        [HttpPost, Route("newProduct")]
        public HttpResponseMessage AddNewProduct(Product product)
        {
            try
            {
                var productDatabase = new ProductDatabase();
                if (productDatabase.newProduct(product) > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, "New product added");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error add new product");
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Server Error", ex);
            }

        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}