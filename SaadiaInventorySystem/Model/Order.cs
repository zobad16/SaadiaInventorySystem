using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int IsActive { get; internal set; }
    }
}
