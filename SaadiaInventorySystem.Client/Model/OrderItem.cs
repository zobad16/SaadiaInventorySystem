using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class OrderItem : BaseViewModel
    {
        private int orderid;
        private Order order;
        private int orderqty;
        private double offeredPrice;
        private double total;
        private int inventoryId;
        private Inventory inventory;
                
        public int OrderId { get => orderid; set { orderid = value; RaisePropertyChanged(); } }
        public Order Order { get => order; set { order = value; RaisePropertyChanged(); } }
        public int OrderQty { get => orderqty; set { orderqty = value; RaisePropertyChanged(); } }
        public int InventoryId { get => inventoryId; set { inventoryId = value; RaisePropertyChanged(); } }
        public Inventory Inventory { get => inventory; set { inventory = value; RaisePropertyChanged(); } }
        public double OfferedPrice { get => offeredPrice; set { offeredPrice = value; RaisePropertyChanged(); } }
        public double Total { get => total; set { total = value; RaisePropertyChanged(); } }
        public void CalculateTotal()
        {
            total = OrderQty * OfferedPrice;
        }

    }
}
