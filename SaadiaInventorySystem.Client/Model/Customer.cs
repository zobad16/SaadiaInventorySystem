using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class Customer : BaseViewModel
    {
        public int _id;
        public string _firstName;
        private string _lastName;
        public string _companyName;
        public string _address;
        public string _trn;
        public string _phoneNumber;
        public string _emailAddress;
        public string _postcode;

        
        public int Id { get => _id; set {_id = value; RaisePropertyChanged(); } }
        public string FirstName { get=> _firstName; set {_firstName = value;RaisePropertyChanged(); } }
        public string LastName { get => _lastName; set { _lastName = value; RaisePropertyChanged(); } }
        public string CompanyName { get=> _companyName; set {_companyName = value; RaisePropertyChanged(); } }
        public string Address { get=> _address; set {_address =value; RaisePropertyChanged(); } }
        public string Trn { get=>_trn; set { _trn = value; RaisePropertyChanged(); } }
        public string PhoneNumber { get=>_phoneNumber; set { _phoneNumber = value; RaisePropertyChanged(); } }
        public string EmailAddress { get => _emailAddress; set { _emailAddress = value; RaisePropertyChanged(); } }
        public string Postcode { get=> _postcode; set { _postcode = value; RaisePropertyChanged(); } }



    }

}
