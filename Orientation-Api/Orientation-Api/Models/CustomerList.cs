using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_Api.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string telephone { get; set; }
        public string email { get; set; }
    }
}