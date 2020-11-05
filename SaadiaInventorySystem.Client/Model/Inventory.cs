using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class Inventory : BaseViewModel
    {
        //public Inventory()
        //{
        //    OldPart = new OldPart();
        //}
        private int id;
        private string partNumber;
        private string description;
        private int availableQty;
        private decimal price;
        private string location;
        private string rem;
        private int ?oldPartFK;
        private OldPart oldPart;
        private int isActive;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); }}
        public string PartNumber { get => partNumber; set { partNumber = value; RaisePropertyChanged(); }}
        public string Description { get => description; set { description = value; RaisePropertyChanged(); }}
        public int AvailableQty { get => availableQty; set { availableQty = value; RaisePropertyChanged(); } }
        public decimal UnitPrice { get => price; set { price = value; RaisePropertyChanged(); } }
        public string Location { get => location; set { location = value; RaisePropertyChanged(); } }
        public string Rem { get => rem; set { rem = value; RaisePropertyChanged(); }}
        public OldPart  OldPart { get => oldPart; set {oldPart = value; RaisePropertyChanged(); }}
        public int ? OldPartFK {  get => oldPartFK; set { oldPartFK = value; RaisePropertyChanged(); }}
        public int IsActive { get => isActive; set { isActive = value; RaisePropertyChanged(); } }
    }
}
