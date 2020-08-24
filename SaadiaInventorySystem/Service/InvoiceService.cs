﻿using log4net.Core;
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
            try
            {
                _logger.LogDebug("Adding invoice");
                bool saved = false;
                bool isexists = dao.Invoices.Any(x => x.Id == data.Id);

                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    await dao.Invoices.AddAsync(data);
                    //if confirmed then deduct from inventory
                    saved = await dao.SaveChangesAsync() > 0;

                    if (saved)
                    {
                        _logger.LogDebug("Insert operation successful");
                    }
                    else
                    {
                        _logger.LogDebug("Insert operation failed");
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
                return false;
            }
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
                            _logger.LogDebug("Updating Cusotmer");
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
            try
            {
                _logger.LogDebug("Updating Invoice");
                Invoice invoice = (Invoice)dao.Invoices
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(data.Id)).FirstOrDefault();
                if (invoice == null)
                {
                    _logger.LogDebug("Update operation failed. Invoice not found");
                    return false;
                }

                _logger.LogDebug("Invoice found");
                
                invoice.DateUpdated = DateTime.Now;
                invoice.OrderId = data.OrderId;
                invoice.OrderPurchaseNumber = data.OrderPurchaseNumber;
                invoice.QuotationId = data.QuotationId;
                invoice.Order.OrderItems = data.Order.OrderItems;
                invoice.CustomerId = data.CustomerId;
                invoice.Customer = data.Customer;
                invoice.OfferedDiscount = data.OfferedDiscount;
                invoice.VAT = data.VAT;
                invoice.IsActive = data.IsActive;
                bool success = await dao.SaveChangesAsync() > 0;
                if (success)
                {
                    _logger.LogDebug("Update operation success.");
                    return true;
                }
                else 
                {
                    _logger.LogDebug("Update operation failed");
                    return false;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("An Exception occured: {ex}", ex.Message);
                _logger.LogError("Stack Trace: {ex}", ex.StackTrace);
                return false;
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
