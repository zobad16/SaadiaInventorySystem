using System;

namespace SaadiaInventorySystem.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Trn { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Postcode { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int IsActive { get; internal set; }
    }
}
