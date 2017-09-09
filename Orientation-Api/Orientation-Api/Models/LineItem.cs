using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_Api.Models
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}