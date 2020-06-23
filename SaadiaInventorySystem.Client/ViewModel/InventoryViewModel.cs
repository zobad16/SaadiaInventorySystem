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
    public class InventoryViewModel : BaseViewModel, IViewModel
    {
        public InventoryViewModel()
        {
            Name = "Inventory";
            FilePath = "";
            service = new InventoryService();
            SaveCommand = new RelayCommand<IClosable>(p => Save(p), p => true);
            CancelCommand = new RelayCommand<IClosable>(p => Cancel(p), p => true);
            CancelCloseCommand = new RelayCommand<IClosable>(p => CancelClose(p), p => true);
            AddWindowCommand = new RelayCommand(p => OpenAddWindow(), a => true);
            EditWindowCommand = new RelayCommand(p => OpenEditWindow(), (a )=> SelectedInventory !=null );
            NewInventory = new Inventory() { IsActive = 1};
            IsEdit = false;
            Active = 0;
        }

        

        private ICommand _addCommand;
        private string _name;
        private string _filePath;
        private ObservableCollection<Inventory> _inventories;
        private Inventory _selectedInventory;
        private Inventory _newInventory;
        private ObservableCollection<OldPart> _oldParts;
        private readonly InventoryService service;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _cancelCloseCommand;
        private bool isEdit;

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> Inventories { get => _inventories; set { _inventories = value; RaisePropertyChanged(); } }
        public Inventory SelectedInventory { get => _selectedInventory; set { _selectedInventory = value; RaisePropertyChanged(); } }
        public Inventory NewInventory { get => _newInventory; set { _newInventory = value; RaisePropertyChanged(); } }
        public ObservableCollection<OldPart> OldParts { get => _oldParts; set { _oldParts = value; RaisePropertyChanged(); } }

        #region Commands
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }

        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public RelayCommand<IClosable> CancelCloseCommand { get => _cancelCloseCommand; set { _cancelCloseCommand = value; RaisePropertyChanged(); } }
        private async void CancelClose(IClosable p)
        {
            //p.Close();
            await GetAll();
        }
        private async void Save(IClosable p)
        {
            if (IsEdit)
            {
                if (await service.CallUpdateService(NewInventory))
                {
                    MessageBox.Show("Success Inventory updated");
                    p.Close();
                    await GetAll();
                    NewInventory = null;
                }
                else
                {
                    MessageBox.Show("Inventory update Failed");
                }
            }
            else
            {
                if (await service.CallAddService(NewInventory))
                {
                    MessageBox.Show("Success Inventory added");
                    p.Close();
                    await GetAll();
                    NewInventory = null;
                }
                else 
                {
                    MessageBox.Show("Inventory Insert Failed");
                }

            }
            

        }

        private async void Cancel(IClosable p)
        {
            p.Close();
            await GetAll();
        }
        #endregion
        #region Open Windows
        private async void OpenAddWindow()
        {
            IsEdit = false;
            OldPartService _service = new OldPartService();
            OldParts = new ObservableCollection<OldPart>(await _service.CallGetAllService());
            
            AddInventoryView window = new AddInventoryView(this);
            //window.ShowDialog();
            window.Activate();
            window.ShowDialog();
        }
        private void OpenEditWindow()
        {
            IsEdit = true;
            NewInventory = SelectedInventory;
            var addwindow = new AddInventoryView(this);
            addwindow.ShowDialog();
            addwindow.Activate();
        }

        #endregion

        //public ICommand AddCommand
        //{
        //    get
        //    {
        //        if (_addCommand == null)
        //        {
        //            _addCommand = new RelayCommand(
        //                p => Add(),
        //                p => CanAdd());
        //        }

        //        return _addCommand;
        //    }
        //}

        public bool CanAdd()
        {
            return true;
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

        /*public void Add()
        {
            AddInventoryView addInventory = new AddInventoryView();
            addInventory.ShowDialog();
            //Open Add Inventory Window
        }*/
        public string VMName()
        {
            return Name;
        }
        #region Business Logic

        public async Task GetAll()
        {
            try
            {
                Inventories = new ObservableCollection<Inventory>(await service.CallGetAllService());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Inventories. An unexpected error occured: {ex.Message}");
                //throw ex;
            }
        }

        public async Task Get()
        {
            try
            {
                await service.CallGetService(SelectedInventory.Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                //throw ex;
            }
        }

        public async Task<bool> AddAsync()
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
                return false;
            }
        }

        public async Task<bool> UpdateAsync()
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
                return false;
            };
        }

        public async Task<bool> DeleteAsync()
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
                return false;
            }
        }

        #endregion
    }
}