using System;

namespace SaadiaInventorySystem.Model
{
    public class InquiryItem
    {
        public int InquiryId { get; set; }
        public int InventoryItem { get; set; }
        public double OfferedPrice { get; set; }
        public int OfferedQty { get; set; }
        public double Total { get; set; }
        public int IsActive { get; set; }
        public Inquiry Inquiry { get; set; }
        public Inventory Inventory { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }
        
    }
}