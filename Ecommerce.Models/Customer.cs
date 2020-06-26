using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int LoyaltyPoint { get; set; }
    }
}
