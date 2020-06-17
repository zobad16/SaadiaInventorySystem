using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class CustomerViewModel : BaseViewModel, IViewModel
    {
        private readonly CustomerService service;
        private string name;
        private ObservableCollection<Customer> customers;
        private Customer selectedCustomer;
        private Customer newCustomer;

        public ObservableCollection<Customer> Customers { get => customers; set { customers = value; RaisePropertyChanged(); } }
        public Customer SelectedCustomer { get => selectedCustomer; set { selectedCustomer = value; RaisePropertyChanged(); } }

        public string Name { get => name; set => name = value;}
        public Customer NewCustomer { get => newCustomer; set { newCustomer = value; RaisePropertyChanged(); } }

        public CustomerViewModel()
        {
            Name = "Customer";
            service = new CustomerService();
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
