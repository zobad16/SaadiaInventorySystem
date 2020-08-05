using Microsoft.EntityFrameworkCore;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
                data.Order.IsActive = 1;
                data.Order.DateCreated = DateTime.Now;
                data.Order.DateUpdated = DateTime.Now;
                foreach(var item in data.Order.OrderItems)
                {
                    if (item.Inventory.Id == 0) 
                    {
                        item.Inventory.DateCreated = DateTime.Now;
                        item.Inventory.DateUpdate = DateTime.Now;
                        item.Inventory.IsActive = 1;
                    }
                }

                bool exists = dao.Quotations.Any(q => q.Id.Equals(data.Id));

                if (!exists) 
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    data.Order.DateCreated = DateTime.Now;
                    data.Order.DateUpdated = DateTime.Now;
                    
                    await dao.Quotations.AddAsync(data);
                    
                    return await dao.SaveChangesAsync() > 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Quotation Add: Error: {ex.ToString()}");
            }
            return false; 
        }

        public async Task<bool> BulkAddAsync(List<Quotation> data)
        {
            try
            {
                foreach (var item in data)
                {
                    item.IsActive = 1;
                    item.Order.IsActive = 1;
                    item.Order.DateCreated = DateTime.Now;
                    item.DateUpdated = DateTime.Now;
                    
                    //Customers:
                    //If Customer null && customerid == null : No Customer for quotation
                    //If Customer null && customerid >0: Existing customer
                    //If Customer !null && customerid ==0: New Customer 
                    //If Customer !null && customerid >0 : Update Customer
                    if(item.Customer != null)
                    {
                        if (item.Customer.Id == 0)
                        {
                            item.Customer.DateCreated = DateTime.Now;
                            item.Customer.IsActive = 1;
                        }
                        else { item.Customer.DateUpdated = DateTime.Now; }
                    }
                    
                    foreach (var part in item.Order.OrderItems)
                    {
                        if (part.Inventory != null)
                        {
                            part.Inventory.DateCreated = DateTime.Now;
                            part.Inventory.IsActive = 1;
                        }
                    }
                }                
                await dao.Quotations.AddRangeAsync(data);

                return await dao.SaveChangesAsync() > 0;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Quotation Bulk Add: Error: {ex.InnerException.Message.ToString()}");
                
            }
            return false;
        }
        public async Task<bool> BulkUpdateAsync(List<Quotation> data)
        {
            try
            {
                foreach (var item in data)
                {
                    item.IsActive = 1;
                    item.Order.IsActive = 1;
                    item.DateUpdated = DateTime.Now; 
                    if(item.Customer != null)
                    {
                        item.Customer.DateUpdated = DateTime.Now; 
                    }
                    
                    foreach (var part in item.Order.OrderItems)
                    {
                        if (part.Inventory != null)
                        {
                            part.Inventory.IsActive = 1;
                            part.Inventory.DateUpdate = DateTime.Now;
                        }
                    }
                }                
                dao.Quotations.UpdateRange(data);

                return await dao.SaveChangesAsync() > 0;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Quotation Bulk Update: Error: {ex.InnerException.Message.ToString()}");
                
            }
            return false;
        }
        public async Task<bool> UpdateAsync(Quotation data)
        {
            try 
            {
                Quotation quote = dao.Quotations
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(data.Id)).FirstOrDefault();
                    
                //if(quote.Order.OrderItems != null)
                //{
                //    dao.Remove(quote.Order.OrderItems);
                //}

                quote.DateUpdated = DateTime.Now;
                quote.OrderId = quote.OrderId;
                
                //quote.Order = data.Order;

                quote.Order.OrderItems = data.Order.OrderItems;
                quote.CustomerId = data.CustomerId;
                quote.Customer = data.Customer;
                quote.Attn = data.Attn;
                quote.Message = data.Message;
                quote.MS = data.MS;
                quote.Note = data.Note;
                quote.OfferedDiscount = data.OfferedDiscount;
                quote.QuotationNumber = data.QuotationNumber;
                quote.ReferenceNumber = data.ReferenceNumber;
                quote.VAT = quote.VAT;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Quotation Update error: {ex.InnerException}");
                throw ex; 
            }
            
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
                Quotation quote = dao.Quotations.
                    Where(q => q.Id == id).FirstOrDefault();
                quote.IsActive = 0;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex){ throw ex; }
            
        }
        public async Task<bool> ActivateAsync(int id)
        {
            try 
            {
                Quotation quote = dao.Quotations.
                    Where(q => q.Id == id).FirstOrDefault();
                quote.IsActive = 1;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex){ throw ex; }
            
        }
        
        public async Task<bool> AdminDeleteAsync(int id) 
        {
            try 
            {
                Quotation quote = dao.Quotations.
                    Where(q => q.Id == id).FirstOrDefault();
                dao.Quotations.Remove(quote);
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex){ throw ex; }
            
        }
        public Quotation Get(int id) 
        {
            try
            {
                var quotation = dao.Quotations.Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r=> r.OrderItems)
                    .ThenInclude(r=> r.Inventory)
                    .Where((quote)=> quote.Id == id )
                    .FirstOrDefault();
                return quotation;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw new Exception(ex.InnerException.Message);
            }
        }
        public List<Quotation> GetAll() 
        {
            try
            {
                var quotes = dao.Quotations.Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(i => i.IsActive == 1)
                    .ToList<Quotation>();
                return quotes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw new Exception(ex.InnerException.Message);
            }
        }
        public List<Quotation> AdminGetAll() 
        {
            try
            {
                var quotes = dao.Quotations.Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .ToList<Quotation>();
                return quotes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw new Exception(ex.InnerException.Message);
            }
        }
    }
}
