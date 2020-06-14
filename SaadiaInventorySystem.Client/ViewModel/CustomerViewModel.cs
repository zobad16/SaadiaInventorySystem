using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class CustomerViewModel : BaseViewModel
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

        public CustomerViewModel(Customer _customer)
        {
            Name = "Customer";
            service = new CustomerService();
        }


        #region Business Logic

        private async Task<bool> Create()
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
                throw ex;
            }
        }

        private async void GetAll()
        {
            try
            {
                Customers = new ObservableCollection<Customer>(await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Customer");
                throw ex;
            }
        }
        private async void Get()
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
        private async Task<bool> Update()
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
                    MessageBox.Show("Error updating Quotation");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                throw ex;
            }
        }
        private async Task<bool> Delete()
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
                throw ex;
            }
        }
        #endregion
    }
}
