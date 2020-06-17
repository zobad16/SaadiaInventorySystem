using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaadiaInventorySystem.Service
{
    public class RoleService
    {
        
        private readonly AppDbContext dao;
        public RoleService(AppDbContext _db)
        {
            dao = _db;
        }
        public async Task<bool> AddAsync(Role data)
        {
            try
            {
                bool isexists = dao.Roles.Any(x => x.Id == data.Id);
               
                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
                    
                    await dao.Roles.AddAsync(data);
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
        public async Task<bool> UpdateAsync(Role data)
        {
            try
            {
                Role role = (Role)dao.Roles
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
                role.DateUpdate = DateTime.Now;
                role.RoleName = data.RoleName;
                return await dao.SaveChangesAsync() > 0;

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
                Role role = (Role)dao.Roles
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                role.IsActive = 0;
                return await dao.SaveChangesAsync() > 0;

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
                Role role = (Role)dao.Roles
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                dao.Remove<Role>(role);
                await dao.SaveChangesAsync();
                return true;

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return false;
        }
        public Role Get(string id)
        {
            return (Role)dao.Roles
                            .Where(r => r.Id.Equals(id)).FirstOrDefault();
        }
        public List<Role> GetAll()
        {
            var role = dao.Roles.AsNoTracking()
                .Where(r=> r.IsActive == 1).ToList();
            return role;
        }
        public List<Role> AdminGetAll()
        {
            
            List<Role> role = dao.Roles.AsNoTracking().ToList();
            return role;
        }
    }
}
