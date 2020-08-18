using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using Serilog;
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
        private readonly ILogger<QuotationService> _logger;
        public QuotationService(AppDbContext db)
        {
            dao = db;
        }
        public QuotationService(AppDbContext db, ILogger<QuotationService> logger)
        {
            dao = db;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Quotation data) 
        {
            try
            {
                _logger.LogDebug("Inserting Quotation");
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
                    int results = await dao.SaveChangesAsync();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Quotation: Insert operation success. Records Inserted {a}",results);
                    }
                    else 
                    {
                        _logger.LogDebug("Quotation: Insert operation Failed. Records inserted {b}", results);
                    }
                    return success;
                }
                _logger.LogDebug("Insert operation failed. Duplicate record found");
            }
            catch(Exception ex)
            {
                _logger.LogError("Adding Quotation threw an Exception:{exception} ", ex.Message);
                _logger.LogError("Adding Quotation threw an Exception:{exception} ",ex.InnerException.ToString());
                
                
            }
            return false; 
        }

        public async Task<bool> BulkAddAsync(List<Quotation> data)
        {
            try
            {
                _logger.LogDebug("Bulk Inserting quotations");
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
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Quotations bulk insert success. Records inserted {records}", results);
                }
                else 
                {
                    _logger.LogDebug("Quotations bulk insert failed. No records were saved");
                }
                return success;
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation Bulk Add: Error: {exception} ", ex.Message);
                _logger.LogError("Exception Inner exception details: {exception} ", ex.InnerException.ToString());

            }
            return false;
        }
        public async Task<bool> BulkUpdateAsync(List<Quotation> data)
        {
            try
            {
                _logger.LogDebug("Bulk Updating quotations");
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
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Quotations Bulk Insert Success. Records updated {a}", results);
                }
                else
                {
                    _logger.LogDebug("Quotations Bulk Insert Failed. Records updated {a}", results);
                }
                return success;
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation Bulk Update: Error:{exception} ", ex.Message);
                _logger.LogError("Inner Exception details: {a}", ex.InnerException.ToString());

            }
            return false;
        }
        public async Task<bool> UpdateAsync(Quotation data)
        {
            try 
            {
                _logger.LogDebug("Updating Quotations");
                Quotation quote = dao.Quotations
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(data.Id)).FirstOrDefault();
                    

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
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Quotations Update Success. Records updated {a}", results);
                }
                else
                {
                    _logger.LogDebug("Quotations Update Failed. Records updated {a}", results);
                }
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation Update Failed. Returned an exception: {a}",ex.Message);
                _logger.LogError("Stack trace: {a}",ex.StackTrace);
            }
            return false;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
                _logger.LogDebug("Deleting Quotaion");
                Quotation quote = dao.Quotations.
                    Where(q => q.Id == id).FirstOrDefault();
                quote.IsActive = 0;
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Delete quotation successs. Records deleted{records}", results);
                }
                else 
                {
                    _logger.LogDebug("Delete quotation Failed. Records deleted{records}", results);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Deleting record: An exception occured {exception}", ex.Message);
                _logger.LogError("Stack Trace {exception}", ex.StackTrace);
            }
            return false;
        }
        public async Task<bool> ActivateAsync(int id)
        {
            try 
            {
                _logger.LogDebug("Activating quotation");
                Quotation quote = dao.Quotations.
                    Where(q => q.Id == id).FirstOrDefault();
                quote.IsActive = 1;
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Quotation Activated successfully. Records updated {records}", results);
                }
                else 
                {
                    _logger.LogDebug("Quotation Activation failed. Records updated {records}", results);
                }
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation Activate threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
            return false;
        }
        
        public async Task<bool> AdminDeleteAsync(int id) 
        {
            try 
            {
                _logger.LogDebug("Quotaion Admin deleting");
                Quotation quote = dao.Quotations.
                    Where(q => q.Id == id).FirstOrDefault();
                dao.Quotations.Remove(quote);
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Quotation Admin deleted successfully. Records updated {records}", results);
                }
                else
                {
                    _logger.LogDebug("Quotation Admin delete failed. Records updated {records}", results);
                }

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation Admin Delete threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
            return false;
        }
        public Quotation Get(int id) 
        {
            try
            {
                _logger.LogDebug("Fetching Quotation with id: {id}",id);

                var quotation = dao.Quotations.Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r=> r.OrderItems)
                    .ThenInclude(r=> r.Inventory)
                    .Where((quote)=> quote.Id == id )
                    .FirstOrDefault();
                if (quotation != null)
                {
                    _logger.LogDebug("Quotation found");
                }
                else 
                {
                    _logger.LogDebug("Quotaion not found");
                }
                return quotation;
            }
            catch(Exception ex)
            {
                _logger.LogError("Quotation get threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
        
            return null;
        }
        public List<Quotation> GetAll() 
        {
            try
            {
                _logger.LogDebug("Fetching Quotaions");

                var quotes = dao.Quotations.Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(i => i.IsActive == 1)
                    .ToList<Quotation>();
                int records = quotes.Count();
                _logger.LogDebug("Quotation records fetched: {record}", records);
                return quotes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation get all threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
        
            return null;
        }
        public List<Quotation> AdminGetAll() 
        {
            try
            {
                _logger.LogDebug("Getting admin level quotaions");
                var quotes = dao.Quotations.Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .ToList<Quotation>();
                int records = quotes.Count();
                _logger.LogDebug("Quotation records fetched: {record}", records);

                return quotes;
            }
            catch (Exception ex)
            {
                _logger.LogError("Quotation admin get all threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
            return null;
        }
    }
}
