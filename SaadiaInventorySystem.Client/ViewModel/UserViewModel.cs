using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class UserViewModel : BaseViewModel, IViewModel
    {

        public UserViewModel()
        {
            Name = "User";
            service = new UserService();
            SaveCommand = new RelayCommand<IClosable>(p => Save(p), p => CanAdd());
            SavePasswordCommand = new RelayCommand<IClosable>(p => SavePassword(p), p => CanSavePassword());
            AddWindowCommand = new RelayCommand(i => OpenAddWindow(), i => CanAdd());
            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => CanOpenEditWindow());
            OpenForgetPasswordWindowCommand = new RelayCommand(i => OpenEditPasswordWindow(), i => CanOpenEditPasswordWindow());
            DisableCommand = new RelayCommand(i => DisableUser(), i => CanOpenEditPasswordWindow());
            CancelCommand = new RelayCommand<IClosable>(p => Cancel(p), p => true);
            CancelCloseCommand = new RelayCommand<IClosable>(p => CancelClose(p), p => true);
            //NewUser = new User();
            IsEdit = false;
            IsEnabled = true;
            Active = 0;
        }

        
        private readonly UserService service;

        private string name;
        private string confirmPassword;

        private User selectedUser;
        private User newUser;
        private bool isEdit;

        private ObservableCollection<User> users;
        private ObservableCollection<Role> rolesList;

        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private ICommand _openForgetPasswordWindowCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _savePasswordCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _cancelCloseCommand;
        private bool isEnabled;
        private RelayCommand _disableCommand;

        public User SelectedUser { get => selectedUser; set { selectedUser = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value; }
        public User NewUser { get => newUser; set { newUser = value; RaisePropertyChanged(); } }
        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }

        public bool IsEnabled { get => isEnabled; set { isEnabled = value; RaisePropertyChanged(); } }

        public string ConfirmPassword { get => confirmPassword; set { confirmPassword = value; RaisePropertyChanged(); } }

        public ObservableCollection<Role> RolesList { get => rolesList; set { rolesList = value; RaisePropertyChanged(); } }
        public ObservableCollection<User> Users { get => users; set { users = value; RaisePropertyChanged(); } }

        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenForgetPasswordWindowCommand { get => _openForgetPasswordWindowCommand; set { _openForgetPasswordWindowCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand
        {
            get => _saveCommand;
            set
            {
                _saveCommand = value;
                RaisePropertyChanged();
            }
        }
        public RelayCommand<IClosable> SavePasswordCommand
        {
            get => _savePasswordCommand;
            set
            {
                _savePasswordCommand = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<IClosable> CancelCloseCommand { get => _cancelCloseCommand; set { _cancelCloseCommand = value; RaisePropertyChanged(); } }
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
        private async void OpenAddWindow()
        {
            RoleService _service = new RoleService();
            RolesList = new ObservableCollection<Role>(await _service.CallGetAllService());
            IsEdit = false;

            NewUser = new User();
            NewUser.Role = RolesList[0];
            AddUserView adduser = new AddUserView(this);
            adduser.ShowDialog();
            adduser.Activate();
        }
        private async void OpenEditWindow()
        {
            RoleService _service = new RoleService();
            RolesList = new ObservableCollection<Role>(await _service.CallGetAllService());
            IsEnabled = false;
            NewUser = SelectedUser;
            NewUser.RoleId = SelectedUser.Role.Id;

            NewUser.Role = RolesList.Where(i => i.Id == SelectedUser.RoleId).FirstOrDefault();

            IsEdit = true;
            AddUserView adduser = new AddUserView(this);
            adduser.ShowDialog();
            adduser.Activate();
        }
        private void OpenEditPasswordWindow()
        {
            NewUser = SelectedUser;
            IsEnabled = false;
            IsEdit = true;
            EditUserPasswordView editpassword = new EditUserPasswordView(this);
            editpassword.ShowDialog();
            editpassword.Activate();
        }
        private async void CancelClose(IClosable p)
        {
            //p.Close();
            await GetAll();
        }
        private async void Save(IClosable window)
        {
            if (IsEdit)
            {
                if (await service.CallUpdateService(NewUser))
                {
                    window.Close();
                    IsEdit = false;
                }
                else
                {
                    MessageBox.Show("Error: Unable to add new User");
                    IsEdit = false;
                }
                await service.CallGetAllService();
            }
            else
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
        }
        private async void SavePassword(IClosable window)
        {
            if (NewUser.Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match");
                return;
            }
            if (await service.CallUpdatePasswordService(NewUser))
            {
                window.Close();
                await service.CallGetAllService();
                IsEdit = false;
            }
            else
            {
                MessageBox.Show("Error: Unable to Update Password");
                IsEdit = false;
            }
        }
        private async void Cancel(IClosable p)
        {
            p.Close();
            IsEdit = false;
            await GetAll();
        }
        private async void DisableUser()
        {
            if (await service.CallDeleteService(SelectedUser.Id.ToString())) 
            {
                MessageBox.Show("User Disabled");
            }
        }

        public bool CanAdd()
        {
            return true;
        }
        public bool CanOpenEditWindow()
        {
            return SelectedUser != null;
        }
        public bool CanSavePassword()
        {
            return true;
        }
        public bool CanOpenEditPasswordWindow()
        {
            return SelectedUser != null;
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

        public string VMName()
        {
            return Name;
        }
        #endregion
    }
}
