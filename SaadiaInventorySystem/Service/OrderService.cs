using Microsoft.EntityFrameworkCore;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class OrderService
    {
        private AppDbContext dao;
        public OrderService(AppDbContext db)
        {
            dao = db;
        }

        public async Task<bool> AddAsync(Order data)
        {
            try
            {
                bool exists = dao.Quotations.Any(q => q.Id.Equals(data.Id));
                if (!exists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    await dao.Orders.AddAsync(data);
                    return await dao.SaveChangesAsync() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
        public async Task<bool> UpdateAsync(Order data)
        {
            try
            {
                Order order = dao.Orders.
                    Where(q => q.Id == data.Id).FirstOrDefault();
                order.DateUpdated = DateTime.Now;
                order.OrderItems = data.OrderItems;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Order order = dao.Orders.
                    Where(q => q.Id == id).FirstOrDefault();
                order.IsActive = 0;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public async Task<bool> ActivateAsync(int id)
        {
            try
            {
                Order order = dao.Orders.
                    Where(q => q.Id == id).FirstOrDefault();
                order.IsActive = 0;
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<bool> AdminDeleteAsync(int id)
        {
            try
            {
                Order order = dao.Orders.
                    Where(q => q.Id == id).FirstOrDefault();
                dao.Orders.Remove(order);
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex) { throw ex; }

        }
        public Order Get(int id)
        {
            try
            {
                var order = dao.Orders
                    .Include(r => r.OrderItems)
                    .Where(order => order.Id == id)
                    .FirstOrDefault();
                return order;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Order> GetAll()
        {
            return dao.Orders.Include(r => r.OrderItems)
                .Where(i => i.IsActive == 1).ToList<Order>();
        }
        public List<Order> AdminGetAll()
        {
            return dao.Orders
                    .Include(r => r.OrderItems)
                    .ToList<Order>();
        }
    }
}
