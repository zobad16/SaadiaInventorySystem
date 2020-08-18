using Microsoft.EntityFrameworkCore;
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
        public InvoiceService(AppDbContext _db)
        {
            dao = _db;
        }
        public async Task<bool> AddAsync(Invoice data) 
        {
            try
            {
                bool isexists = dao.Invoices.Any(x => x.Id == data.Id);

                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    await dao.Invoices.AddAsync(data);
                    //if confirmed then deduct from inventory
                    return await dao.SaveChangesAsync() > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> UpdateAsync(Invoice data) 
        {
            try
            {
                Invoice invoice = (Invoice)dao.Invoices
                    .Include(r => r.Order)
                    .ThenInclude(r => r.OrderItems)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(data.Id)).FirstOrDefault();
                            
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
                return await dao.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                Invoice invoice = (Invoice)dao.Invoices
                            .Where(invoice => invoice.Id.Equals(id)).FirstOrDefault();
                dao.Remove<Invoice>(invoice);
                return await dao.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public Invoice Get(string id)
        {
            try
            {
                Invoice invoice = (Invoice)dao.Invoices
                            .Where(invoice => invoice.Id.Equals(id)).FirstOrDefault();
                return invoice;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public List<Invoice> GetAll() 
        {
            try
            {
                return dao.Invoices.Where(i => i.IsActive == 1).ToList();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public List<Invoice> AdminGetAll() 
        {
            try
            {
                
                return dao.Invoices.ToList();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
