using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class UserViewModel : BaseViewModel, IViewModel
    {
        private readonly UserService service;
        private string name;
        private ObservableCollection<User> users;
        private User selectedUser;
        private User newUser;
        private ObservableCollection<Role> rolesList;
        private ICommand _addWindowCommand;
        private RelayCommand<IClosable> _saveCommand;

        public ObservableCollection<User> Users { get => users; set { users = value; RaisePropertyChanged(); } }
        public User SelectedUser { get => selectedUser; set { selectedUser = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value; }
        public User NewUser { get => newUser; set { newUser = value; RaisePropertyChanged(); } }

        public ObservableCollection<Role> RolesList { get => rolesList; set { rolesList = value; RaisePropertyChanged();} }

        public UserViewModel()
        {
            Name = "User";
            service = new UserService();
            SaveCommand = new RelayCommand<IClosable>(p => Save(p) , p=>CanAdd());
            //NewUser = new User();
        }

        
        public ICommand AddWindowCommand
        {
            get
            {
                if (_addWindowCommand == null)
                {
                    _addWindowCommand = new RelayCommand(
                        p => OpenAddWindow(),
                        p => CanAdd());
                }

                return _addWindowCommand;
            }
        }

        public RelayCommand<IClosable> SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                RaisePropertyChanged();
            }
        }

        private async void OpenAddWindow()
        {
            RoleService _service = new RoleService();
            RolesList = new ObservableCollection<Role>( await _service.CallGetAllService());
         
            NewUser= new User();
            NewUser.Role = RolesList[0];
            AddUserView adduser = new AddUserView(this);
            adduser.ShowDialog();
        }
        private async void Save(IClosable window)
        {
            NewUser.IsActive = 1;
            //NewUser.Role = null;
            if (await service.CallAddService(NewUser))
            {
                window.Close();
                await service.CallGetAllService();
            }
            else 
            {
                MessageBox.Show("Error: Unable to add new User");
            }
            
        }

        public bool CanAdd()
        {
            return true;
        }

        #region Business Logic

        public async Task<bool> AddAsync()
        {
            try
            {
                if (await service.CallAddService(NewUser))
                {
                    MessageBox.Show("New User Added Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error adding new User");
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
                if (await service.CallDeleteService(SelectedUser.Id.ToString()))
                {
                    MessageBox.Show("User Deleted Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Deleting Customer");
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
                await service.CallGetService(SelectedUser.Id.ToString());
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
                Users = new ObservableCollection<User>(await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Customer:{ex.Message}");
            }
        }

        public async Task<bool> UpdateAsync()
        {
            try
            {
                if (await service.CallUpdateService(SelectedUser))
                {
                    MessageBox.Show("User Updated Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error updating User");
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
