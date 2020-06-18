using Microsoft.EntityFrameworkCore;
using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class OldPartService
    {
        public OldPartService(AppDbContext db)
        {
            context = db;
        }
        private readonly AppDbContext context;
        
        public async Task<bool> AddAsync(OldPart data)
        {
            try
            {
                bool isexists = context.Inventories.Any(x => x.PartNumber == data.PartNumber);
                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
                                    
                    await context.OldParts.AddAsync(data);
                    return await context.SaveChangesAsync() > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> UpdateAsync(OldPart data)
        {
            try
            {
                OldPart part = (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
                part.Description = data.Description;
                part.Location = data.Location;
                part.PartNumber = data.PartNumber;
                part.Rem = data.Rem;
                part.DateUpdate = DateTime.Now;
                return await context.SaveChangesAsync() > 0;

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
                OldPart part = (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                part.IsActive = 0;
                return await context.SaveChangesAsync() > 0;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        public async Task<bool> AdminDeleteAsync(string id)
        {
            try
            {
                OldPart part = (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                context.Remove<OldPart>(part);
                await context.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return false;
        }
        public OldPart Get(string id)
        {
            return (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
        }
        public List<OldPart> GetAll()
        {

            /*var query = from photo in context.Set<PersonPhoto>()
                        join person in context.Set<Person>()
                            on photo.PersonPhotoId equals person.PhotoId
                        select new { person, photo };*/
            var oldPart = context.OldParts.Where(i => i.IsActive == 1).ToList();
            return oldPart;
        }
        public List<OldPart> AdminGetAll()
        {

            /*var query = from photo in context.Set<PersonPhoto>()
                        join person in context.Set<Person>()
                            on photo.PersonPhotoId equals person.PhotoId
                        select new { person, photo };*/
            var oldPart = context.OldParts.ToList();
            return oldPart;
        }
    }
}
