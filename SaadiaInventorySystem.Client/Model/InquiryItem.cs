using SaadiaInventorySystem.Client.Util;
namespace SaadiaInventorySystem.Client.Model
{
    public class InquiryItem : BaseViewModel
    {
        private int _inquiryId;
        private int _inventoryId;
        private double _offeredPrice;
        private int _offeredQty;
        private double _total;
        private int _isActive;
        private Inquiry _inquiry;
        private Inventory _inventory;
        private double _vat;
        public int InquiryId { get => _inquiryId; set { _inquiryId = value; RaisePropertyChanged(); } }
        public int InventoryId { get => _inventoryId; set { _inventoryId = value; RaisePropertyChanged(); } }
        public double OfferedPrice { get => _offeredPrice; set { _offeredPrice = value; RaisePropertyChanged();} }
        public int OfferedQty { get => _offeredQty; set { _offeredQty = value; RaisePropertyChanged(); } }
        public double Vat { get => _vat; set { _vat = value; RaisePropertyChanged(); } }
        public double Total { get => _total; set { _total = value; RaisePropertyChanged(); } }
        public int IsActive { get => _isActive; set { _isActive = value; RaisePropertyChanged(); } }
        public Inquiry Inquiry { get => _inquiry; set { _inquiry = value; RaisePropertyChanged(); } }
        public Inventory Inventory { get => _inventory; set { _inventory = value; RaisePropertyChanged(); } }

        public void CalculateTotal()
        {
            Total = (OfferedPrice * OfferedQty);
        }
    }
}
