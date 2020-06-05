using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class CustomerService
    {
        private AppDbContext _userDao;
        public CustomerService(AppDbContext db)
        {
            _userDao = db;
        }

        public bool Add(Customer data) { return false; }
        public bool Update(Customer data) { return false; }
        public bool Delete(Customer data) { return false; }
        public bool Get(Customer data) { return false; }
        public Customer GetAll() { return new Customer(); }
    }
}
