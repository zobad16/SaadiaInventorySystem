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
        public CustomerService(AppDbContext db)
        {
            _dao = db;
        }

        public async Task<bool> AddAsync(Customer data) 
        {
            try
            {
                bool isexists = _dao.Customers.Any(x => x.Id== data.Id || 
                                                  (x.LastName == data.LastName && x.FirstName == data.FirstName));

                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    await _dao.Customers.AddAsync(data);
                    return await _dao.SaveChangesAsync() > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> UpdateAsync(Customer data) 
        {
            try
            {
                bool saved = false;
                Customer _customer = (Customer)_dao.Customers
                            .Where(customer => customer.Id.Equals(customer.Id)).FirstOrDefault();
                if (_customer != null)
                {
                    if (!string.IsNullOrEmpty(_customer.FirstName)) _customer.FirstName = _customer.FirstName;
                    if (!string.IsNullOrEmpty(_customer.LastName)) _customer.LastName = _customer.LastName;
                    if (!string.IsNullOrEmpty(_customer.EmailAddress)) _customer.EmailAddress = _customer.EmailAddress;
                    if (!string.IsNullOrEmpty(_customer.PhoneNumber)) _customer.PhoneNumber = _customer.PhoneNumber;
                    if (!string.IsNullOrEmpty(_customer.Postcode)) _customer.Postcode = data.Postcode;
                    if (!string.IsNullOrEmpty(_customer.Trn)) _customer.Trn = data.Trn;
                    _customer.DateUpdated = DateTime.Now;

                    saved = await _dao.SaveChangesAsync() > 0;
                }
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> DeleteAsync(string id) 
        {
            try
            {
                bool saved = false;
                Customer _customer = (Customer)_dao.Customers
                            .Where(customer => customer.Id.Equals(id)).FirstOrDefault();
                if (_customer != null)
                {
                    _customer.IsActive = 0;
                    _customer.DateUpdated = DateTime.Now;

                    saved = await _dao.SaveChangesAsync() > 0;
                }
                return saved;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> AdminDeleteAsync(string id)
        {
            try
            {
                Customer _customer = (Customer)_dao.Customers
                            .Where(_customer => _customer.Id.Equals(id)).FirstOrDefault();
                _dao.Customers.Remove(_customer);
                
                return await _dao.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public Customer Get(string id)
        {
            try
            {
                Customer _customer = (Customer)_dao.Customers
                    .Where(_customer => _customer.Id.Equals(id)).FirstOrDefault();
                return _customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public List<Customer> GetAll() 
        {
            try
            {
                List<Customer> _customer = _dao.Customers.Where(i => i.IsActive == 1).ToList();

                return _customer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            
        }
    }
}
