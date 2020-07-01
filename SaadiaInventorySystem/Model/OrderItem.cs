using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Model
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int OrderQty { get; set; }
        public double OfferedPrice { get; set; }
        public double Total { get; set; }
    }
}
