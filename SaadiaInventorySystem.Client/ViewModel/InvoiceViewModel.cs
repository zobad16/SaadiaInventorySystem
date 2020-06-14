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
    public class InvoiceViewModel : BaseViewModel
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
        }
        #region Commands


        #endregion
        #region Business Logic
        private async Task<bool> Create()
        {
            try
            {
                return await service.CallAddService(NewInvoice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting invoice");
                throw ex;
            }
        }
        private async Task<List<Invoice>> GetAll()
        {
            try
            {
                return await service.CallGetAllService();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching invoices");
                throw ex;
            }
        }
        private async Task<Invoice> Get()
        {
            try
            {
                return await service.CallGetService(SelectedInvoice.Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching invoice");
                throw ex;
            }
        }
        private async Task<bool> Update()
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
                MessageBox.Show("Error fetching invoice");
                throw ex;
            }
        }
        private async Task<bool> Delete()
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
                MessageBox.Show("Error fetching invoice");
                throw ex;
            }
        }

        #endregion
    }
}