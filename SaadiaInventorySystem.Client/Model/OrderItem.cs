using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class OrderItem : BaseViewModel
    {
        private int id;
        private Inventory part;
        private int qty;
        private Order order;

        public int Id { get => id; set => id = value; }
        public Inventory Part { get => part; set => part = value; }
        public int Qty { get => qty; set => qty = value; }
        public Order Order { get => order; set => order = value; }
    }
}
