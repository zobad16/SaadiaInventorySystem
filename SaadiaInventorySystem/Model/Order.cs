using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Model
{
    public class Order
    {
        public int Id { get; set; }
        public List<InvoiceItem> OrderItems { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
