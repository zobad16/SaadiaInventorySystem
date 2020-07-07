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
    public class QuotationViewModel : BaseViewModel, IViewModel
    {
        public QuotationViewModel()
        {
            Name = "Quotation";
            service = new QuotationService();
            AddWindowCommand = new RelayCommand(i => OpenAddWindow(), i => true);
            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => SelectedQuotation != null);
            OpenAddCustomerWindowCommand = new RelayCommand(i => OpenAddCustomerWindow(), i => true);
            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            SelectCustomerCommand = new RelayCommand<IClosable>(i => SelectCustomersCommand(i),i=> true);
            SelectPartCommand = new RelayCommand<IClosable>(i => SelectPartsCommand(i),i=> true);
            AddOrderItemCommand = new RelayCommand<IClosable>(i => AddOrderItem(i), i => true);
         //   NewQuotation = new Quotation();
        }

        

        private string _name;
        private readonly QuotationService service;
        private Quotation _quotation;
        private Quotation _selectedQuotation;
        private Quotation _newQuotation;
        private double _netTotal;
        private string message;
        private string note;

        private ObservableCollection<Quotation> _quotations;
        private ObservableCollection<Customer> _customersList;
        private Customer _selectedCustomer;
        private ObservableCollection<Inventory> _partsList;
        private OrderItem _selectedOrderItem;
        
        private ICommand _addWindowCommand;
        private ICommand _openAddCustomerWindowCommand;
        private ICommand _openAddPartsWindowCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _saveCommand;

        private RelayCommand<IClosable> _selectCustomerCommand;
        private RelayCommand<IClosable> _selectPartCommand;
        private RelayCommand<IClosable> _addOrderItemCommand;
        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }

        public double NetTotal
        {
            get => _netTotal;
            set
            {
                if (_netTotal == 0 && SelectedQuotation != null)
                {
                    foreach (var order in SelectedQuotation.Order.OrderItems) 
                    {
                        _netTotal += order.Total;
                    }
                    RaisePropertyChanged();
                }
            }
        }
        public Quotation Quotation { get => _quotation; set { _quotation = value; RaisePropertyChanged(); } }
        public ObservableCollection<Quotation> Quotations { get => _quotations; set { _quotations = value; RaisePropertyChanged(); } }
        public Quotation SelectedQuotation { get => _selectedQuotation; set { _selectedQuotation = value; RaisePropertyChanged(); } }
        public Quotation NewQuotation { get => _newQuotation; set { _newQuotation = value; RaisePropertyChanged(); } }
        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }

        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddCustomerWindowCommand { get => _openAddCustomerWindowCommand; set { _openAddCustomerWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddPartsWindowCommand { get => _openAddPartsWindowCommand; set { _openAddPartsWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectCustomerCommand { get => _selectCustomerCommand; set { _selectCustomerCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectPartCommand { get => _selectPartCommand; set { _selectPartCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddOrderItemCommand { get => _addOrderItemCommand; set { _addOrderItemCommand = value; RaisePropertyChanged(); } }

        public ObservableCollection<Customer> CustomersList { get => _customersList; set { _customersList = value; RaisePropertyChanged(); } }
        public Customer SelectedCustomer { get => _selectedCustomer; set { _selectedCustomer = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> PartsList { get => _partsList; set { _partsList = value; RaisePropertyChanged(); } }
        public OrderItem SelectedOrderItem { get => _selectedOrderItem; set { _selectedOrderItem = value; RaisePropertyChanged(); } }

        public string Message { get => message; set { message = value; RaisePropertyChanged(); } }
        public string Note { get => note; set { note = value; RaisePropertyChanged(); } }

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
            //Check if partnumber exists. if it does replace Inventory with the id

            p.Close();
            await GetAll();
        }

        private async void OpenAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedOrderItem = new OrderItem() { Inventory = new Inventory()};
            var window = new QuotationAddPartsView(this);
            window.ShowDialog();
        }

        private async void OpenAddCustomerWindow()
        {
            //load customer data
            var _service = new CustomerService();
            CustomersList = new ObservableCollection<Customer>(await _service.CallGetAllService());
            var window = new QuotationAddCustomerView(this);
            window.ShowDialog();
        }

        private void OpenEditWindow()
        {
            throw new NotImplementedException();
        }

        private void OpenAddWindow()
        {
            NewQuotation = new Quotation();
            NewQuotation.IsActive = 1;
            NewQuotation.Message = Message;
            NewQuotation.Note = Note;

            
            var window = new AddQuotationView(this);
            window.ShowDialog();
        }
        private void SelectPartsCommand(IClosable i)
        {
            throw new NotImplementedException();
        }
        private void AddOrderItem(IClosable i)
        {
            if(SelectedOrderItem.Inventory.PartNumber != "") 
            {
                SelectedOrderItem.CalculateTotal();
                if (NewQuotation.Order.OrderItems.Count == 0)
                {
                    NewQuotation.Order.OrderItems = new ObservableCollection<OrderItem>();
                }
                NewQuotation.Order.OrderItems.Add(SelectedOrderItem);
                NewQuotation.CalculateNetTotal();

                i.Close();
            }
            
        }

        private void SelectCustomersCommand(IClosable i)
        {

            i.Close();
        }
        #region Business Logic
        public string VMName()
        {
            return Name;
        }
       
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
        public async Task<bool> UpdateAsync()
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
                return false;
            }
        }
        public async Task<bool> DeleteAsync()
        {
            try
            {
                if (await service.CallDeleteService(SelectedQuotation.Id))
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

        public async Task GetAll()
        {
            try
            {
                Quotations = new ObservableCollection<Quotation>(await service.CallGetAllService());
                foreach(var item in Quotations)
                {
                    item.CalculateNetTotal();
                }
                Message = Quotations[0].Message;
                Note = Quotations[0].Note;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Quotation: {ex.Message}");
                
            }
        }

        public async Task Get()
        {
            try
            {
                await service.CallGetService(SelectedQuotation.Id);
                SelectedQuotation.CalculateNetTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
            }
        }

        public async Task<bool> AddAsync()
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
                return false;
            }
        }

        #endregion
    }
}