using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Model
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoiceItem> Item { get; set; }
        public DateTime DateCreated { get; internal set; }
        public DateTime DateUpdated { get; internal set; }
    }
}
