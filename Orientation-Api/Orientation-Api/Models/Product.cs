﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orientation_Api.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int Inventory { get; set; }
        public bool Stock { get; set; }
    }
}