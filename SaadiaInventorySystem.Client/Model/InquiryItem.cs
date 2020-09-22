using SaadiaInventorySystem.Client.Util;
namespace SaadiaInventorySystem.Client.Model
{
    public class InquiryItem : BaseViewModel
    {
        private int _inquiryId;
        private int _inventoryItem;
        private double _offeredPrice;
        private int _offeredQty;
        private double _total;
        private int _isActive;
        private Inquiry _inquiry;
        private Inventory _inventory;

        public int InquiryId { get => _inquiryId; set { _inquiryId = value; RaisePropertyChanged(); } }
        public int InventoryItem { get => _inventoryItem; set { _inventoryItem = value; RaisePropertyChanged(); } }
        public double OfferedPrice { get => _offeredPrice; set { _offeredPrice = value; RaisePropertyChanged();} }
        public int OfferedQty { get => _offeredQty; set { _offeredQty = value; RaisePropertyChanged(); } }
        public double Total { get => _total; set { _total = value; RaisePropertyChanged(); } }
        public int IsActive { get => _isActive; set { _isActive = value; RaisePropertyChanged(); } }
        public Inquiry Inquiry { get => _inquiry; set { _inquiry = value; RaisePropertyChanged(); } }
        public Inventory Inventory { get => _inventory; set { _inventory = value; RaisePropertyChanged(); } }

    }
}
