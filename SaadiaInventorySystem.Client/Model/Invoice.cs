using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class Invoice : BaseViewModel
    {
        private int id;
        private int customerId;
        private Customer customer;
        private Order order;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public int CustomerId { get => customerId; set { customerId = value; RaisePropertyChanged(); } }
        public Customer Customer { get => customer; set { customer = value; RaisePropertyChanged(); }}
        public Order Order { get => order; set { order = value; RaisePropertyChanged(); } }
    


    }
}
