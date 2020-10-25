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
    public class InquiryService: IInquiryService
    {
        private readonly AppDbContext db;
        private readonly ILogger<InquiryService> _logger;
        public InquiryService(ILogger<InquiryService> logger, AppDbContext data)
        {
            db = data;
            _logger = logger;

        }
        public async Task<bool> AddAsync(Inquiry data)
        {
            try
            {
                _logger.LogDebug("Inserting Inquiry");
                data.IsActive = 1;
                data.DateCreated = DateTime.Now;
                data.DateUpdated = DateTime.Now;
                foreach (var item in data.Items)
                {
                    if (item.Inventory != null)
                    {
                        item.Inventory.DateCreated = DateTime.Now;
                        item.Inventory.DateUpdate = DateTime.Now;
                        item.Inventory.IsActive = 1;
                    }
                }

                bool exists = db.Inquirys.Any(q => q.Id.Equals(data.Id));

                if (!exists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdated = DateTime.Now;
                    foreach (var item in data.Items)
                    {
                        item.DateAdded = DateTime.Now;
                        item.DateUpdated = DateTime.Now;
                    }
                    await db.Inquirys.AddAsync(data);
                    int results = await db.SaveChangesAsync();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Inquiry: Insert operation success. Records Inserted {a}", results);
                    }
                    else
                    {
                        _logger.LogDebug("Inquiry: Insert operation Failed. Records inserted {b}", results);
                    }
                    return success;
                }
                _logger.LogDebug("Insert operation failed. Duplicate record found");
            }
            catch (Exception ex)
            {
                _logger.LogError("Adding Inquiry threw an Exception:{exception} ", ex.Message);
                _logger.LogError("Adding Inquiry threw an Exception:{exception} ", ex.InnerException.ToString());


            }
            return false;
        }

        public async Task<bool> BulkAddAsync(List<Inquiry> inquiry)
        {
            try
            {
                _logger.LogDebug("Bulk Inserting Inquirys");
                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var item in inquiry)
                    {
                        item.IsActive = 1;
                        item.DateCreated = DateTime.Now;
                        item.DateUpdated = DateTime.Now;

                        foreach (var part in item.Items)
                        {
                            if (part.Inventory != null)
                            {
                                if (part.Inventory.Id >= 1)
                                {
                                    part.InventoryId = part.Inventory.Id;
                                }
                                else {
                                    part.Inventory.IsActive = 1;
                                    part.Inventory.DateCreated = DateTime.Now;
                                    part.Inventory.DateUpdate = DateTime.Now;
                                }
                                
                            }
                            
                        }
                        await db.AddAsync(item);
                    }
                    //db.Inquirys.AddRange(inquiry);
                    int results = db.SaveChanges();
                    if (results > 0)
                    {
                        _logger.LogDebug("Inquiry bulk insert success. Records inserted {records}", results);
                        await transaction.CommitAsync();
                        return true;
                    }
                    else {
                        _logger.LogDebug("Inquiry bulk insert failed. No records were saved");
                        return false;
                    }
                    
                }    
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry Bulk Add: Error: {exception} ", ex.Message);
                _logger.LogError("Exception Inner exception details: {exception} ", ex.InnerException.ToString());
                return false;
            }
            
        }

        public async Task<bool> BulkUpdateAsync(List<Inquiry> inquiry)
        {
            try
            {
                _logger.LogDebug("Bulk Updating inquirys");
                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var inq in inquiry)
                    {
                        var _inq = db.Inquirys.AsTracking()
                            .Where(pk => pk.Id == inq.Id)
                            .FirstOrDefault();
                        if (_inq == null)
                        {
                            await transaction.CommitAsync();
                            return await BulkAddAsync(inquiry);
                        }
                        if (inq != null)
                        {
                            inq.IsActive = 1;
                            inq.DateCreated = DateTime.Now;
                            inq.DateUpdated = DateTime.Now;
                            inq.DateIssued = DateTime.Now;
                        }
                        
                        foreach (var item in inq.Items)
                        {
                            if (item != null)
                            {
                                item.IsActive = 1;
                                item.DateUpdated = DateTime.Now;
                                item.DateAdded = DateTime.Now;
                                if (item.Inventory != null)
                                {
                                    if (item.Inventory.Id >= 1)
                                    {
                                        item.InventoryId = item.Inventory.Id;
                                    }
                                    else
                                    {
                                        item.Inventory.IsActive = 1;
                                        item.Inventory.DateCreated = DateTime.Now;
                                        item.Inventory.DateUpdate = DateTime.Now;
                                    }
                                    //item.Inventory.IsActive = 1;
                                    //item.Inventory.DateCreated = DateTime.Now;
                                    //item.Inventory.DateUpdate = DateTime.Now;
                                }
                            }
                        }
                        _inq.InquiryNumber = !string.IsNullOrWhiteSpace(inq.InquiryNumber) ? inq.InquiryNumber:"";
                        _inq.Message = !string.IsNullOrWhiteSpace(inq.Message) ? inq.Message : "";
                        _inq.Ms = !string.IsNullOrWhiteSpace(inq.Ms) ? inq.Ms : "";
                        _inq.Note = !string.IsNullOrWhiteSpace(inq.Note) ? inq.Note : "";
                        _inq.Vat = inq.Vat;
                        _inq.VatPercent = inq.VatPercent;
                        _inq.Items = inq.Items;
                        db.Inquirys.Update(_inq);
                    }
                    int results = db.SaveChanges();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Inquiry Bulk Insert Success. Records updated {a}", results);
                        await transaction.CommitAsync();
                    }
                    else
                    {
                        _logger.LogDebug("Inquiry Bulk Insert Failed. Records updated {a}", results);
                    }
                    return success;


                }                               
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry Bulk Update: Error:{exception} ", ex.Message);
                _logger.LogError("Inner Exception details: {a}", ex.InnerException.ToString());
                return false;

            }
        }

        public async Task<bool> UpdateAsync(Inquiry data)
        {
            try
            {
                _logger.LogDebug("Updating Quotations");
                Inquiry inquiry = db.Inquirys.AsTracking()
                    .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(data.Id)).FirstOrDefault();

                if (inquiry != null)
                {
                    _logger.LogDebug("inquiry found");
                }
                else
                {
                    _logger.LogDebug("Update operation failed. Inquiry not found");
                    return false;
                }
                inquiry.InquiryNumber = data.InquiryNumber;
                inquiry.Attn = !String.IsNullOrWhiteSpace(data.Attn) ? data.Attn: "";
                inquiry.IsActive = data.IsActive;
                inquiry.Items = data.Items;
                inquiry.Message = !String.IsNullOrWhiteSpace(data.Message)? data.Message: "";
                inquiry.Ms = !String.IsNullOrWhiteSpace(data.Ms)? data.Ms: "";
                inquiry.Note = !String.IsNullOrWhiteSpace(data.Note)?data.Note:"";
                inquiry.Discount = data.Discount;
                inquiry.Vat = data.Vat;
                inquiry.VatPercent = data.VatPercent;
                data.DateUpdated = DateTime.Now;
                db.Inquirys.Update(inquiry);
                int results = await db.SaveChangesAsync();
                bool success = results > 0;
                if (success)
                {
                    _logger.LogDebug("Inquirys Update Success. Records updated {a}", results);
                }
                else
                {
                    _logger.LogDebug("Inquirys Update Failed. Records updated {a}", results);
                }
                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry Update Failed. Returned an exception: {a}", ex.Message);
                _logger.LogError("Stack trace: {a}", ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> ActivateAsync(int id)
        {
            try
            {
                _logger.LogDebug("Activating Quotations");
                Inquiry inquiry = db.Inquirys
                    .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(id)).FirstOrDefault();

                if (inquiry != null)
                {
                    _logger.LogDebug("inquiry found");
                    inquiry.DateUpdated = DateTime.Now;
                    inquiry.IsActive = 1;
                    int results = await db.SaveChangesAsync();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Inquiry Activated Success. Records updated {a}", results);
                    }
                    else
                    {
                        _logger.LogDebug("Inquiry activation Failed. Records updated {a}", results);
                    }
                    return success;
                }
                else
                {
                    _logger.LogDebug("Activate operation failed. Inquiry not found");
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry activation Failed. Returned an exception: {a}", ex.Message);
                _logger.LogError("Stack trace: {a}", ex.StackTrace);
                return false;
            }
        }

        public async Task<Inquiry>Get(int id)
        {
            try
            {
                _logger.LogDebug("Fetching Inquiry with id: {id}", id);

                Inquiry inquiry = db.Inquirys.AsNoTracking()
                     .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                     .Where(q => q.Id.Equals(id)).FirstOrDefault();
                if (inquiry != null)
                {
                    _logger.LogDebug("Inquiry found");
                }
                else
                {
                    _logger.LogDebug("Inquiry not found");
                }
                return inquiry;
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry get threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
                return null;
            }
        }

        public List<Inquiry> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching Inquiry");

                var inquiry = db.Inquirys.AsNoTracking()
                     .Include(r => r.Items)
                     .ThenInclude(r => r.Inventory)
                     .Where(q => q.IsActive == 1).ToList<Inquiry>();
                int records = inquiry.Count();
                _logger.LogDebug("Inquiry records fetched: {record}", records);
                return inquiry;
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry get all threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
                return null;
            }
        }

        public List<Inquiry> AdminGetAll()
        {
            try
            {
                _logger.LogDebug("Fetching Inquiry");

                var inquiry = db.Inquirys.AsNoTracking()
                     .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                     .ToList<Inquiry>();
                int records = inquiry.Count();
                _logger.LogDebug("Inquiry records fetched: {record}", records);
                return inquiry;
            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry get all threw an exception. Exception message: {message}", ex.Message);
                _logger.LogError("Stack trace: {trace}", ex.StackTrace);
                return null;
            }
        }

        public async Task<Inquiry> GetByPartNumber(string part)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeactivateAsync(int id)
        {
            try
            {
                _logger.LogDebug("Deactivating Quotations");
                Inquiry inquiry = db.Inquirys
                    .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(id)).FirstOrDefault();

                if (inquiry != null)
                {
                    _logger.LogDebug("inquiry found");
                    inquiry.DateUpdated = DateTime.Now;
                    inquiry.IsActive = 0;
                    int results = await db.SaveChangesAsync();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Inquiry Deactivate Success. Records updated {a}", results);
                    }
                    else
                    {
                        _logger.LogDebug("Inquiry deactivate Failed. Records updated {a}", results);
                    }
                    return success;
                }
                else
                {
                    _logger.LogDebug("Activate operation failed. Inquiry not found");
                    return false;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry activation Failed. Returned an exception: {a}", ex.Message);
                _logger.LogError("Stack trace: {a}", ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.LogDebug("Deactivating Quotations");
                Inquiry inquiry = db.Inquirys
                    .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(id)).FirstOrDefault();

                if (inquiry != null)
                {
                    _logger.LogDebug("inquiry found");
                    inquiry.DateUpdated = DateTime.Now;
                    inquiry.IsActive = 0;
                    int results = await db.SaveChangesAsync();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Inquiry Deactivate Success. Records updated {a}", results);
                    }
                    else
                    {
                        _logger.LogDebug("Inquiry deactivate Failed. Records updated {a}", results);
                    }
                    return success;
                }
                else
                {
                    _logger.LogDebug("Activate operation failed. Inquiry not found");
                    return false;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry activation Failed. Returned an exception: {a}", ex.Message);
                _logger.LogError("Stack trace: {a}", ex.StackTrace);
                return false;
            }
        }

        public async Task<bool> AdminDeleteAsync(int id)
        {
            try
            {
                _logger.LogDebug("Deactivating Quotations");
                Inquiry inquiry = db.Inquirys
                    .Include(r => r.Items)
                    .ThenInclude(r => r.Inventory)
                    .Where(q => q.Id.Equals(id)).FirstOrDefault();

                if (inquiry != null)
                {
                    _logger.LogDebug("inquiry found");
                    db.Inquirys.Remove(inquiry);
                    int results = await db.SaveChangesAsync();
                    bool success = results > 0;
                    if (success)
                    {
                        _logger.LogDebug("Inquiry Admin deleted successfully. Records updated {records}", results);
                    }
                    else
                    {
                        _logger.LogDebug("Inquiry Admin delete failed. Records updated {records}", results);
                    }

                   
                    return success;
                }
                else
                {
                    _logger.LogDebug("Activate operation failed. Inquiry not found");
                    return false;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError("Inquiry activation Failed. Returned an exception: {a}", ex.Message);
                _logger.LogError("Stack trace: {a}", ex.StackTrace);
                return false;
            }
        }
    }
}
