using log4net.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly AppDbContext dao;
        private readonly ILogger<InvoiceService> _logger;

        public InvoiceService(AppDbContext _db, ILogger<InvoiceService> logger)
        {
            dao = _db;
            _logger = logger;
        }
        public async Task<bool> AddAsync(Invoice data) 
        {
            using (var transaction = dao.Database.BeginTransaction())
            {
                try
                {
                    _logger.LogDebug("Adding invoice");
                    int res = 0;
                    bool saved = false;
                    bool isexists = dao.Invoices.AsNoTracking()
                        .Include(c => c.Customer)
                        .Include(o => o.Order)
                        .ThenInclude(oi => oi.OrderItems)
                        .Any(x => x.Id == data.Id);

                    if (!isexists)
                    {
                        Invoice entity = new Invoice()
                        {
                            Attn = data.Attn,
                            IsActive = 1,
                            VAT = data.VAT,
                            Confirmation = false,
                            CustomerId = data.CustomerId,
                            Customer = data.Customer,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now,
                            Message = data.Message,
                            MS = data.MS,
                            Note = data.Note,
                            OrderPurchaseNumber = data.OrderPurchaseNumber,
                            OfferedDiscount = data.OfferedDiscount,
                            QuotationId = data.QuotationId,
                            QuotationNumber = data.QuotationNumber,
                            Total = data.Total
                            

                        };


                        entity.Order = new Order()
                        {
                            IsActive = 1,
                            DateCreated = DateTime.Now,
                            DateUpdated = DateTime.Now,
                            OrderItems = new List<OrderItem>()
                        };
                        foreach (var item in data.Order.OrderItems)
                        {
                            if (item.InventoryId < 1 && item.Inventory == null) continue;
                            if (item.Inventory.Id >= 1)
                            {
                                entity.Order.OrderItems.Add(new OrderItem()
                                {
                                    InventoryId = item.Inventory.Id,
                                    OfferedPrice = item.OfferedPrice,
                                    OrderId = data.OrderId,
                                    OrderQty = item.OrderQty,
                                    Total = item.Total

                                });
                                continue;
                            }
                            else
                            {
                                entity.Order.OrderItems.Add(new OrderItem()
                                {
                                    InventoryId = item.Inventory.Id,
                                    OfferedPrice = item.OfferedPrice,
                                    OrderId = data.OrderId,
                                    OrderQty = item.OrderQty,
                                    Inventory = item.Inventory,
                                    Total = item.Total
                                });
                            }
                        }
                        if (data.CustomerId > 0) entity.Customer = null;
                        await dao.Invoices.AddAsync(entity);
                        //if confirmed then deduct from inventory
                        res += await dao.SaveChangesAsync();

                        //Existing Customer Update
                        if (data.CustomerId > 0 && data.Customer != null)
                        {
                            var _customer = dao.Customers.Where(i => i.Id == data.Customer.Id).FirstOrDefault();
                            if (_customer != null)
                            {
                                _customer.Id = data.Customer.Id;
                                _customer.CompanyName = data.Customer.CompanyName;
                                _customer.PhoneNumber = data.Customer.PhoneNumber;
                                _customer.EmailAddress = data.Customer.EmailAddress;
                                _customer.Postcode = data.Customer.Postcode;
                                _customer.Trn = data.Customer.Trn;
                                _customer.Address = data.Customer.Address;
                                _customer.DateCreated = data.Customer.DateCreated;
                                _customer.DateUpdated = DateTime.Now;
                                _customer.IsActive = 1;

                                res += await dao.SaveChangesAsync();
                            }
                        }
                        //New Customer
                        else if (data.CustomerId == 0)
                        {
                            var _customer = new Customer();
                             _customer.Id = data.Customer.Id;
                            _customer.CompanyName = data.Customer.CompanyName;
                            _customer.PhoneNumber = data.Customer.PhoneNumber;
                            _customer.EmailAddress = data.Customer.EmailAddress;
                            _customer.Postcode = data.Customer.Postcode;
                            _customer.Trn = data.Customer.Trn;
                            _customer.Address = data.Customer.Address;
                            _customer.DateCreated = data.Customer.DateCreated;
                            _customer.DateUpdated = DateTime.Now;
                            _customer.IsActive = 1;

                            res += await dao.SaveChangesAsync();
                            
                        }
                        saved = res > 0;
                        if (saved)
                        {
                            _logger.LogDebug("Insert operation successful");
                            await transaction.CommitAsync();
                        }
                        else
                        {
                            _logger.LogDebug("Insert operation failed");
                            await transaction.RollbackAsync();
                        }
                        return saved;
                    }
                    _logger.LogDebug("Insert operation failed. Record already exists");
                    return false;

                }
                catch (Exception ex)
                {
                    _logger.LogError("An Exception occured: {ex}", ex.Message);
                    _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        public async Task<bool> InvoiceConfirmation(int id)
        {
            var inquiry = dao.Invoices.Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(i => i.Id == id)
                .FirstOrDefault();
            if (inquiry != null && inquiry.Confirmation == true)
                return false;
            foreach (var item in inquiry.Order.OrderItems)
            {
                if (item.OrderQty > item.Inventory.AvailableQty)
                {
                    return false;
                }
                    
            }
            bool result = await DeductInventory(inquiry.Order.OrderItems);
            if (result)
            {
                inquiry.Confirmation = true;
                bool success = await dao.SaveChangesAsync() > 0;
                if (success)
                {
                    _logger.LogDebug("Invoice confirm operation success.");
                    return true;
                }
                else
                {
                    _logger.LogDebug("Invoice confirm operation failed");
                    return false;
                }
            }
            else 
            {
                _logger.LogDebug("An Error occured. Invoice failed to deduct inventory stocks");
                return false;
            }
        }
        private async Task<bool>DeductInventory(List<OrderItem> _orderItems)
        {
            var inventoryList = dao.Inventories.ToList();
            using (var transaction = dao.Database.BeginTransaction())
            {
                int result = 0;
                try
                {
                    foreach (var item in _orderItems)
                    {
                        var part = inventoryList.Where(pk => pk.Id == item.InventoryId).FirstOrDefault();
                        if (part != null)
                        {
                            part.AvailableQty -= item.OrderQty;
                            result += await dao.SaveChangesAsync();
                        }
                    }
                    await transaction.CommitAsync();
                    _logger.LogDebug("Successfully updated inventory stocks");
                    return true;

                }
                catch (Exception ex)
                {
                    _logger.LogError("An error occured while updating the inventory quantity");
                    await transaction.RollbackAsync();
                    _logger.LogError("An Exception occured: {ex}", ex.Message);
                    _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                    return false;
                }

                
            }
                return false;
        }
        public async Task<bool> BulkAddAsync(List<Invoice> data)
        {
            try
            {
                _logger.LogDebug("Bulk Inserting invoices");
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
                    if (item.Customer != null)
                    {
                        if (item.Customer.Id == 0)
                        {
                            _logger.LogDebug("Inserting new Customer");
                            item.Customer.DateCreated = DateTime.Now;
                            item.Customer.IsActive = 1;
                        }
                        else 
                        {
                            _logger.LogDebug("Updating Customer");
                            item.Customer.DateUpdated = DateTime.Now; 
                        }
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
                await dao.Invoices.AddRangeAsync(data);
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Invoices bulk insert success. Records inserted {records}", results);
                }
                else
                {
                    _logger.LogDebug("Invoices bulk insert failed. No records were saved");
                }
                return success;

            }
            catch (Exception ex)
            {
                _logger.LogError("Invoice Bulk Add: Error: {exception} ", ex.Message);
                _logger.LogError("Exception Inner exception details: {exception} ", ex.InnerException.ToString());

            }
            return false;
        }
        public async Task<bool> BulkUpdateAsync(List<Invoice> data)
        {
            try
            {
                _logger.LogDebug("Bulk Updating invoices");
                foreach (var item in data)
                {
                    item.IsActive = 1;
                    item.Order.IsActive = 1;
                    item.DateUpdated = DateTime.Now;
                    if (item.Customer != null)
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
                dao.Invoices.UpdateRange(data);
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Invoices Bulk update Success. Records updated {a}", results);
                }
                else
                {
                    _logger.LogDebug("Invoices Bulk update Failed. Records updated {a}", results);
                }
                return success;

            }
            catch (Exception ex)
            {
                _logger.LogError("Invoices Bulk Update: Error:{exception} ", ex.Message);
                _logger.LogError("Inner Exception details: {a}", ex.InnerException.ToString());

            }
            return false;
        }
        public async Task<bool> UpdateAsync(Invoice data) 
        {
            using (var transaction = dao.Database.BeginTransaction())
            {
                try
                {
                    int save = 0;
                    _logger.LogDebug("Updating Invoice");
                    Invoice invoice = (Invoice)dao.Invoices
                        .Include(r => r.Order)
                        .ThenInclude(r => r.OrderItems)
                        .ThenInclude(r => r.Inventory)
                        .Include(r => r.Customer)
                        .Where(q => q.Id.Equals(data.Id)).Single();

                    if (invoice == null)
                    {
                        _logger.LogDebug("Update operation failed. Invoice not found");
                        return false;
                    }

                    _logger.LogDebug("Invoice found");
                    invoice.DateUpdated = DateTime.Now;

                    if (data.Customer.Id > 0)
                    {
                        invoice.CustomerId = data.Customer.Id;
                        invoice.Customer.Address = data.Customer.Address;
                        invoice.Customer.IsActive = 1;
                        invoice.Customer.EmailAddress = data.Customer.EmailAddress;
                        invoice.Customer.CompanyName = data.Customer.CompanyName;
                        invoice.Customer.DateCreated = data.Customer.DateCreated;
                        invoice.Customer.DateUpdated = DateTime.Now;
                        //invoice.Customer.FirstName = data.Customer.FirstName;
                        //invoice.Customer.LastName = data.Customer.LastName;
                        invoice.Customer.PhoneNumber = data.Customer.PhoneNumber;
                        invoice.Customer.Postcode = data.Customer.Postcode;
                        invoice.Customer.Trn = data.Customer.Trn;
                    }
                    else
                    {
                        invoice.Customer = new Customer();
                        invoice.Customer = data.Customer;
                    }

                    //dao.Customers.Update(invoice.Customer);
                    save += await dao.SaveChangesAsync();
                    invoice.OrderPurchaseNumber = data.OrderPurchaseNumber;
                    invoice.QuotationId = data.QuotationId;
                    invoice.OfferedDiscount = data.OfferedDiscount;
                    invoice.VAT = data.VAT;
                    invoice.IsActive = data.IsActive;
                    invoice.Message = data.Message;
                    invoice.MS = data.MS;
                    invoice.Note = data.Note;
                    invoice.Total = data.Total;
                    save += await dao.SaveChangesAsync();
                    if (invoice.Order.OrderItems.Any())
                    {
                        dao.RemoveRange(invoice.Order.OrderItems);
                        await dao.SaveChangesAsync();
                    }
                    foreach (var item in data.Order.OrderItems)
                    {
                        if (item.InventoryId < 1 && item.Inventory == null) continue;
                        if (item.Inventory.Id > 0)
                        {
                            invoice.Order.OrderItems.Add(new OrderItem()
                            {
                                InventoryId = item.Inventory.Id,
                                OfferedPrice = item.OfferedPrice,
                                OrderId = data.OrderId,
                                OrderQty = item.OrderQty,
                                Total = item.Total

                            });
                        }
                        else 
                        {
                            invoice.Order.OrderItems.Add(new OrderItem()
                            {
                                InventoryId = item.Inventory.Id,
                                OfferedPrice = item.OfferedPrice,
                                OrderId = data.OrderId,
                                OrderQty = item.OrderQty,
                                Inventory = item.Inventory,
                                Total = item.Total
                            });
                        }
                        
                    }
                    save += await dao.SaveChangesAsync();

                    bool success = save > 0;
                    if (success)
                    {
                        _logger.LogDebug("Update operation success.");
                        await transaction.CommitAsync();
                        return true;
                    }
                    else
                    {
                        _logger.LogDebug("Update operation failed");
                        await transaction.RollbackAsync();
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError("An Exception occured: {ex}", ex.Message);
                    _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogDebug("Deleting invoice");
                Invoice invoice = (Invoice)dao.Invoices
                            .Where(invoice => invoice.Id.Equals(id)).FirstOrDefault();
                invoice.IsActive = 0;
                bool success = await dao.SaveChangesAsync() > 0;
                if (success)
                {
                    _logger.LogDebug("Disable operation successful");
                    return true;
                }
                else 
                {
                    _logger.LogDebug("Disable operation failed.");
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return false;
            }
        }
        public Invoice Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Invoice");
                Invoice invoice = (Invoice)dao.Invoices
                    .Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(invoice => invoice.Id.Equals(id)).FirstOrDefault();
                if (invoice != null)
                {
                    _logger.LogDebug("Fetch operation success");
                }
                else
                    _logger.LogDebug("Fetch operation failed");
                return invoice;

            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return null;
            }
        }
        public List<Invoice> GetAll() 
        {
            try
            {
                _logger.LogDebug("Fetching Invoices");

                var invoices = dao.Invoices
                    .Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory).Where(i => i.IsActive == 1).ToList();
                if (invoices.Count > 0)
                {
                    _logger.LogDebug("Fetch operation successful. Returning {count} records", invoices.Count);
                }
                else
                    _logger.LogDebug("Fetch operation failed.");
                return invoices;
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return null;
            }
        }
        public List<Invoice> AdminGetAll() 
        {
            try
            {
                _logger.LogDebug("Admin Fetching Invoices");

                var invoices = dao.Invoices
                    .Include(c => c.Customer)
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory).ToList();
                if (invoices.Count > 0)
                {
                    _logger.LogDebug("Fetch operation successful. Returning {count} records", invoices.Count);
                }
                else
                    _logger.LogDebug("Fetch operation failed.");
                return invoices;

            }
            catch (System.Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return null;
            }
        }
        public async Task<bool> ActivateAsync(int id)
        {
            try
            {
                _logger.LogDebug("Activating invoice");
                var invoice = dao.Invoices.
                    Where(q => q.Id == id).FirstOrDefault();
                if (invoice == null)
                {
                    _logger.LogDebug("Operation failed. Record not found");
                    return false;
                }
                invoice.IsActive = 1;
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Invoice Activated successfully. Records updated {records}", results);
                }
                else
                {
                    _logger.LogDebug("Invoice Activation failed. Records updated {records}", results);
                }
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
            return false;
        }

        public async Task<bool> AdminDeleteAsync(int id)
        {
            try
            {
                _logger.LogDebug("Invoice Admin deleting");
                var invoice = dao.Invoices.
                    Where(q => q.Id == id).FirstOrDefault();
                if (invoice == null)
                {
                    _logger.LogDebug("Delete operation failed. Record not found");
                    return false;
                }
                _logger.LogDebug("Invoice found");
                dao.Invoices.Remove(invoice);
                int results = await dao.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Invoice Admin deleted successfully. Records updated {records}", results);
                }
                else
                {
                    _logger.LogDebug("Invoice Admin delete failed. Records updated {records}", results);
                }

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
            }
            return false;
        }

    }
}
