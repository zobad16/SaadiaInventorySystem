using SaadiaInventorySystem.Client.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SaadiaInventorySystem.Client.Model
{
    public class Order:BaseViewModel
    {
        public Order()
        {
            OrderItems = new ObservableCollection<OrderItem>();
        }
        private int id;
        private ObservableCollection<OrderItem> orderItems;
        private double totalPrice;

        public int Id { get => id; set { id = value; RaisePropertyChanged();}}
        public ObservableCollection<OrderItem> OrderItems { get => orderItems; set { orderItems = value; RaisePropertyChanged(); } }

        public double TotalPrice 
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                RaisePropertyChanged();
            }
        }
        public void CalculateTotalPrice() 
        {
            foreach(var item in OrderItems) 
            {
                TotalPrice += item.Total;
            }
            RaisePropertyChanged("TotalPrice");
        }

    }
}
