using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SaadiaInventorySystem.Client.Model
{
    public class Quotation : BaseViewModel
    {
        public Quotation()
        {
            Customer = new Customer();
            Order = new Order();

        }
        private int id;
        private string quotationNumber;
        private string referenceNumber;
        private int customerId;
        private Customer customer;
        private int orderId;
        private Order order;
        private double offeredDiscount;
        private double vat;
        private string ms;
        private string attn;
        private string note;
        private string message;
        private int isActive;
        private double netTotal;
        private DateTime dateCreated;
        private string date;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public string QuotationNumber { get => quotationNumber; set { quotationNumber = value; RaisePropertyChanged(); } }
        public string ReferenceNumber { get => referenceNumber; set { referenceNumber = value; RaisePropertyChanged(); } }

        public int CustomerId { get => customerId; set { customerId = value; RaisePropertyChanged(); } }
        public Customer Customer { get => customer; set { customer = value; RaisePropertyChanged(); } }

        public int OrderId { get => orderId; set { orderId = value; RaisePropertyChanged(); } }
        public Order Order { get => order; set { order = value; RaisePropertyChanged(); } }

        public double OfferedDiscount { get => offeredDiscount; set { offeredDiscount = value; RaisePropertyChanged(); } }
        public double VAT { get => vat; set { vat = value; RaisePropertyChanged(); } }
        public string MS { get => ms; set { ms = value; RaisePropertyChanged(); } }
        public string Attn { get => attn; set { attn = value; RaisePropertyChanged(); } }
        public string Note { get => note; set { note = value; RaisePropertyChanged();} }
        public string Message { get => message; set { message = value; RaisePropertyChanged(); } }
        public int IsActive { get => isActive;  set { isActive = value; RaisePropertyChanged(); } }

        public double NetTotal 
        {
            get => netTotal; 
            set 
            {
                netTotal = value; 
                RaisePropertyChanged(); 
            }
        }

        public DateTime DateCreated { get => dateCreated; set { dateCreated = value; RaisePropertyChanged(); } }
        public string Date { get => date; set { date = DateCreated.ToString("dd-mm-yyyy",CultureInfo.InvariantCulture); RaisePropertyChanged(); } }

        public void CalculateNetTotal()
        {
            Order.CalculateTotalPrice();
            double total_percent = (VAT + offeredDiscount) / 100;
            double adj_price = total_percent * Order.TotalPrice;
            NetTotal = Order.TotalPrice - adj_price;
            RaisePropertyChanged("NetTotal");
        }

    }
}
