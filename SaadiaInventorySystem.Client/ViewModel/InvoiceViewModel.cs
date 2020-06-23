using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;


namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InvoiceViewModel : BaseViewModel,IViewModel
    {
        private string _name;
        private ObservableCollection<Invoice> _invoices;
        private Invoice _selectedInvoice;
        private Invoice _newInvoice;
        private readonly InvoiceService service;
        
        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public Invoice SelectedInvoice { get => _selectedInvoice; set { _selectedInvoice = value; RaisePropertyChanged(); } }
        public Invoice NewInvoice { get => _newInvoice; set { _newInvoice = value; RaisePropertyChanged(); } }
        public ObservableCollection<Invoice> Invoices { get => _invoices; set { _invoices = value; RaisePropertyChanged(); } }

        public InvoiceViewModel()
        {
            Name = "Invoice";
            service = new InvoiceService();
            Active = 0;
        }
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
        #region Commands


        #endregion
        #region Business Logic
        public string VMName()
        {
            return Name;
        }
        public async Task GetAll()
        {
            try
            {
                Invoices= new ObservableCollection<Invoice>( await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching invoices{ex.Message}");
                throw ex;
            }
        }

        public async Task Get()
        {
            try
            {
                SelectedInvoice =  await service.CallGetService(SelectedInvoice.Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching invoice");
                throw ex;
            }
        }

        public async Task<bool> AddAsync()
        {
            try
            {
                return await service.CallAddService(NewInvoice);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting invoice{ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAsync()
        {
            try
            {
                if (await service.CallUpdateService(SelectedInvoice))
                {
                    MessageBox.Show("Invoice Updated Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error updating Incoive");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching invoice{ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync()
        {
            try
            {
                if (await service.CallDeleteService(SelectedInvoice.Id.ToString()))
                {
                    MessageBox.Show("Invoice Deleted Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Deleting Invoice");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching invoice{ex.Message}");
                return false;
            }
        }

        #endregion
    }
}