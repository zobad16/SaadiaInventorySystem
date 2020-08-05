using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
        public InventoryService(AppDbContext _db)
        {
            dao = _db;
        }
        public async Task<bool> AddAsync(Inventory data) 
        {
            try
            {
                bool isexists = dao.Inventories.Any(x => x.PartNumber == data.PartNumber);
                bool oldpartExists = dao.OldParts.Any(x => x.Id == data.OldPartFK) || data.OldPart ==null;
                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
                    data.IsActive = 1;
                    if (!oldpartExists) { await dao.OldParts.AddAsync(data.OldPart); }
                    
                    await dao.Inventories.AddAsync(data);
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
                Console.WriteLine($"Inventory Bulk Add: Error: {ex.InnerException.Message.ToString()}");
            }
            return false;
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
                Console.WriteLine($"Inventory Bulk Update: Error: {ex.InnerException.Message.ToString()}");

            }
            return false;
        }

        public async Task<bool> UpdateAsync(Inventory data) 
        {
            try
            {
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
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
                return await dao.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> ActivateAsync(int id) 
        {
            try
            {
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id == id).FirstOrDefault();
                part.IsActive = 1;
                part.DateUpdate = DateTime.Now;
                return await dao.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
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
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteAsync(int id) 
        {
            try
            {
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                part.IsActive = 0;
                return await dao.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> AdminDeleteAsync(int id) 
        {
            try
            {
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                dao.Remove<Inventory>(part);
                await dao.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return false;
        }
        public Inventory Get(int id) {
            return  (Inventory)dao.Inventories
                            .Include(i => i.OldPart)
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
        }
        public Inventory GetByPartNumber(string part) {
            return  (Inventory)dao.Inventories
                            .Include(i => i.OldPart)
                            .Where(part => part.PartNumber.Equals(part)).FirstOrDefault();
        }
        public List<Inventory> GetAll() 
        {

            /*var query = from photo in context.Set<PersonPhoto>()
                        join person in context.Set<Person>()
                            on photo.PersonPhotoId equals person.PhotoId
                        select new { person, photo };*/
            var inventory = dao.Inventories.Include(inventory => inventory.OldPart).Where(i=> i.IsActive == 1).ToList();
            return inventory;
        }
        public List<Inventory> AdminGetAll() 
        {

            /*var query = from photo in context.Set<PersonPhoto>()
                        join person in context.Set<Person>()
                            on photo.PersonPhotoId equals person.PhotoId
                        select new { person, photo };*/
            var inventory = dao.Inventories.Include(inventory => inventory.OldPart).ToList();
            return inventory;
        }
    }
}
