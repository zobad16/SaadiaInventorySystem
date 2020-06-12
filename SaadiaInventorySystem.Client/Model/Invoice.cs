using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int ItemInventoryId { get; set; }
        public List<Inventory> ItemInventory { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

    }
}
