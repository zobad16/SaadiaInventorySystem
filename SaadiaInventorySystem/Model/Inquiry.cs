using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Model
{
    public class Inquiry
    {
        public int Id { get; set; }
        public string Ms { get; set; }
        public string Attn { get; set; }
        public string InquiryNumber { get; set; }
        public string Message { get; set; }
        public string Note { get; set; }
        public double Discount { get; set; }
        public double VatPercent { get; set; }
        public double Vat { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<InquiryItem> Items { get; set; } 
        public int IsActive { get; set; }

    }
}
