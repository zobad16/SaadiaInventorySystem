using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InventoryViewModel : BaseViewModel
    {
        private ICommand _addCommand;
        private string _name;
        private string _filePath;
        private ObservableCollection<Inventory> _inventories;
        private Inventory _selectedInventory;
        private Inventory _newInventory;
        private readonly InventoryService service;


        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> Inventories { get => _inventories; set { _inventories = value; RaisePropertyChanged(); } }
        public Inventory SelectedInventory { get => _selectedInventory; set { _selectedInventory = value; RaisePropertyChanged(); } }
        public Inventory NewInventory { get => _newInventory; set { _newInventory = value; RaisePropertyChanged(); } }

        public InventoryViewModel()
        {
            Name = "Inventory";
            FilePath = "";
            service = new InventoryService();
            //GetAll();
        }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        p => Add(),
                        p => CanAdd());
                }

                return _addCommand;
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        
        public void Add()
        {
            AddInventoryView addInventory = new AddInventoryView();
            addInventory.ShowDialog();
            //Open Add Inventory Window
        }
        #region Business Logic

        private async Task<bool> Create()
        {
            try
            {
                if (await service.CallAddService(NewInventory))
                {
                    MessageBox.Show("New Inventory Item Added Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error adding new Inventory");
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
                Inventories = new ObservableCollection<Inventory>(await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Inventories");
                throw ex;
            }
        }
        private async void Get()
        {
            try
            {
                await service.CallGetService(SelectedInventory.Id.ToString());
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
                if (await service.CallUpdateService(SelectedInventory))
                {
                    MessageBox.Show("Inventory Updated Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error updating Inventory");
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
                if (await service.CallDeleteService(SelectedInventory.Id.ToString()))
                {
                    MessageBox.Show("Inventory Deleted Successfully");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Deleting Inventory");
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