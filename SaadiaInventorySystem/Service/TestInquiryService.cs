using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Service
{
    public class TestInquiryService:IInquiryService
    {
        private List<Inquiry> _dao;
        public List<Inquiry>Dao
        {
            get { if (_dao == null) return new List<Inquiry>(); else return _dao; }
            set { _dao = value; }
        }
        public TestInquiryService()
        {
            _dao = new List<Inquiry>() 
            {
                new Inquiry()
                {
                    Id = 1,
                    Attn = "Mr. Gohar",
                    DateIssued = new DateTime(2020,08,08),
                    Discount = 5,
                    Ms = "Al-Futtaim",
                    IsActive = 1,
                    Items = new List<InquiryItem>()
                    {
                        new InquiryItem()
                        {
                            InquiryId = 1,
                            InventoryId = 1,
                            Inventory = new Inventory(){
                                Id=1,
                                Description = "Inventory Part 1",
                                AvailableQty = 3,
                                IsActive = 1,
                                PartNumber = "12345",
                                Rem="GN",
                                Location="1B1",
                                UnitPrice = 350
                            },
                            OfferedQty = 3,
                            IsActive = 1,
                            OfferedPrice= 300,
                            Total=900,
                        },
                        new InquiryItem()
                        {
                            InquiryId = 1,
                            InventoryId = 2,
                            Inventory = new Inventory(){
                                Id=1,
                                Description = "Inventory Part 2",
                                AvailableQty = 3,
                                IsActive = 1,
                                PartNumber = "12335",
                                Rem="GN",
                                Location="1B1",
                                UnitPrice = 350
                            },
                            OfferedQty = 3,
                            IsActive = 1,
                            OfferedPrice= 300,
                            Total=900,
                        }
                    }
                    
                },
            };

        }
        public async Task<bool> AddAsync(Inquiry inquiry)
        {
            Dao.Add(inquiry);
            return true;
        }

        public async Task<bool> BulkAddAsync(List<Inquiry> inquiry)
        {
            Dao.AddRange(inquiry);
            return true;
        }

        public async Task<bool> BulkUpdateAsync(List<Inquiry> inquiry)
        {
            try
            {
                foreach (var item in inquiry)
                {
                    var change = Dao.Where(i => item.Id == i.Id).FirstOrDefault();
                    change = item;
                }
                return true;
            }
            catch{ return false; }
            
        }

        public async Task<bool> UpdateAsync(Inquiry inquiry)
        {
            try
            {
                var change = Dao.Where(i => inquiry.Id == i.Id).FirstOrDefault();
                change = inquiry;
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> ActivateAsync(int id)
        {
            try
            {
                var change = Dao.Where(i => id == i.Id).FirstOrDefault();
                change.IsActive = 1;

                return true;
            }
            catch { return false; }
        }

        public async Task<Inquiry>  Get(int id)
        {
            try {
                var inquiry = Dao.Where(i => i.Id == id).FirstOrDefault();
                if (inquiry != null)
                    return inquiry;
                else
                    return null;
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        public async Task<List<Inquiry>> GetAll()
        {
            try 
            {
                return Dao.Where(i=> i.IsActive == 1).ToList();
            }
            catch 
            {
                return null;
            }
        }

        public async Task< List<Inquiry>> AdminGetAll()
        {
            try
            {
                return Dao;
            }
            catch
            {
                return null;
            }
        }

        
        public async Task<bool> DeactivateAsync(int id)
        {
            try
            {
                var change = Dao.Where(i => id == i.Id).FirstOrDefault();
                change.IsActive = 1;

                return true;
            }
            catch { return false; }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var change = Dao.Where(i => id == i.Id).FirstOrDefault();
                change.IsActive = 0;

                return true;
            }
            catch { return false; }
        }

        public async Task<bool> AdminDeleteAsync(int id)
        {
            try
            {
                var change = Dao.Where(i => id == i.Id).FirstOrDefault();
                Dao.Remove(change);

                return true;
            }
            catch { return false; }
        }
    }
}
