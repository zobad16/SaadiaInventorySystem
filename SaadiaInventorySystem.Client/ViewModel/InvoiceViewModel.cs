using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InvoiceViewModel : BaseViewModel
    {
        private string _name;

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public InvoiceViewModel()
        {
            Name = "Invoice";
        }
    }
}