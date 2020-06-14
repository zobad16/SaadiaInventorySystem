using System.ComponentModel.DataAnnotations;

namespace SaadiaInventorySystem.Model
{
    public class InvoiceItem
    {
        [Required]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [Required]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int Qty { get; set; }
        
    }
}
