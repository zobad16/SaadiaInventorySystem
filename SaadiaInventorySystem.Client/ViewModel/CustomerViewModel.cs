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
            CancelCommand = new RelayCommand<IClosable>(p => Cancel(p), p => true);
            CancelCloseCommand = new RelayCommand<IClosable>(p => CancelClose(p), p => true);
            AddWindowCommand = new RelayCommand(   p => OpenAddWindow(),a => true);
            EditWindowCommand = new RelayCommand(   p => OpenEditWindow(),a => CanEditWindow());
            NewCustomer = new Customer();
            IsEdit = false;
        }

        #region variables and properties
        private readonly CustomerService service;
        private string name;
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        private Customer newCustomer;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private bool isEdit;
        private RelayCommand<IClosable> _cancelCloseCommand;

        public ObservableCollection<Customer> Customers { get => customers; set { customers = value; RaisePropertyChanged(); } }
        public Customer SelectedCustomer { get => selectedCustomer; set { selectedCustomer = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value;}
        public Customer NewCustomer { get => newCustomer; set { newCustomer = value; RaisePropertyChanged(); } }

        #endregion

        #region Commands
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCloseCommand { get => _cancelCloseCommand; set { _cancelCloseCommand = value; RaisePropertyChanged(); } }

        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }

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



        #region Business Logic

        public async Task GetAll()
        {
            try
            {
                Customers = new ObservableCollection<Customer>(await service.CallGetAllService());
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
                if (await service.CallDeleteService(SelectedCustomer.Id.ToString()))
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
        #endregion
    }
}
