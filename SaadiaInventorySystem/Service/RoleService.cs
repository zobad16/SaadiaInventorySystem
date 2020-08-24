using SaadiaInventorySystem.Data;
using SaadiaInventorySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SaadiaInventorySystem.Service
{
    public class RoleService
    {
        
        private readonly AppDbContext dao;
        private readonly ILogger<RoleService> _logger;
        public RoleService(AppDbContext _db, ILogger<RoleService> logger)
        {
            dao = _db;
            _logger = logger;
        }
        public async Task<bool> AddAsync(Role data)
        {
            try
            {
                _logger.LogDebug("Adding role");
                bool saved = false;
                bool isexists = dao.Roles.Any(x => x.Id == data.Id);
               
                if (!isexists)
                {
                    data.DateCreated = DateTime.Now;
                    data.DateUpdate = DateTime.Now;
                    data.IsActive = 1;
                    await dao.Roles.AddAsync(data);
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
                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;
            }
        }
        public async Task<bool> UpdateAsync(Role data)
        {
            try
            {
                _logger.LogDebug("Updating Role");
                Role role = (Role)dao.Roles
                            .Where(part => part.Id.Equals(data.Id)).FirstOrDefault();
                if (role != null)
                {
                    _logger.LogDebug("Role Found");
                }
                else 
                {
                    _logger.LogDebug("Role not found");
                    return false;
                }
                role.DateUpdate = DateTime.Now;
                role.RoleName = data.RoleName;
                var saved = await dao.SaveChangesAsync() > 0;
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
                _logger.LogDebug("Disabling role");
                bool saved = false; 
                Role role = (Role)dao.Roles
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                if(role == null)
                {
                    _logger.LogDebug("Operation failed. Role not found");
                    return false;
                }
                role.IsActive = 0;
                saved = await dao.SaveChangesAsync() > 0;
                if (!saved)
                {
                    _logger.LogDebug("Disable operation failed");
                }
                else
                {
                    _logger.LogDebug("Disable operation success");
                }
                return saved;

            }
            catch (System.Exception ex)
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
                _logger.LogDebug("Admin deleting role");
                bool saved =false;
                Role role = (Role)dao.Roles
                            .Where(part => part.Id.Equals(id)).FirstOrDefault();
                if(role == null)
                {
                    _logger.LogDebug("Delete operation failed. Role not found");
                    return false;
                }
                dao.Remove<Role>(role);
                saved = await dao.SaveChangesAsync() >0;
                if(!saved)
                {
                    _logger.LogDebug("Delete operation failed");
                }
                else
                {
                    _logger.LogDebug("Delete operation success");
                }
                return saved;

            }
            catch (System.Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return false;

            }
            return false;
        }
        public Role Get(string id)
        {
            try
            {
                _logger.LogDebug("Fetching Role by ID");
                var role = dao.Roles
                            .Where(r => r.Id.Equals(id)).FirstOrDefault();
                if (role == null)
                {
                    _logger.LogDebug("Fetch operation failed. No record found");
                    return role;
                }
                _logger.LogDebug("Role found");
                return role;
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public List<Role> GetAll()
        {
            try
            {
                _logger.LogDebug("Fetching all roles");
                var roles = dao.Roles.AsNoTracking().ToList();
                if (roles.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No records found");
                    return roles;
                }
                _logger.LogDebug("Roles found");
                return roles;
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
        public List<Role> AdminGetAll()
        {

            try
            {
                _logger.LogDebug("Admin fetching all roles");
                List<Role> roles = dao.Roles.AsNoTracking().ToList();
                if (roles.Count < 1)
                {
                    _logger.LogDebug("Fetch operation failed. No record found");
                    return roles;
                }
                _logger.LogDebug("Roles found");
                return roles;
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An exception occured: {ex}", ex.ToString());
                _logger.LogError("Stack Trace: {trace}", ex.StackTrace);
                return null;

            }
        }
    }
}
