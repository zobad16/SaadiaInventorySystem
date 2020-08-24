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
    public class OrderService
    {
        private AppDbContext dao;
        private readonly ILogger<OrderService> _logger;
        public OrderService(AppDbContext db, ILogger<OrderService> logger)
        {
            dao = db;
            _logger = logger;
        }

        public async Task<bool> AddAsync(Order data)
        {
            try
            {
                _logger.LogDebug("Adding order");
                bool saved = false;
                bool exists = dao.Quotations.Any(q => q.Id.Equals(data.Id));
                if (!exists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    await dao.Orders.AddAsync(data);
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
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                

            }
            return false;
        }
        public async Task<bool> UpdateAsync(Order data)
        {
            try
            {
                var saved = false;
                Order order = dao.Orders.
                    Where(q => q.Id == data.Id).FirstOrDefault();
                order.DateUpdated = DateTime.Now;
                order.OrderItems = data.OrderItems;
                saved = await dao.SaveChangesAsync() > 0;
                if (saved)
                {
                    _logger.LogDebug("Update operation successful");
                }
                else
                {
                    _logger.LogDebug("Update operation failed");
                }
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }

        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                bool saved = false;
                _logger.LogDebug("Disabling Order");
                Order order = dao.Orders.
                    Where(q => q.Id == id).FirstOrDefault();
                if(order == null)
                {
                    _logger.LogDebug("Operation failed. Record not found");
                    return false;
                }
                order.IsActive = 0;
                saved = await dao.SaveChangesAsync() > 0;
                if (!saved)
                    _logger.LogDebug("Disable operation failed.");
                else
                    _logger.LogDebug("Disable operation success");
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }

        }
        public async Task<bool> ActivateAsync(int id)
        {
            try
            {
                bool saved = false;
                _logger.LogDebug("Activating Order");
                Order order = dao.Orders.
                    Where(q => q.Id == id).FirstOrDefault();
                if (order == null)
                {
                    _logger.LogDebug("Operation failed. Record not found");
                    return false;
                }
                order.IsActive = 0;
                saved = await dao.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Activate operation failed.");
                }
                else
                {
                    _logger.LogDebug("Activation operation success");
                }
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }

        }

        public async Task<bool> AdminDeleteAsync(int id)
        {
            try
            {
                _logger.LogDebug("Admin deleteing Order");
                bool saved = false;
                Order order = dao.Orders.
                    Where(q => q.Id == id).FirstOrDefault();
                dao.Orders.Remove(order);
                saved = await dao.SaveChangesAsync() > 0;
                if (!saved)
                    _logger.LogDebug("Delete operation failed");
                else
                    _logger.LogDebug("Delete operation success");
                return saved;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }

        }
        public Order Get(int id)
        {
            try
            {
                _logger.LogDebug("Fetching Order by ID");
                var order = dao.Orders
                    .Include(r => r.OrderItems)
                    .Where(order => order.Id == id)
                    .FirstOrDefault();
                if (order == null)
                {
                    _logger.LogDebug("Fetch operation failed. No record found");
                    return order;
                }
                _logger.LogDebug("Order found");
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public List<Order> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching all Orders");
                var orders = dao.Orders.Include(r => r.OrderItems)
                .Where(i => i.IsActive == 1).ToList<Order>();
                if (orders.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return orders;
                }
                _logger.LogDebug("Orders found");
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public List<Order> AdminGetAll()
        {
            try
            {
                _logger.LogDebug("Adming fetching all orders");
                var orders = dao.Orders
                    .Include(r => r.OrderItems)
                    .ToList<Order>();
                if (orders.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return orders;
                }
                _logger.LogDebug("Orders found");
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
    }
}
