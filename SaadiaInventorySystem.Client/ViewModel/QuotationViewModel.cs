﻿using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class QuotationViewModel : BaseViewModel
    {
        private string _name;
        private readonly QuotationService service;
        private Quotation _quotation;
        private Quotation _selectedQuotation;
        private Quotation _newQuotation;
        private ObservableCollection<Quotation> _quotations;
        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }

        public Quotation Quotation { get => _quotation; set { _quotation = value; RaisePropertyChanged(); } }
        public ObservableCollection<Quotation> Quotations { get => _quotations; set { _quotations = value; RaisePropertyChanged(); } }
        public Quotation SelectedQuotation { get => _selectedQuotation; set { _selectedQuotation = value; RaisePropertyChanged(); } }
        public Quotation NewQuotation { get => _newQuotation; set { _newQuotation = value; RaisePropertyChanged(); } }

        public QuotationViewModel()
        {
            Name = "Quotation";
            service = new QuotationService();
        }
        #region Business Logic

        private async Task<bool> Create()
        {
            try
            {
                if (await service.CallAddService(NewQuotation))
                {
                    MessageBox.Show("New Quotation Added Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error adding new Quotation");
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
                Quotations = new ObservableCollection<Quotation>(await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Quotation");
                throw ex;
            }
        }
        private async void Get()
        {
            try
            {
                await service.CallGetService(SelectedQuotation.Id.ToString());
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
                if (await service.CallUpdateService(SelectedQuotation))
                {
                    MessageBox.Show("Quotation Updated Successfully");
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
                if (await service.CallDeleteService(SelectedQuotation.Id.ToString()))
                {
                    MessageBox.Show("Quotation Deleted Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Deleting Quotation");
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