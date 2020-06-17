using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class OldPart : BaseViewModel
    {
        private int id;
        private string rem;
        private string location;
        private string partNumber;
        private string description;
        

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public string PartNumber { get => partNumber; set { partNumber = value; RaisePropertyChanged(); } }
        public string Description { get => description; set { description = value; RaisePropertyChanged(); } }
        public string Location { get => location; set { location = value; RaisePropertyChanged();} }
        public string Rem { get => rem; set { rem = value; RaisePropertyChanged();}}
    }
}