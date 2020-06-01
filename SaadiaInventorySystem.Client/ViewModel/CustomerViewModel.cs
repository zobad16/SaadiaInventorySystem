using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        public Customer Customer { get; set; }
        public CustomerViewModel(Customer _customer)
        {
            Customer = _customer;
        }
    }
}
