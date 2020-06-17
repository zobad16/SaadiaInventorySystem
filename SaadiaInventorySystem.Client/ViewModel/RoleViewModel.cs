using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class RoleViewModel : BaseViewModel, IViewModel
    {
        private readonly RoleService service;
        private string name;
        private ObservableCollection<Role> roles;
        private Role selectedRole;
        private Role newRole;

        public ObservableCollection<Role> Roles { get => roles; set { roles = value; RaisePropertyChanged(); } }
        public Role SelectedRole { get => selectedRole; set { selectedRole = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value; }
        public Role NewRole { get => newRole; set { newRole = value; RaisePropertyChanged(); } }

        public RoleViewModel()
        {
            Name = "Role";
            service = new RoleService();
        }


        #region Business Logic
        public async Task<bool> AddAsync()
        {
            try
            {
                if (await service.CallAddService(NewRole))
                {
                    MessageBox.Show("New Role Added Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error adding new Role");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync()
        {
            try
            {
                if (await service.CallDeleteService(SelectedRole.Id.ToString()))
                {
                    MessageBox.Show("Role Deleted Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Deleting Role");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                return false;
            }
        }

        public async Task Get()
        {
            try
            {
                await service.CallGetService(SelectedRole.Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                throw ex;
            }
        }

        public async Task GetAll()
        {
            try
            {
                Roles = new ObservableCollection<Role>(await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Role:{ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync()
        {
            try
            {
                if (await service.CallUpdateService(SelectedRole))
                {
                    MessageBox.Show("Role Updated Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error updating Role");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                return false;
            }
        }
        #endregion
    }
}
