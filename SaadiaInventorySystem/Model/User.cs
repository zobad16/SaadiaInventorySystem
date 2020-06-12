using System;

namespace SaadiaInventorySystem.Model
{
    public class User
    {
        public User()
        {
            IsActive = 1;
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public int IsActive { get; set; }
        public Role Role { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        
    }
}
