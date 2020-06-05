using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class QuotationService
    {
        private AppDbContext _userDao;
        public QuotationService(AppDbContext db)
        {
            _userDao = db;
        }

        public bool Add(Quotation data) { return false; }
        public bool Update(Quotation data) { return false; }
        public bool Delete(Quotation data) { return false; }
        public bool Get(Quotation data) { return false; }
        public Quotation GetAll() { return new Quotation(); }
    }
}
