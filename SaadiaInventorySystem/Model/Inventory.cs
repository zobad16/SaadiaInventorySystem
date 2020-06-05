using System;

namespace SaadiaInventorySystem.Model
{
    public class Inventory
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public string Description { get; set; }
        public int AvailableQty { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Rem { get; set; }
        public OldPart OldPart { get; set; }
        public DateTime DateUpdate { get; internal set; }
        public DateTime DateCreated { get; internal set; }
        public int IsActive { get; internal set; }
    }
}
