using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaadiaInventorySystem.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        
        [Column(TypeName = "decimal(5, 2)")]
        public decimal UnitPrice { get; set; }
        public int AvailableQty { get; set; }
        public string Rem { get; set; }
        public int ? OldPartFK { get; set; }
        public OldPart? OldPart { get; set; }

        public DateTime DateUpdate { get; internal set; }
        public DateTime DateCreated { get; internal set; }
        public int IsActive { get; internal set; }
    }
}
