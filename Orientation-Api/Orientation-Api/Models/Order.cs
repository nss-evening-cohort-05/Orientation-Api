using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_Api.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal TotalPrice { get; set; }
        public Boolean Paid { get; set; }

    }
}