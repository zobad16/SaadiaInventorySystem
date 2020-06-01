using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class Customer : BaseViewModel
    {
        private string _lastName;

        public string LastName { get => _lastName; set { _lastName = value; RaisePropertyChanged(); } }
    }
}
