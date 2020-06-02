using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public int IsActive { get; set; }
        public int RoleId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdate { get; set; }
        

        public Role Role { get; set; }
        public Customer Customer { get; set; }
    }
}
