using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public interface IInquiryService
    {
        Task<bool> AddAsync(Inquiry inquiry);
        Task<bool> BulkAddAsync(List<Inquiry> inquiry);
        Task<bool> BulkUpdateAsync(List<Inquiry> inquiry);
        Task<bool> UpdateAsync(Inquiry inquiry);
        Task<bool> ActivateAsync(int id);
        Task<Inquiry> Get(int id);
        List<Inquiry> GetAll();
        List<Inquiry> AdminGetAll();
        Task<bool> DeactivateAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> AdminDeleteAsync(int id);

    }
}
