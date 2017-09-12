using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        [HttpGet, Route("all")]
        public HttpResponseMessage Get()
        {
            throw new NotImplementedException();
        }

        [HttpPut, Route("")]
        public HttpResponseMessage Put()
        {
            throw new NotImplementedException();
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Post()
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("")]
        public HttpResponseMessage Delete()
        {
            throw new NotImplementedException();
        }
    }
}
