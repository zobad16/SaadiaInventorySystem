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
    public class OldPartService
    {
        private readonly AppDbContext context;
        private readonly ILogger<OldPartService> _logger;

        public OldPartService(AppDbContext db)
        {
            context = db;
        }
        
        
        public async Task<bool> AddAsync(OldPart data)
        {
            try
            {
                _logger.LogDebug("Adding Old part");

                bool saved = false;
                bool isexists = context.Inventories.Any(x => x.PartNumber == data.PartNumber);
                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
                                    
                    await context.OldParts.AddAsync(data);
                 saved = await context.SaveChangesAsync() > 0;

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
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }
        }
        public async Task<bool> UpdateAsync(OldPart data)
        {
            try
            {
                var saved = false;
                OldPart part = (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
                if(part == null)
                {
                    _logger.LogDebug("Update operation failed.Part not found");
                    return false;
                }
                _logger.LogDebug("Part found");
                part.Description = data.Description;
                part.Location = data.Location;
                part.PartNumber = data.PartNumber;
                part.Rem = data.Rem;
                part.DateUpdate = DateTime.Now;
                saved = await context.SaveChangesAsync() > 0;
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
        public async Task<bool> DeleteAsync(string id)
        {
            try
            {
                bool saved = false;
                _logger.LogDebug("Disabling Old Part");
                OldPart part = (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                if(part == null)
                {
                    _logger.LogDebug("Part not found");
                    return false;
                }
                _logger.LogDebug("Part found");
                part.IsActive = 0;
                saved = await context.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Disable operation failed");
                    return saved;
                }
                _logger.LogDebug("Disable operation successful");
                return saved;


            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }
        }
        public async Task<bool> AdminDeleteAsync(string id)
        {
            try
            {
                bool saved = false;
                _logger.LogDebug("Deleting Old Part");
                OldPart part = (OldPart)context.OldParts
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                if (part == null)
                {
                    _logger.LogDebug("Delete operation failed. Record not found");
                    return false;
                }
                _logger.LogDebug("Record found");
                context.Remove<OldPart>(part);
                saved = await context.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Delete operation failed.");
                }
                else
                {
                    _logger.LogDebug("Delete operation success.");
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
        public OldPart Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Old part by id");
                var parts =  (OldPart)context.OldParts
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
        public List<OldPart> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching all Old parts");
                var parts = context.OldParts.Where(i => i.IsActive == 1).ToList();
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
        public List<OldPart> AdminGetAll()
        {

            try
            {
                _logger.LogDebug("Adming Fetching all old parts");
                var parts = context.OldParts.ToList();
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
