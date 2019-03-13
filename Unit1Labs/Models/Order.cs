using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unit1Labs.Models;

namespace Unit1Labs.Models
{
    public class Order
    {
        public Products Prod { get; set; }
        public int Qty { get; set; }
        
    }
}