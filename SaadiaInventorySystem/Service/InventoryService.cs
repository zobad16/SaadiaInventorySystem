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
                bool isexists = dao.Inventories.Any(x => x.PartName == data.PartName);

                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
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
        public async Task<bool> UpdateAsync(Inventory data) 
        {
            try
            {
                Inventory part = (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
                part.AvailableQty = data.AvailableQty;
                part.Description = data.Description;
                part.Location = data.Location;
                part.OldPart = data.OldPart;
                part.PartName = data.PartName;
                part.Price = data.Price;
                part.Rem = data.Rem;
                part.DateUpdate = DateTime.Now;
                return await dao.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return false; 
        }
        public async Task<bool> DeleteAsync(string id) 
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

            }
            return false;
        }
        public async Task<bool> AdminDeleteAsync(string id) 
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
        public Inventory Get(string id) {
            return  (Inventory)dao.Inventories
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
        }
        public List<Inventory> GetAll() 
        {
            
            var inventories = dao.Inventories.ToList<Inventory>();
            return inventories;
        }
    }
}
