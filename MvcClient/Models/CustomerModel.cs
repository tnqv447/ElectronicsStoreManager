using System;
using System.Collections.Generic;
using AppCore.Models;

namespace MvcClient.Models
{
    public class CustomerModel
    {
        public Customer Customer { get; set; } = null;
        public IList<Order> Orders { get; set; }
    }
}