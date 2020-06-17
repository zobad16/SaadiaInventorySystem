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
        private AppDbContext dao;
        public QuotationService(AppDbContext db)
        {
            dao = db;
        }

        public async Task<bool> AddAsync(Quotation data) 
        {
            try
            {
                bool exists = dao.Quotations.Any(q => q.Id.Equals(data.Id));
                if (!exists) 
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    await dao.Quotations.AddAsync(data);
                    return await dao.SaveChangesAsync() > 0;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false; 
        }
        public async Task<bool> UpdateAsync(Quotation data)
        {
            try 
            {
                Quotation quote = dao.Quotations.
                    Where(q => q.Id.Equals(data.Id)).FirstOrDefault();
                quote.DateUpdated = DateTime.Now;
                quote.Items = data.Items;
                quote.CustomerId = data.CustomerId;
                quote.Customer = data.Customer;
                
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex){ throw ex; }
            
        }
        public async Task<bool> DeleteAsync(string id)
        {
            try 
            {
                Quotation quote = dao.Quotations.
                    Where(q => q.Id.Equals(id)).FirstOrDefault();
                quote.IsActive = 0;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex){ throw ex; }
            
        }
        
        public async Task<bool> AdminDeleteAsync(string id) 
        {
            try 
            {
                Quotation quote = dao.Quotations.
                    Where(q => q.Id.Equals(id)).FirstOrDefault();
                dao.Quotations.Remove(quote);
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex){ throw ex; }
            
        }
        public Quotation Get(string id) 
        {
            try
            {
                var quotation = dao.Quotations.
                    Where((quote)=> quote.Id.Equals(id)
                    ).FirstOrDefault();
                return quotation;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<Quotation> GetAll() 
        {
            return dao.Quotations.Where(i => i.IsActive == 1).ToList<Quotation>(); 
        }
        public List<Quotation> AdminGetAll() 
        {
            return dao.Quotations.ToList<Quotation>(); 
        }
    }
}
