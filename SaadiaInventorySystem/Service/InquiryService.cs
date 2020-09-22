using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class InquiryService
    {
        private readonly AppDbContext db;
        private readonly ILogger<InquiryService> _logger;
        public InquiryService(ILogger<InquiryService> logger, AppDbContext data)
        {
            db = data;
            _logger = logger;

        }
        public Task<bool> AddAsync(Inquiry inquiry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BulkAddAsync(List<Inquiry> inquiry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> BulkUpdateAsync(List<Inquiry> inquiry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Inquiry inquiry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Inquiry Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Inquiry> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Inquiry> AdminGetAll()
        {
            throw new NotImplementedException();
        }

        public Inquiry GetByPartNumber(string part)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AdminDeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
