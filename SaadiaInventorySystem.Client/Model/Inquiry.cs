using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.Generic;

namespace SaadiaInventorySystem.Client.Model
{
    public class Inquiry : BaseViewModel
    {
        private int _id;
        private string _ms;
        private string _attn;
        private string _inquiryNumber;
        private string _message;
        private string _note;
        private double _discount;
        private int _isActive;
        private DateTime _dateIssued;
        private DateTime _dateCreated;
        private DateTime _dateEdited;
        private List<InquiryItem> _items;

        public int Id { get => _id; set { _id = value; RaisePropertyChanged(); } }
        public string Ms { get => _ms; set { _ms = value; RaisePropertyChanged(); } }
        public string Attn { get => _attn; set { _attn = value; RaisePropertyChanged(); } }
        public string InquiryNumber { get => _inquiryNumber; set { _inquiryNumber = value; RaisePropertyChanged(); } }
        public string Message { get => _message; set { _message = value; RaisePropertyChanged(); } }
        public string Note { get => _note; set { _note = value; RaisePropertyChanged(); } }
        public double Discount { get => _discount; set { _discount = value; RaisePropertyChanged(); } }
        public int IsActive { get => _isActive; set { _isActive = value; RaisePropertyChanged();} }
        public DateTime DateIssued { get => _dateIssued; set { _dateIssued = value; RaisePropertyChanged(); } }
        public DateTime DateCreated { get => _dateCreated; set { _dateCreated = value; RaisePropertyChanged(); } }
        public DateTime DateEdited { get => _dateEdited; set { _dateEdited = value;RaisePropertyChanged(); }}
        public List<InquiryItem> Items { get => _items; set { _items = value; RaisePropertyChanged(); } }
    }
}
