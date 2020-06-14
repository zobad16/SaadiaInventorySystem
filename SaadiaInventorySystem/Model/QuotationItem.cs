using System.ComponentModel.DataAnnotations;

namespace SaadiaInventorySystem.Model
{
    public class QuotationItem
    {
        [Required]
        public int QuotationId { get; set; }
        public Quotation Quotation { get; set; }
        [Required]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int Qty { get; set; }
    }
}
