using System;

namespace SaadiaInventorySystem.Model
{
    public class OldPart
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Rem { get; set; }
        public string PartNumber { get; internal set; }
        public int IsActive { get; internal set; }
        public DateTime DateUpdate { get; internal set; }
        public DateTime DateCreated { get; internal set; }
    }
}
