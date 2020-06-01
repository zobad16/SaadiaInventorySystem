using System;

namespace SaadiaInventorySystem.Model
{
    public class Quotation
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
