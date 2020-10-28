using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SaadiaInventorySystem.Client.Model
{
    public class Inquiry : BaseViewModel
    {
        public Inquiry()
        {
            Items = new ObservableCollection<InquiryItem>();
            IsActive = 1;
            VatPercent = 5;
        }
        public Inquiry(Inquiry i)
        {
            Id =i.Id;
            Ms = i.Ms;
            InquiryNumber = i.InquiryNumber;
            Attn = i.Attn;
            IsActive = 1;
            DateCreated = i.DateCreated;
            Message = i.Message;
            Note = i.Note;
            NetTotal = i.NetTotal;
            DateIssued = i.DateIssued;
            DateEdited = i.DateEdited;
            Items = i.Items;
            Discount = i.Discount;
            Vat = i.Vat;
            VatPercent = i.VatPercent;
            Total = i.Total;
        }
        private int _id;
        private string _ms;
        private string _attn;
        private string _inquiryNumber;
        private string _message;
        private string _note;
        private double _discount; 
        private double _vat; 
        private double _vatPercent; 
        private double _total;
        private double _netTotal;
        private int _isActive;
        private DateTime _dateIssued;
        private DateTime _dateCreated;
        private DateTime _dateEdited;
        private ObservableCollection<InquiryItem> _items;
        
        public int Id { get => _id; set { _id = value; RaisePropertyChanged(); } }
        public string Ms { get => _ms; set { _ms = value; RaisePropertyChanged(); } }
        public string Attn { get => _attn; set { _attn = value; RaisePropertyChanged(); } }
        public string InquiryNumber { get => _inquiryNumber; set { _inquiryNumber = value; RaisePropertyChanged(); } }
        public string Message { get => _message; set { _message = value; RaisePropertyChanged(); } }
        public string Note { get => _note; set { _note = value; RaisePropertyChanged(); } }
        public double Discount { get => _discount; set { _discount = value; RaisePropertyChanged(); CalculateNetTotal(); } }
        public double Vat { get => _vat; set { _vat = value; RaisePropertyChanged(); } }
        public double VatPercent { get => _vatPercent; set { _vatPercent = value; RaisePropertyChanged(); CalculateNetTotal(); } }
        public double Total { get => _total; set { _total = value;  RaisePropertyChanged();  } }
        public double NetTotal { get => _netTotal; set { _netTotal = value; RaisePropertyChanged(); } }
        public int IsActive { get => _isActive; set { _isActive = value; RaisePropertyChanged();} }
        public DateTime DateIssued { get => _dateIssued; set { _dateIssued = value; RaisePropertyChanged(); } }
        public DateTime DateCreated { get => _dateCreated; set { _dateCreated = value; RaisePropertyChanged(); } }
        public DateTime DateEdited { get => _dateEdited; set { _dateEdited = value;RaisePropertyChanged(); }}
        public ObservableCollection<InquiryItem> Items { get => _items; set { _items = value; RaisePropertyChanged(); } }

        public void CalculateTotal()
        {
            Total = 0.0;
            Vat = 0.0;
           foreach (var item in Items)
            {
                item.CalculateTotal();
                Total += item.Total;              
            }
            if(Discount > 0)
                Total -= Discount / 100;
        }
        public void CalculateVat()
        {
            Vat = 0.0;
            foreach (var item in Items)
            { 
                item.Vat = item.Total * (VatPercent/100);
                Vat += item.Vat;
            }

        }
        public void CalculateNetTotal()
        {
            Total = 0.0;
            Vat = 0.0;
            
            CalculateTotal();
            CalculateVat();
            
            if (Discount > 0)
                Total -= Discount / 100;
            NetTotal = Total + Vat;
            RaisePropertyChanged("NetTotal");
        }
    }
}
