using log4net.Core;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class CustomerService
    {
        private AppDbContext _dao;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(AppDbContext db, ILogger<CustomerService> logger)
        {
            _dao = db;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Customer data) 
        {
            try
            {
                _logger.LogDebug("Service: Adding Customer");
                bool isexists = _dao.Customers.Any(x => x.Id== data.Id || 
                                                  (x.LastName == data.LastName && x.FirstName == data.FirstName));

                if (!isexists)
                {
                    _logger.LogDebug("Inserting new customer");
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    data.IsActive = 1;
                    await _dao.Customers.AddAsync(data);
                    bool res = await _dao.SaveChangesAsync() > 0;
                    if (res)
                        _logger.LogDebug("Insert Operation success.");
                    else
                        _logger.LogDebug("Insert operation failed");
                    return res;
                }
                _logger.LogDebug("Customer found. Aborting insert operation");
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Customer data) 
        {
            try
            {
                _logger.LogDebug("Updating Customer");
                bool saved = false;
                Customer _customer = (Customer)_dao.Customers
                            .Where(customer => customer.Id.Equals(customer.Id)).FirstOrDefault();
                if (_customer != null)
                {
                    _logger.LogDebug("Customer found. Updating record");
                    _customer.IsActive = 1;
                    _customer.FirstName = data.FirstName;
                    _customer.LastName = data.LastName;
                    _customer.Address = data.Address;
                    _customer.EmailAddress = data.EmailAddress;
                    _customer.PhoneNumber = data.PhoneNumber;
                    _customer.Postcode = data.Postcode;
                    _customer.Trn = data.Trn;
                    _customer.DateUpdated = DateTime.Now;
                    int records = await _dao.SaveChangesAsync();
                    saved = records > 0;
                    if (saved)
                        _logger.LogDebug("Update operation successfull. Records updated: {records}",records);
                    else
                        _logger.LogDebug("Update operation failed. Records updated:{records}", records);
                }
                _logger.LogDebug("Update operation failed. Customer not found");
                
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return false;
        }

        public async Task<bool> ActivateAsync(int id)
        {
            try
            {
                _logger.LogDebug("Activating Customer");
                bool saved = false;
                Customer _customer = (Customer)_dao.Customers
                            .Where(customer => customer.Id == id).FirstOrDefault();
                if (_customer != null)
                {
                    _logger.LogDebug("Customer found. Activating");
                    _customer.IsActive = 1;
                    saved = await _dao.SaveChangesAsync() > 0;
                    if (saved)
                    {
                        _logger.LogDebug("Activate operation success");
                    }
                    else
                        _logger.LogDebug("Activate operation failed");
                }
                _logger.LogDebug("Activate operation failed. Record not found");
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int id) 
        {
            try
            {
                _logger.LogDebug("Disabling Customer");
                bool saved = false;
                Customer _customer = (Customer)_dao.Customers
                            .Where(customer => customer.Id == id ).FirstOrDefault();
                if (_customer != null)
                {
                    _logger.LogDebug("Customer found.");
                    _customer.IsActive = 0;
                    _customer.DateUpdated = DateTime.Now;

                    saved = await _dao.SaveChangesAsync() > 0;
                    if (saved)
                        _logger.LogDebug("Disable operation success");
                    else
                        _logger.LogDebug("Disable operation failed");
                }
                _logger.LogDebug("Disable operation failed. Customer not found");
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return false;
        }
        public async Task<bool> AdminDeleteAsync(int id)
        {
            try
            {
                _logger.LogDebug("Service: Permanently deleting Customer");
                Customer _customer = (Customer)_dao.Customers
                            .Where(_customer => _customer.Id == id).FirstOrDefault();
                if (_customer != null)
                {
                    _logger.LogDebug("Customer found");
                    _dao.Customers.Remove(_customer);

                    bool result = await _dao.SaveChangesAsync() > 0;
                    if (result)
                        _logger.LogDebug("Delete operation success.");
                    else
                        _logger.LogDebug("Delete operation failed");
                    return result;
                }
                else
                {
                    _logger.LogDebug("Customer not found");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return false;
        }

        public Customer Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Customer");
                Customer _customer = (Customer)_dao.Customers
                    .Where(_customer => _customer.Id.Equals(id)).FirstOrDefault();
                if (_customer != null)
                    _logger.LogDebug("Customer found");
                else
                    _logger.LogDebug("Customer not found");
                return _customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return null;
        }
        public List<Customer> GetAll() 
        {
            try
            {
                _logger.LogDebug("Fetching all customers");
                List<Customer> _customer = _dao.Customers.Where(i => i.IsActive == 1).ToList();
                if (_customer.Count > 0)
                    _logger.LogDebug("Customers found. Total records found: {records}", _customer.Count());
                else
                    _logger.LogDebug("Customers not found");
                return _customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return null;
            
        }
        public List<Customer> AdminGetAll() 
        {
            try
            {
                _logger.LogDebug("Admin Fetching all customers");
                List<Customer> _customer = _dao.Customers.ToList();
                if (_customer.Count > 0)
                    _logger.LogDebug("Customers found. Total records found: {records}", _customer.Count());
                else
                    _logger.LogDebug("Customers not found");

                return _customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
            }
            return null;
            
        }
    }
}
