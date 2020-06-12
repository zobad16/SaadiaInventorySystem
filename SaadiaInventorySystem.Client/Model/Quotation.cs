using SaadiaInventorySystem.Client.Util;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Client.Model
{
    public class Quotation : BaseViewModel
    {
        private int id;
        private int customerId;
        private Customer customer;
        private List<Order> orders;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public int CustomerId { get => customerId; set { customerId = value; RaisePropertyChanged(); } }
        public Customer Customer { get => customer; set { customer = value; RaisePropertyChanged(); } }

        public List<Order> Orders { get => orders; set { orders = value; RaisePropertyChanged();}}


    }
}
