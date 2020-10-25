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
        private double vat;
        private double vat_percent;

        public double VatPercent
        {
            get { return vat_percent; }
            set { vat_percent = value; RaisePropertyChanged(); }
        }

        public double Vat
        {
            get { return vat; }
            set { vat = value; RaisePropertyChanged(); }
        }

        public int OrderId { get => orderid; set { orderid = value; RaisePropertyChanged(); } }
        public Order Order { get => order; set { order = value; RaisePropertyChanged(); } }
        public int OrderQty { get => orderqty; set { orderqty = value; RaisePropertyChanged(); } }
        public int InventoryId { get => inventoryId; set { inventoryId = value; RaisePropertyChanged(); } }
        public Inventory Inventory { get => inventory; set { inventory = value; RaisePropertyChanged(); } }
        public double OfferedPrice { get => offeredPrice; set { offeredPrice = value; RaisePropertyChanged(); } }
        public double Total { get => total; set { total = value; RaisePropertyChanged(); } }
        
        public int IsActive { get; internal set; }

        public void CalculateTotal()
        {
            total = OrderQty * OfferedPrice;
        }
        public void CalculateVAT()
        {
            CalculateTotal();
            if (VatPercent == 0)
                VatPercent = 8;
            if (VatPercent > 0)
            {
                vat = total * vat_percent / 100;
            }
            else
                vat = 0.0;

        }

    }
}
