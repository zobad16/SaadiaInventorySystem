using SaadiaInventorySystem.Client.Util;
using System;
using System.Globalization;

namespace SaadiaInventorySystem.Client.Model
{
    public class Invoice : BaseViewModel
    {
        public Invoice()
        {
            Order = new Order();
            Customer = new Customer();
            VAT = 5;
        }
        private int id;
        private int quotationId;
        private string invoiceNumber;
        private string quotationNumber;
        private string _orderPurchaseNumber;
        private int ? customerId;
        private Customer customer;
        private int orderId;
        private Order order;
        private double offeredDiscount;
        private double vat;
        private int isActive;
        private double netTotal;
        private string ms;
        private string attn;
        private string note;
        private string message;
        private DateTime dateCreated;
        private string date;
        private bool confirmation;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public int QuotationId { get => quotationId; set { quotationId = value; RaisePropertyChanged(); } }
        public string InvoiceNumber { get => invoiceNumber; set { invoiceNumber = value; RaisePropertyChanged(); } }
        public string QuotationNumber { get => quotationNumber; set { quotationNumber = value; RaisePropertyChanged(); } }
        public string OrderPurchaseNumber { get => _orderPurchaseNumber; set { _orderPurchaseNumber = value; RaisePropertyChanged(); } }
        public int ? CustomerId { get => customerId; set { customerId = value; RaisePropertyChanged(); } }
        public Customer Customer { get => customer; set { customer = value; RaisePropertyChanged(); }}
        public int OrderId { get => orderId; set { orderId = value; RaisePropertyChanged(); } }
        public Order Order { get => order; set { order = value; RaisePropertyChanged(); } }
        public double OfferedDiscount { get => offeredDiscount; set { offeredDiscount = value; RaisePropertyChanged(); CalculateNetTotal(); } }
        public double VAT { get => vat; set { vat = value; RaisePropertyChanged(); CalculateNetTotal(); } }
        public string MS { get => ms; set { ms = value; RaisePropertyChanged(); } }
        public string Attn { get => attn; set { attn = value; RaisePropertyChanged(); } }
        public string Note { get => note; set { note = value; RaisePropertyChanged(); } }
        public string Message { get => message; set { message = value; RaisePropertyChanged(); } }
        public int IsActive { get => isActive; set { isActive = value; RaisePropertyChanged(); } }
        public bool Confirmation { get => confirmation; set { confirmation = value; RaisePropertyChanged(); } }

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
        public string Date { get => date; set { date = DateCreated.ToString("dd-mm-yyyy", CultureInfo.InvariantCulture); RaisePropertyChanged(); } }

        public void CalculateNetTotal()
        {
            Order.CalculateTotalPrice();
            if (VAT == 0) VAT = 5;
            foreach (var part in Order.OrderItems)
                part.CalculateVAT();
            double total_percent = offeredDiscount / 100;
            double vat_adj = VAT / 100 * Order.TotalPrice;
            double discount_adj = total_percent * Order.TotalPrice;
            NetTotal = (Order.TotalPrice - discount_adj) + vat_adj;
            RaisePropertyChanged("NetTotal");
        }


    }
}
