using SaadiaInventorySystem.Client.Util;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Client.Model
{
    public class Order:BaseViewModel
    {
        private int id;
        private List<OrderItem> orderItems;

        public int Id { get => id; set { id = value; RaisePropertyChanged();}}
        public List<OrderItem> OrderItems { get => orderItems; set { orderItems = value; RaisePropertyChanged(); } }
        
    }
}
