using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_Api.Models
{
    public class CustomerList
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set; }
        public string Adress { get; set; }
        public Boolean Active { get; set; }
        public int telephone { get; set; }
        public string email { get; set; }
    }
}