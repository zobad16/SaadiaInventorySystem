using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class CustomerViewModel : BaseViewModel, IViewModel
    {
        public CustomerViewModel()
        {
            Name = "Customer";
            service = new CustomerService();
            SaveCommand = new RelayCommand<IClosable>(p => Save(p), p => true);
            DeleteCommand = new RelayCommand(p => Delete(), a => CanEditWindow());
            DisableCommand = new RelayCommand(p => Disable(), a => CanEditWindow());
            ActivateCommand = new RelayCommand(p => ActivateCustomerAsync(), a => CanEditWindow());
            CancelCommand = new RelayCommand<IClosable>(p => Cancel(p), p => true);
            CancelCloseCommand = new RelayCommand<IClosable>(p => CancelClose(p), p => true);
            AddWindowCommand = new RelayCommand(p => OpenAddWindow(), a => true);
            EditWindowCommand = new RelayCommand(p => OpenEditWindow(), a => CanEditWindow());
            NewCustomer = new Customer();
            IsEdit = false;
            IsAdmin = false;
            Active = 0;
        }

        

        #region variables and properties
        private readonly CustomerService service;
        private string name;
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        private Customer newCustomer;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private ICommand _deleteCommand;
        private ICommand _disableCommand;
        private ICommand _activateCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private bool isEdit;
        private bool isAdmin;
        private RelayCommand<IClosable> _cancelCloseCommand;

        public ObservableCollection<Customer> Customers { get => customers; set { customers = value; RaisePropertyChanged(); } }
        public Customer SelectedCustomer { get => selectedCustomer; set { selectedCustomer = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value; }
        public Customer NewCustomer { get => newCustomer; set { newCustomer = value; RaisePropertyChanged(); } }

        #endregion

        #region Commands
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCloseCommand { get => _cancelCloseCommand; set { _cancelCloseCommand = value; RaisePropertyChanged(); } }

        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }

        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }

        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }

        public ICommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public ICommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public ICommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged();} }

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

        #region Open Windows
        private void OpenAddWindow()
        {
            var addwindow = new AddEditCustomerView(this);
            addwindow.ShowDialog();
        }
        private void OpenEditWindow()
        {
            NewCustomer = SelectedCustomer;
            IsEdit = true;
            var addwindow = new AddEditCustomerView(this);
            addwindow.ShowDialog();
        }

        #endregion

        private bool CanEditWindow()
        {
            return SelectedCustomer != null;
        }

        private async void Save(IClosable p)
        {
            if (IsEdit)
            {
                if (await service.CallUpdateService(NewCustomer))
                {
                    MessageBox.Show("Success Customer Updated");
                    p.Close();
                    await GetAll();
                    NewCustomer = null;
                    IsEdit = false;
                }
                else 
                {
                    MessageBox.Show("Customer Update Failed");

                }

            }
            else 
            {
                if (await service.CallAddService(NewCustomer))
                {
                    MessageBox.Show("Success Customer added");
                    p.Close();
                    await GetAll();
                    NewCustomer = null;
                }
            }
            

        }

        private async void Cancel(IClosable p)
        {
            p.Close();
            await GetAll();
        }
        private async void CancelClose(IClosable p)
        {
            await GetAll();
        }
        private async void Disable()
        {
            bool task = await service.CallDeleteService(SelectedCustomer.Id);
            if (task)
            {
                MessageBox.Show("Customer sucessfully disabled");
                await GetAll();
            }
            else
            {
                MessageBox.Show("Customer disable failed");
                await GetAll();
            }
        }
        private async void ActivateCustomerAsync()
        {
            bool task = await service.CallActivateService(SelectedCustomer.Id);
            if (task)
            {
                MessageBox.Show("Customer sucessfully activated");
                await GetAll();
            }
            else
            {
                MessageBox.Show("Error! Customer activation failed!");
                await GetAll();
            }
        }

        private async void Delete()
        {
            if (AppProperties.RoleName == AppProperties.ROLE_ADMIN)
            {
                bool task = await service.CallAdminDeleteService(SelectedCustomer.Id);
                if (task)
                {
                    MessageBox.Show("Customer sucessfully deleted");
                    await GetAll();
                }
                else 
                {
                    MessageBox.Show("Customer delete failed");
                    await GetAll();
                }
            }
            else if (AppProperties.RoleName == AppProperties.ROLE_USER)
            {
                bool task = await service.CallDeleteService(SelectedCustomer.Id);
                if (task)
                {
                    MessageBox.Show("Customer sucessfully deleted");
                    await GetAll();
                }
                else
                {
                    MessageBox.Show("Customer delete failed");
                    await GetAll();
                }
            }
        }


        #region Business Logic

        public async Task GetAll()
        {
            try
            {
                if (AppProperties.RoleName == AppProperties.ROLE_ADMIN)
                {
                    Customers = new ObservableCollection<Customer>(await service.CallAdminGetAllService());
                    IsAdmin = true;
                }
                else if (AppProperties.RoleName == AppProperties.ROLE_USER)
                {
                    Customers = new ObservableCollection<Customer>(await service.CallGetAllService());
                    IsAdmin = false ;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Customer:{ex.Message}");
            }
        }

        public async Task Get()
        {
            try
            {
                await service.CallGetService(SelectedCustomer.Id.ToString());
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                throw ex;
            }
        }

        public async Task<bool> AddAsync()
        {
            try
            {
                if (await service.CallAddService(NewCustomer))
                {
                    MessageBox.Show("New Customer Added Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error adding new Customer");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync()
        {
            try
            {
                if (await service.CallUpdateService(SelectedCustomer))
                {
                    MessageBox.Show("Customer Updated Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error updating Customer");
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
                if (await service.CallDeleteService(SelectedCustomer.Id))
                {
                    MessageBox.Show("Customer Deleted Successfully");
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
        public async Task<bool> AdminDeleteAsync()
        {
            try
            {
                if (await service.CallAdminDeleteService(SelectedCustomer.Id))
                {
                    MessageBox.Show("Customer Deleted Successfully");
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
        public string VMName() 
        {
            return Name;
        }

        
        #endregion
    }
}
