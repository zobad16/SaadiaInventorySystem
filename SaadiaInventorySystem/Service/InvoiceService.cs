using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class InvoiceService
    {
        private readonly AppDbContext db;
        public InvoiceService(AppDbContext _db)
        {
            db = _db;
        }
        public bool Add(Invoice data) { return false; }
        public bool Update(Invoice data) { return false; }
        public bool Delete(string id) { return false; }
        public bool AdminDelete(string id) { return false; }
        public bool Get(string id) { return false; }
        public Invoice GetAll() { return new Invoice(); }
    }
}
