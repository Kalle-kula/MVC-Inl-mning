using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Domain.Models;

namespace Project.Web.Models
{
    public class OrderViewModel
    {
        public Order Order { get; set; }

        public List<OrderDetails> OrderDetails { get; set; } 
    }
}