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
using SaadiaInventorySystem.Client.View;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class RoleViewModel : BaseViewModel, IViewModel
    {
        public RoleViewModel()
        {
            Name = "Role";
            service = new RoleService();
            SaveCommand = new RelayCommand<IClosable>(p => Save(p), p => true);
            CancelCommand = new RelayCommand<IClosable>(p => Cancel(p), p => true);
            CancelCloseCommand = new RelayCommand<IClosable>(p => CancelClose(p), p => true);
            AddWindowCommand = new RelayCommand(p => OpenAddWindow(), a => true);
            EditWindowCommand = new RelayCommand(p => OpenEditWindow(), (a) => SelectedRole != null);
            NewRole = new Role();
            IsEdit = false;
            Active = 0;
        }

        private readonly RoleService service;
        private string name;
        private ObservableCollection<Role> roles;
        private Role selectedRole;
        private Role newRole;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private bool isEdit;
        private RelayCommand<IClosable> _cancelCloseCommand;

        public ObservableCollection<Role> Roles { get => roles; set { roles = value; RaisePropertyChanged(); } }
        public Role SelectedRole { get => selectedRole; set { selectedRole = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value; }
        public Role NewRole { get => newRole; set { newRole = value; RaisePropertyChanged(); } }

        #region Commands
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCloseCommand { get => _cancelCloseCommand; set { _cancelCloseCommand = value; RaisePropertyChanged(); } }

        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }

        private int active;
        public bool Activate()
        {
            Active = 1;
            return Active == 1;
        }
        public bool Deactivate()
        {
            Active = 0;
            return Active == 0;
        }
        #endregion


        private async void Save(IClosable p)
        {
            if (!IsEdit)
            {
                if (await service.CallAddService(NewRole))
                {
                    MessageBox.Show("Success Role added");
                    p.Close();
                    await GetAll();
                    NewRole = null;
                }
                else
                {
                    MessageBox.Show("Role Insert Failed");
                }

            }
            else 
            {
                if (await service.CallUpdateService(NewRole))
                {
                    MessageBox.Show("Success Role updated");
                    p.Close();
                    await GetAll();
                    NewRole = null;
                    IsEdit = false;
                }
                else
                {
                    MessageBox.Show("Role Update Failed");
                }

            }
           

        }
        public string VMName()
        {
            return Name;
        }
        private async void Cancel(IClosable p)
        {
            p.Close();
            await GetAll();
        }
        private async void CancelClose(IClosable p)
        {
            //p.Close();
            await GetAll();
        }

        #region Open Windows
        private void OpenAddWindow()
        {
            IsEdit = false;
            AddRoleView window = new AddRoleView(this);
            //window.ShowDialog();
            window.Activate();
            window.ShowDialog();
        }
        private void OpenEditWindow()
        {
            IsEdit = true;
            NewRole = SelectedRole;

            var addwindow = new AddRoleView(this);
            addwindow.ShowDialog();
            addwindow.Activate();
        }

        #endregion

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
