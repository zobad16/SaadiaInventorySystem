using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
