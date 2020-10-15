using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class InventoryService
    {
        private readonly AppDbContext dao;
        private readonly ILogger<InventoryService> _logger;
        public InventoryService(AppDbContext _db, ILogger<InventoryService> logger)
        {
            dao = _db;
            _logger = logger;
        }
        public async Task<bool> AddAsync(Inventory data) 
        {
            try
            {
                bool saved = false;
                bool isexists = dao.Inventories.Any(x => x.PartNumber == data.PartNumber);
                bool oldpartExists = dao.OldParts.Any(x => x.Id == data.OldPartFK) || data.OldPart ==null;
                if (!isexists)
                {
                    _logger.LogDebug("Inserting new inventory");
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
                    data.IsActive = 1;
                    if (!oldpartExists) 
                    {
                        _logger.LogDebug("Insert old part");
                        await dao.OldParts.AddAsync(data.OldPart); 
                    }
                    
                    await dao.Inventories.AddAsync(data);
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
                _logger.LogDebug("Insert operation failed. Record already exists.");
                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }
        }
        public async Task<bool> BulkAddAsync(List<Inventory> data)
        {
            try
            {
                foreach (var item in data)
                {
                    item.DateUpdate = DateTime.Now;
                    if (item != null)
                    {
                        if (item.Id == 0)
                        {
                            item.IsActive = 1;
                            item.DateCreated = DateTime.Now;

                        }
                        else { item.DateUpdate = DateTime.Now; }
                    }
                }
                await dao.Inventories.AddRangeAsync(data);      
                return await dao.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }
        }
        public async Task<bool> BulkUpdateAsync(List<Inventory> data)
        {
            try
            {
                foreach (var item in data)
                {
                    if (item != null)
                    {
                        item.IsActive = 1;
                        item.DateUpdate = DateTime.Now;
                    }
                }
                dao.Inventories.UpdateRange(data);

                return await dao.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }
        }

        public async Task<bool> UpdateAsync(Inventory data) 
        {
            try
            {
                bool saved = false;
                _logger.LogDebug("Updating Inventory");
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
                if (part == null)
                {
                    _logger.LogDebug("Update operation failed. Inventory part not found");
                    return false;
                }

                _logger.LogDebug("Inventory part found");
                
                part.AvailableQty = data.AvailableQty;
                part.Description = data.Description;
                part.Location = data.Location;
                part.OldPartFK = data.OldPartFK;
                part.OldPart = data.OldPart;
                part.PartNumber = data.PartNumber;
                part.UnitPrice = data.UnitPrice;
                part.Rem = data.Rem;
                part.IsActive = 1;
                part.DateUpdate = DateTime.Now;
                
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
        public async Task<bool> ActivateAsync(int id) 
        {
            try
            {
                bool saved = false;
                _logger.LogDebug("Activating Inventory part");
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id == id).FirstOrDefault();
                if (part == null)
                {
                    _logger.LogDebug("Operation failed. Record not found");
                    return false;
                }
                part.IsActive = 1;
                part.DateUpdate = DateTime.Now;
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
        public async Task<bool> DeactivateAsync(int id) 
        {
            try
            {
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id == id).FirstOrDefault();
                part.IsActive = 0;
                part.DateUpdate = DateTime.Now;
                return await dao.SaveChangesAsync() > 0;

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
                _logger.LogDebug("Disabling Inventory part");
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                part.IsActive = 0;
                if (part == null)
                {
                    _logger.LogDebug("Operation failed. Record no found");
                    return false;
                }
                saved = await dao.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Diasable operation failed");
                }
                else
                {
                    _logger.LogDebug("Disable operation successful");
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
                bool saved = false;
                _logger.LogDebug("Admin deleting Inventory part");
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                if (part == null)
                {
                    _logger.LogDebug("Delete operation failed. Record not found");
                }
                dao.Remove<Inventory>(part);
                saved = await dao.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Delete operation failed");
                }
                else
                {
                    _logger.LogDebug("Delete operation successful");
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
        public Inventory Get(int id) {
            try
            {
                _logger.LogDebug("Fetching Inventory part by ID");
                var parts = (Inventory)dao.Inventories.AsNoTracking()
                            .Include(i => i.OldPart)
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                if (parts == null)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return parts;
                }
                _logger.LogDebug("Parts found");
                return parts;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public Inventory GetByPartNumber(string part) {
            try
            {
                _logger.LogDebug("Fetchin Inventory part by part number");
                var parts = (Inventory)dao.Inventories.AsNoTracking()
                            .Include(i => i.OldPart)
                            .Where(part => part.PartNumber.Equals(part)).FirstOrDefault();
                if (parts == null)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return parts;
                }
                _logger.LogDebug("Parts found");
                return parts;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public List<Inventory> GetAll() 
        {
            try
            {
                _logger.LogDebug("Fetching all Inventory parts");
                var parts = dao.Inventories.AsNoTracking().Include(inventory => inventory.OldPart).Where(i => i.IsActive == 1).ToList();
                if (parts.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return parts;
                }
                _logger.LogDebug("Parts found");
                return parts;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public List<Inventory> AdminGetAll() 
        {
            try
            {
                _logger.LogDebug("Adming fetching all Inventory parts");
                var parts = dao.Inventories.AsNoTracking().Include(inventory => inventory.OldPart).ToList();
                if (parts.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return parts;
                }
                _logger.LogDebug("Parts found");
                return parts;
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
