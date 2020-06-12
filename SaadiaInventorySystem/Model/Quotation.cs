using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Model
{
    public class Quotation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Order> Orders { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
