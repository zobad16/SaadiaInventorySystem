using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InquiryViewModel : BaseViewModel, IViewModel
    {
        private string _name;
        private int active;
        private Inquiry _selectedInquiry;
        private Inquiry _newInquiry;
        private ObservableCollection<Inquiry> inquirys;
        private ObservableCollection<Inventory> _partsList;
        private InquiryItem _selectedItem;
        private InquiryItem _removeSelectedItem;
        private readonly InquiryService service;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private ICommand _openAddPartsWindowCommand;
        private ICommand _removePartCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _activateCommand;
        private RelayCommand _disableCommand;
        private RelayCommand<IClosable> _addInquiryItemCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _saveCommand;
        private bool isEdit;
        private bool isAdmin;

        public InquiryViewModel()
        {
            AddWindowCommand = new RelayCommand(i => OpenAddWindow(), i => true);
            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => SelectedInquiry != null); 
            _name = "Inquiry";

            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            AddInquiryItemCommand = new RelayCommand<IClosable>(i => AddInquiryItem(i), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);

            service = new InquiryService();
           
            RemovePartCommand = new RelayCommand(i => RemovePart(), i => RemoveSelectedItem != null);
            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a) => SelectedInquiry != null);
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedInquiry != null);
            DeleteCommand = new RelayCommand(i => DeleteAsync(), (a) => SelectedInquiry != null);

        }


        public string Name { get => _name; private set { _name = value; RaisePropertyChanged(); } }

        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddInquiryItemCommand { get => _addInquiryItemCommand; set { _addInquiryItemCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        
        public Inquiry NewInquiry { get => _newInquiry;  set { _newInquiry = value; RaisePropertyChanged(); } }
        public Inquiry SelectedInquiry { get => _selectedInquiry;  set { _selectedInquiry = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }

        public ObservableCollection<Inquiry> Inquirys { get => inquirys; set { inquirys = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> PartsList { get => _partsList; set { _partsList = value; RaisePropertyChanged(); } }
        public InquiryItem SelectedItem { get => _selectedItem; set { _selectedItem = value; RaisePropertyChanged(); } }
        public InquiryItem RemoveSelectedItem { get => _removeSelectedItem; set { _removeSelectedItem = value; RaisePropertyChanged(); } }

        public ICommand RemovePartCommand { get => _removePartCommand; set { _removePartCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddPartsWindowCommand { get => _openAddPartsWindowCommand; set { _openAddPartsWindowCommand = value; RaisePropertyChanged(); } }
        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }
        public bool Activate()
        {
            Active = 1;
            return Active == 1;
        }
        private void AddInquiryItem(IClosable i)
        {
            if (SelectedItem.Inventory.PartNumber != "")
            {
                SelectedItem.Inventory.IsActive = 1;
               if (NewInquiry.Items.Count == 0)
                {
                    NewInquiry.Items = new ObservableCollection<InquiryItem>();
                }
                NewInquiry.Items.Add(new InquiryItem()
                {
                    Inventory = SelectedItem.Inventory,
                    InventoryId = SelectedItem.Inventory.Id,
                    OfferedPrice = SelectedItem.OfferedPrice,
                    OfferedQty = SelectedItem.OfferedQty,
                    IsActive = 1

                });
                NewInquiry.CalculateNetTotal();

                i.Close();
            }
        }
        private void RemovePart()
        {
            NewInquiry.Items.Remove(RemoveSelectedItem);
            NewInquiry.CalculateNetTotal();
        }
        public async Task<bool> AddAsync()
        {
            try
            {
                return await service.CallAddService(NewInquiry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting inquiry{ex.Message}");
                return false;
            }
        }
        private async void CancelClose(IClosable p)
        {
            //p.Close();
            await GetAll();
        }
        private async void Cancel(IClosable p)
        {
            p.Close();
            await GetAll();
        }
        private async void Save(IClosable p)
        {
            //Data Checks
            //Check if it is create or update mode
            //if create mode
            //Check if inventory id > 0 then set inventory to null
            foreach (var item in NewInquiry.Items)
            {
                if (item.InventoryId > 0)
                {
                    item.Inventory = null;
                }
                item.IsActive = 1;
               
            }
            
            if (!isEdit)
            {
                await AddAsync();
            }
            else if (isEdit)
            {
                await UpdateAsync();
            }

            p.Close();
            await GetAll();
        }
        private void OpenAddWindow()
        {
            NewInquiry = new Inquiry() { Items = new ObservableCollection<InquiryItem>()};
            NewInquiry.IsActive = 1;
            isEdit = false;

            var window = new AddInquiryView(this);
            window.ShowDialog();

        }
        private async void OpenAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedItem = new InquiryItem() { Inventory = new Inventory(),IsActive =1 };
            var window = new InquiryAddPartsView(this);
            window.ShowDialog();


        }
        private void OpenEditWindow()
        {
            isEdit = true;
            NewInquiry = SelectedInquiry;
            var window = new AddInquiryView(this);
            window.ShowDialog();

        }
        public bool Deactivate()
        {
            Active = 0;
            return Active == 0;
        }
        public async void ActivateAsync()
        {
            if (await service.CallActivateService(SelectedInquiry.Id))
            {
                MessageBox.Show("Inquiry Activated");
                await GetAll();
            }
        }
        public async Task<bool> DisableAsync()
        {
            if (await service.CallDisableInquiryService(SelectedInquiry.Id))
            {
                MessageBox.Show("Inquiry Disabled");
                await GetAll();
                return true;
            }
            else
                return false;
        }
        public async Task<bool> DeleteAsync()
        {
            if (CurrentUserRole(AppProperties.ROLE_ADMIN))
            {
                if(await service.CallAdminDeleteService(SelectedInquiry.Id))
                {
                    MessageBox.Show("Inquiry Deleted");
                    return true;
                }
                MessageBox.Show("Inquiry Delete failed");
                return false;
            }
            else
            {
                if (await service.CallDeleteService(SelectedInquiry.Id))
                {
                    MessageBox.Show("Inquiry Deleted");
                    return true;
                }
                MessageBox.Show("Inquiry Delete failed");
                return false;
            }
            
        }

        public async Task Get()
        {
            try
            {
                await service.CallGetService(SelectedInquiry.Id);
                SelectedInquiry.CalculateNetTotal();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
            }
        }

        public async Task GetAll()
        {
            try
            {
                if (CurrentUserRole(AppProperties.ROLE_ADMIN))
                {

                    Inquirys = new ObservableCollection<Inquiry>(await service.CallAdminGetAllService());
                    foreach (var i in Inquirys)
                    {
                        i.CalculateNetTotal(); 
                    }
                    IsAdmin = true;
                }
                else if (CurrentUserRole(AppProperties.ROLE_USER))
                {

                    Inquirys = new ObservableCollection<Inquiry>(await service.CallGetAllService());
                    foreach (var i in Inquirys)
                    {
                        i.CalculateNetTotal();
                    }
                    IsAdmin = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Inquiry: {ex.Message}");

            }
        }

        public async Task<bool> UpdateAsync()
        {
            try
            {
                return await service.CallUpdateService(NewInquiry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating inquiry{ex.Message}");
                return false;
            }
        }

        public string VMName()
        {
            return Name;
        }

        bool CurrentUserRole(string role)
        {
            return AppProperties.RoleName == role;
        }
    }
}
