using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaadiaInventorySystem.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public int? QuotationId { get; set; }
        public string InvoiceNumber { get; set; }
        public string QuotationNumber { get; set; }
        public int ? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string OrderPurchaseNumber { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double OfferedDiscount { get; set; }
        public double VAT { get; set; }
        public string MS { get; set; }
        public string Attn { get; set; }
        public string Note { get; set; }
        public string Message { get; set; }
        public int IsActive { get; set; }
        public bool Confirmation { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        [NotMapped]
        public double Total { get; set; }
        
        
    }
}
