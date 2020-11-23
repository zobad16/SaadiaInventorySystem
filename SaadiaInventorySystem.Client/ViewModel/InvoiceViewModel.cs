using ExcelDataReader;
using Humanizer;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InvoiceViewModel : BaseViewModel, IViewModel
    {
        string arabic_txt = "شركة سعدية للتجارة ذ.م.م";
        private string _name;
        private ObservableCollection<Invoice> _invoices;
        private ObservableCollection<Invoice> _bulkInvoices;
        private Invoice _selectedBulkInvoice;
        private ObservableCollection<Quotation> _quotationList;
        private ObservableCollection<Customer> _customersList;
        private Customer _selectedCustomer;
        private Invoice _selectedInvoice;
        private Quotation _selectedQuotation;
        private ObservableCollection<Inventory> _partsList;
        private Invoice _newInvoice;
        private OrderItem _selectedOrderItem;
        private OrderItem _selectedImportOrderItem;
        private OrderItem _removeSelectedOrderItem;
        private readonly InvoiceService service;
        private double _netTotal;
        private string _filePath;
        private string _duplicateState;
        private bool _isUpdateCheck;
        private bool _isIgnoreCheck;
        private static bool isEdit;
        private bool isAdmin;
        
        private ICommand _addWindowCommand;
        private ICommand _removePartCommand;
        private ICommand _removePartImportCommand;
        private ICommand _removeRecordCommand;
        private RelayCommand _confirmCommand;
        private RelayCommand _activateCommand;
        private RelayCommand _disableCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _importCommand;
        private RelayCommand _addImportPartOpenCommand;
        private RelayCommand _editImportPartOpenCommand;
        private RelayCommand _previousRecordCommand;
        private RelayCommand _nextRecordCommand;
        
        private RelayCommand _duplicateCommand;
        private RelayCommand _exportCommand;


        private RelayCommand<IClosable> _uploadCommand;

        private ICommand _openAddExistingQuotationWindowCommand;
        private ICommand _openAddCustomerWindowCommand;
        private ICommand _openAddPartsWindowCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _saveImportCommand;

        private RelayCommand<IClosable> _selectCustomerCommand;
        private RelayCommand<IClosable> _selectPartCommand;
        private RelayCommand<IClosable> _selectQuotationCommand;
        private RelayCommand<IClosable> _addOrderItemCommand;
        private RelayCommand<IClosable> _addOrderItemImportCommand;


        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public Invoice SelectedInvoice { get => _selectedInvoice; set { _selectedInvoice = value; RaisePropertyChanged(); } }
        public Invoice SelectedBulkInvoice { get => _selectedBulkInvoice; set { _selectedBulkInvoice = value; RaisePropertyChanged(); } }
        public Quotation SelectedQuotation { get => _selectedQuotation; set { _selectedQuotation = value; RaisePropertyChanged(); } }
        public Invoice NewInvoice { get => _newInvoice; set { _newInvoice = value; RaisePropertyChanged(); } }
        public ObservableCollection<Invoice> Invoices { get => _invoices; set { _invoices = value; RaisePropertyChanged(); } }
        public ObservableCollection<Invoice> BulkInvoices { get => _bulkInvoices; set { _bulkInvoices = value; RaisePropertyChanged(); } }
        public bool IsUpdateCheck { get => _isUpdateCheck; set { _isUpdateCheck = value; RaisePropertyChanged(); } }
        public bool IsIgnoreCheck { get => _isIgnoreCheck; set { _isIgnoreCheck = value; RaisePropertyChanged(); } }
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }


        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand RemovePartImportCommand { get => _removePartImportCommand; set { _removePartImportCommand = value; RaisePropertyChanged(); } }
        public ICommand RemoveRecordCommand { get => _removeRecordCommand; set { _removeRecordCommand = value; RaisePropertyChanged(); } }
        public ICommand RemovePartCommand { get => _removePartCommand; set { _removePartCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ConfirmCommand { get => _confirmCommand; set { _confirmCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ImportCommand { get => _importCommand; set { _importCommand = value; RaisePropertyChanged(); } }
        public RelayCommand AddImportPartOpenCommand { get => _addImportPartOpenCommand; set { _addImportPartOpenCommand = value; RaisePropertyChanged(); } }
        public RelayCommand EditImportPartOpenCommand { get => _editImportPartOpenCommand; set { _editImportPartOpenCommand = value; RaisePropertyChanged(); } }
        public RelayCommand NextRecordCommand { get => _nextRecordCommand; set { _nextRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand PreviousRecordCommand { get => _previousRecordCommand; set { _previousRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DuplicateCommand { get => _duplicateCommand; set { _duplicateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> UploadCommand { get => _uploadCommand; set { _uploadCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ExportCommand { get { return _exportCommand; } set { _exportCommand = value; RaisePropertyChanged(); } }

        public ICommand OpenAddExistingQuotationWindowCommand { get => _openAddExistingQuotationWindowCommand; set { _openAddExistingQuotationWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddCustomerWindowCommand { get => _openAddCustomerWindowCommand; set { _openAddCustomerWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddPartsWindowCommand { get => _openAddPartsWindowCommand; set { _openAddPartsWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }

        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveImportCommand { get => _saveImportCommand; set { _saveImportCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectCustomerCommand { get => _selectCustomerCommand; set { _selectCustomerCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectPartCommand { get => _selectPartCommand; set { _selectPartCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectQuotationCommand { get => _selectQuotationCommand; set { _selectQuotationCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddOrderItemCommand { get => _addOrderItemCommand; set { _addOrderItemCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddOrderItemImportCommand { get => _addOrderItemImportCommand; set { _addOrderItemImportCommand = value; RaisePropertyChanged(); } }

        public ObservableCollection<Quotation> QuotationList { get => _quotationList; set { _quotationList = value; RaisePropertyChanged(); } }
        public ObservableCollection<Customer> CustomersList { get => _customersList; set { _customersList = value; RaisePropertyChanged(); } }
        public Customer SelectedCustomer { get => _selectedCustomer; set { _selectedCustomer = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> PartsList { get => _partsList; set { _partsList = value; RaisePropertyChanged(); } }
        public OrderItem SelectedOrderItem { get => _selectedOrderItem; set { _selectedOrderItem = value; RaisePropertyChanged(); } }
        public OrderItem SelectedImportOrderItem { get => _selectedImportOrderItem; set { _selectedImportOrderItem = value; RaisePropertyChanged(); } }
        public OrderItem RemoveSelectedOrderItem { get => _removeSelectedOrderItem; set { _removeSelectedOrderItem = value; RaisePropertyChanged(); } }
        public string DuplicateState { get => _duplicateState; set { _duplicateState = value; RaisePropertyChanged(); } }

        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }


        public double NetTotal
        {
            get => _netTotal;
            set
            {
                if (_netTotal == 0 && SelectedInvoice != null)
                {
                    foreach (var order in SelectedInvoice.Order.OrderItems)
                    {
                        _netTotal += order.Total;
                    }
                    RaisePropertyChanged();
                }
            }
        }
        public InvoiceViewModel()
        {
            Name = "Invoice";
            service = new InvoiceService();
            Active = 0;
            AddWindowCommand = new RelayCommand(i => OpenAddWindow(), i => true);
            RemovePartCommand = new RelayCommand(i => RemovePart(), i => RemoveSelectedOrderItem != null);
            RemovePartImportCommand = new RelayCommand(i => RemoveImportPart(), i => SelectedImportOrderItem != null);
            RemoveRecordCommand = new RelayCommand(i => RemoveImportRecord(), i => BulkInvoices.Count >= 1);

            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => SelectedInvoice != null);
            OpenAddExistingQuotationWindowCommand = new RelayCommand(i => OpenAddQuotaionWindow(), i => true);
            OpenAddCustomerWindowCommand = new RelayCommand(i => OpenAddCustomerWindow(), i => true);
            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            EditImportPartOpenCommand = new RelayCommand(i => OpenImportEditWindow(), (i) => SelectedImportOrderItem != null);
            AddImportPartOpenCommand = new RelayCommand(i => OpenImportAddPartsWindow(), i => true);
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            SaveImportCommand = new RelayCommand<IClosable>(i => SaveImport(i), i => true);
            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a) => SelectedInvoice != null);
            ConfirmCommand = new RelayCommand(i => ConfirmInvoiceAsync(), (a) => SelectedInvoice != null);
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedInvoice != null);
            DeleteCommand = new RelayCommand(i => Delete(), (a) => SelectedInvoice != null);
            ImportCommand = new RelayCommand(i => ImportInvoice(), i => true);
            AddImportPartOpenCommand = new RelayCommand(i => OpenImportAddPartsWindow(), i => true);
            EditImportPartOpenCommand = new RelayCommand(i => OpenImportEditWindow(), (i) => SelectedImportOrderItem != null);

            NextRecordCommand = new RelayCommand(i => NextRecord());
            PreviousRecordCommand = new RelayCommand(i => PreviousRecord());
            ExportCommand = new RelayCommand(i => ExportInvoice(), (i) => SelectedInvoice != null);
            UploadCommand = new RelayCommand<IClosable>(i => Upload(i), i => true);
            SelectCustomerCommand = new RelayCommand<IClosable>(i => SelectCustomersCommand(i), i => true);
            SelectPartCommand = new RelayCommand<IClosable>(i => SelectPartsCommand(i), i => true);
            SelectQuotationCommand = new RelayCommand<IClosable>(i => SelectedQuotationCommand(i), i => true);
            AddOrderItemCommand = new RelayCommand<IClosable>(i => AddOrderItem(i), i => true);
            AddOrderItemImportCommand = new RelayCommand<IClosable>(i => AddOrderItemsImport(i), i => true);
            DuplicateCommand = new RelayCommand(i => SetDuplicateSet(i), i => true);
            isEdit = false;
            isAdmin = false;
            IsIgnoreCheck = true;

        }

        private void SetDuplicateSet(object param)
        {
            DuplicateState = (string)param;
        }

        private void AddOrderItem(IClosable i)
        {
            if (SelectedOrderItem.Inventory.PartNumber != "")
            {
                SelectedOrderItem.Inventory.IsActive = 1;
                SelectedOrderItem.CalculateTotal();
                if (NewInvoice.Order.OrderItems.Count == 0)
                {
                    NewInvoice.Order.OrderItems = new ObservableCollection<OrderItem>();
                }
                NewInvoice.Order.OrderItems.Add(new OrderItem()
                {
                    Inventory = SelectedOrderItem.Inventory,
                    InventoryId = SelectedOrderItem.Inventory.Id,
                    OfferedPrice = SelectedOrderItem.OfferedPrice,
                    Order = SelectedOrderItem.Order,
                    OrderId = SelectedOrderItem.OrderId,
                    OrderQty = SelectedOrderItem.OrderQty,
                    Total = SelectedOrderItem.Total,
                    IsActive = 1

                });
                NewInvoice.CalculateNetTotal();

                i.Close();
            }
        }
        private void AddOrderItemsImport(IClosable i)
        {
            //throw new NotImplementedException();
            //Add new Order Item
            if (!isEdit)
            {
                if (SelectedImportOrderItem.Inventory.PartNumber != "")
                {
                    SelectedImportOrderItem.Inventory.IsActive = 1;
                    SelectedImportOrderItem.CalculateTotal();
                    if (SelectedBulkInvoice.Order.OrderItems.Count == 0)
                    {
                        SelectedBulkInvoice.Order.OrderItems = new ObservableCollection<OrderItem>();
                    }
                    SelectedBulkInvoice.Order.OrderItems.Add(new OrderItem()
                    {
                        Inventory = SelectedImportOrderItem.Inventory,
                        InventoryId = SelectedImportOrderItem.Inventory.Id,
                        OfferedPrice = SelectedImportOrderItem.OfferedPrice,
                        Order = SelectedImportOrderItem.Order,
                        OrderId = SelectedImportOrderItem.OrderId,
                        OrderQty = SelectedImportOrderItem.OrderQty,
                        Total = SelectedImportOrderItem.Total,
                        IsActive = 1

                    });
                    SelectedBulkInvoice.CalculateNetTotal();

                    i.Close();

                }
            }

            //Edit Order Item
            else
            {
                if (SelectedImportOrderItem.Inventory.PartNumber != "")
                {
                    SelectedImportOrderItem.CalculateTotal();
                    SelectedImportOrderItem.CalculateVAT();
                    var part = SelectedBulkInvoice.Order.OrderItems.Where(item =>
                        (item.Inventory.PartNumber == SelectedImportOrderItem.Inventory.PartNumber)).FirstOrDefault();

                    part = SelectedImportOrderItem;
                    SelectedBulkInvoice.CalculateNetTotal();
                    i.Close();
                }
            }
            


        }
        private void SelectPartsCommand(IClosable i)
        {
            throw new NotImplementedException();
        }
        private void SelectedQuotationCommand(IClosable i)
        {
            NewInvoice.QuotationId = SelectedQuotation.Id;
            NewInvoice.IsActive = 1;
            NewInvoice.Message = SelectedQuotation.Message;
            NewInvoice.MS = SelectedQuotation.MS;
            NewInvoice.Note = SelectedQuotation.Note;
            NewInvoice.OfferedDiscount = SelectedQuotation.OfferedDiscount;
            NewInvoice.Order = SelectedQuotation.Order;
            //NewInvoice.OrderId = SelectedQuotation.OrderId;
            NewInvoice.QuotationNumber = SelectedQuotation.QuotationNumber;
            NewInvoice.VAT = SelectedQuotation.VAT;
            NewInvoice.Attn = SelectedQuotation.Attn;
            NewInvoice.Confirmation = false;
            NewInvoice.Customer = SelectedQuotation.Customer;
            //NewInvoice.CustomerId = SelectedQuotation.CustomerId;
            NewInvoice.Date = DateTime.Now.ToString();
            NewInvoice.DateCreated = DateTime.Now;
            
            i.Close();
        }

        private void SelectCustomersCommand(IClosable i)
        {
            i.Close();
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
            var _service = new CustomerService();
            var customerList = new ObservableCollection<Customer>(await _service.CallGetAllService());

            foreach (var item in NewInvoice.Order.OrderItems)
            {
                if (item.InventoryId > 0)
                {
                    //item.Inventory = null;
                    item.InventoryId = 0;
                }
                item.IsActive = 1;
                item.OrderId = NewInvoice.OrderId;
            }
            //Check if id matches the firsname and lastname of existing customer
            var _customer = customerList.Where(i => i.Id == NewInvoice.Customer.Id).FirstOrDefault();
            //if matches existing record set CustomerId
            if (_customer != null)
            {
                if (_customer.FirstName.Equals(NewInvoice.Customer.FirstName) &&  _customer.LastName.Equals(NewInvoice.Customer.LastName))
                {
                    NewInvoice.CustomerId = NewInvoice.Customer.Id;
                }
                //If dont match set id to 0
                else
                {
                    //New Record
                    NewInvoice.CustomerId = 0;
                    NewInvoice.Customer.Id = 0;
                }
            }


            // NewInvoice.Customer = null;
            //if (NewInvoice.OrderId > 0)
            //    NewInvoice.Order = null;
            if (!isEdit)
            {
                if (await AddAsync())
                {
                    MessageBox.Show("Invoice added sucessfully");
                }
                else
                {
                    MessageBox.Show("Invoice insert operation failed.");
                }
            }
            else if (isEdit)
            {
                if (await UpdateAsync())
                {
                    MessageBox.Show("Invoice updated sucessfully");
                }
                else
                {
                    MessageBox.Show("Invoice insert operation failed.");
                }
            }

            p.Close();
            await GetAll();
        }
        private async void SaveImport(IClosable p)
        {
            //Data Checks
            var list = await DuplicateChecks(BulkInvoices.ToList());
            BulkInvoices = new ObservableCollection<Invoice>(list);
            foreach (var invoice in BulkInvoices)
            {
                if (invoice.Order != null)
                {
                    if (invoice.Order.OrderItems != null)
                    {
                        foreach (var item in invoice.Order.OrderItems)
                        {
                            if (item.InventoryId > 0)
                            {
                                item.Inventory = null;
                            }
                            item.IsActive = 1;
                            item.OrderId = invoice.OrderId;
                        }
                    }

                }
                if (invoice.Customer != null)
                {
                    if (invoice.Customer.Id > 0)
                    {
                        invoice.CustomerId = invoice.Customer.Id;
                        invoice.Customer = null;
                    }
                }


            }

            if (IsIgnoreCheck)
            {
                BulkSave(p);
            }
            else if (IsUpdateCheck)
            {
                BulkUpdate(p);
            }

            p.Close();
            await GetAll();
        }

        private async Task<List<Invoice>> DuplicateChecks(List<Invoice> lists)
        {
            var _service = new CustomerService();
            var _partsService = new InventoryService();
            if (CurrentUserRole(AppProperties.ROLE_ADMIN))
            {
                CustomersList = new ObservableCollection<Customer>(await _service.CallGetAllService());
                PartsList = new ObservableCollection<Inventory>(await _partsService.CallGetAllService());
            }
            else {
                CustomersList = new ObservableCollection<Customer>(await _service.CallGetAllService());
                PartsList = new ObservableCollection<Inventory>(await _partsService.CallGetAllService());
            }var invoice_list = new List<Invoice>();
            foreach (var q in lists)
            {
                if (q != null)
                {
                    var _invoice = Invoices.Where(i => (q.OrderPurchaseNumber == i.OrderPurchaseNumber)).FirstOrDefault();
                    if (_invoice != null && IsIgnoreCheck)
                    {
                        continue;
                    }
                    else if (_invoice != null && IsUpdateCheck)
                    {
                        q.Id = _invoice.Id;
                    }
                    if (String.IsNullOrEmpty(q.Customer.FirstName) && String.IsNullOrEmpty(q.Customer.FirstName))
                    {
                        q.Customer.FirstName = ""; q.Customer.LastName = "";
                    }

                    Customer customer = CustomersList.Where(i => i.FirstName.Equals(q.Customer.FirstName) && i.LastName.Equals(q.Customer.LastName)).FirstOrDefault();

                    if (customer != null)
                    {
                        //Record found
                        //if DuplpicateState equals ignore: remove object set id
                        if (IsIgnoreCheck)
                        {
                            q.CustomerId = customer.Id;
                            q.Customer = null;
                        }
                        else if (IsUpdateCheck)
                        {
                            q.CustomerId = customer.Id;
                            q.Customer = null;
                        }
                    }
                    //Check order Parts
                    foreach (var part in q.Order.OrderItems)
                    {
                        var item = PartsList.Where(i => i.PartNumber.Equals(part.Inventory.PartNumber) && i.Description.Equals(part.Inventory.Description)).FirstOrDefault();
                        if (item != null)
                        {
                            if (IsIgnoreCheck)
                            {
                                part.InventoryId = item.Id;
                                part.Inventory = null;
                            }
                            else if (IsUpdateCheck)
                            {
                                part.InventoryId = item.Id;
                                part.Inventory = null;
                            }
                        }
                    }
                    invoice_list.Add(q);
                }
            }

            return invoice_list;
        }
        
        private async void BulkUpdate(IClosable p)
        {
            var listUpdate = BulkInvoices.Where(i => i.Id > 0).ToList();
            var listAdd = BulkInvoices.Where(i => i.Id == 0).ToList();
            if (listUpdate.Count > 0)
            {
                if (await service.CallBulkUpdate(listUpdate))
                {
                    MessageBox.Show("Bulk Insert Success");
                }
            }
            if (listAdd.Count > 0)
            {
                if (await service.CallBulkInsert(listAdd))
                {
                    MessageBox.Show("Bulk Insert Success");
                }
            }
            if(! (listAdd.Count > 0) &&!(listUpdate.Count > 0))
            {
                MessageBox.Show("Nothing to insert.Records Already uptodate");
            }

            p.Close();
            await GetAll();
        }

        private async void BulkSave(IClosable p)
        {
            var listAdd = BulkInvoices.Where(i => i.Id == 0).ToList();
            if (listAdd.Count > 0)
            {
                if (await service.CallBulkInsert(listAdd))
                {
                    MessageBox.Show("Bulk Insert Success");
                }
            }
            else
            {
                MessageBox.Show("Nothing to insert.Records Already uptodate");
            }

            p.Close();
            await GetAll();
        }
        private async void OpenImportAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedImportOrderItem = new OrderItem() { Inventory = new Inventory() };
            var window = new InvoiceImportAddOrderItemView(this);
            isEdit = false;
            window.ShowDialog();
        }
        private async void OpenImportEditWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            isEdit = true;
            var window = new InvoiceImportAddOrderItemView(this);
            window.ShowDialog();

        }
        private async void OpenAddImportCustomerWindow()
        {
            //load customer data
            var _service = new CustomerService();
            CustomersList = new ObservableCollection<Customer>(await _service.CallGetAllService());
            var window = new QuotationAddCustomerView(this);
            window.ShowDialog();
        }

        private async void OpenAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedOrderItem = new OrderItem() { Inventory = new Inventory() };
            var window = new InvoiceAddPartsView(this);
            window.ShowDialog();

        }

        private async void OpenAddQuotaionWindow()
        {
            var _service = new QuotationService();
            QuotationList = new ObservableCollection<Quotation>(await _service.CallGetAllService());
            var window = new InvoiceAddQuotationView(this);
            window.ShowDialog();
        }
        private async void OpenAddCustomerWindow()
        {
            var _service = new CustomerService();
            CustomersList = new ObservableCollection<Customer>(await _service.CallGetAllService());
            var window = new InvoiceAddCustomerView(this);
            window.ShowDialog();
        }

        private void OpenEditWindow()
        {
            isEdit = true;
            NewInvoice = SelectedInvoice;
            var window = new AddInvoiceView(this);
            window.ShowDialog();

        }

        private void OpenAddWindow()
        {
            NewInvoice = new Invoice();
            NewInvoice.IsActive = 1;
            isEdit = false;

            var window = new AddInvoiceView(this);
            window.ShowDialog();

        }
        private void RemovePart()
        {
            NewInvoice.Order.OrderItems.Remove(RemoveSelectedOrderItem);
            NewInvoice.CalculateNetTotal();

        }
        private void RemoveImportPart()
        {
            SelectedBulkInvoice.Order.OrderItems.Remove(SelectedImportOrderItem);
            SelectedBulkInvoice.CalculateNetTotal();

        }
        private void RemoveImportRecord()
        {
            if (BulkInvoices.Count > 1)
            {
                BulkInvoices.Remove(SelectedBulkInvoice);
                NextRecord();
            }
            else if (BulkInvoices.Count == 1)
            {
                BulkInvoices.Remove(SelectedBulkInvoice);
                SelectedBulkInvoice = new Invoice();
            }

        }

        private async Task Upload(IClosable i)
        {
            if (!string.IsNullOrWhiteSpace(FilePath))
            {
                await ReadInvoiceExcel(FilePath);
                var window = new InvoiceImportDisplayView(this);
                if (BulkInvoices == null)
                {
                    return;
                }
                foreach (var invoice in BulkInvoices)
                {
                    invoice.DateCreated = DateTime.Now;
                    invoice.DateCreated = DateTime.Now;
                    foreach (var part in invoice.Order.OrderItems)
                    {
                        part.CalculateTotal();
                        part.CalculateVAT();
                    }
                }
                SelectedBulkInvoice = BulkInvoices[0];
                i.Close();
                window.ShowDialog();
            }
        }
        private void NextRecord()
        {
            int length = BulkInvoices.Count;
            try
            {
                int index = BulkInvoices.IndexOf(SelectedBulkInvoice);
                SelectedBulkInvoice = BulkInvoices[index + 1];

            }
            catch (Exception )
            {
                MessageBox.Show("No More records to display");
            }
        }
        private void PreviousRecord()
        {
            try
            {
                int index = BulkInvoices.IndexOf(SelectedBulkInvoice);
                SelectedBulkInvoice = BulkInvoices[index - 1];

            }
            catch (Exception)
            {
                MessageBox.Show("No More records to display");
            }
        }
        private void ExportExcel(string path)
        {
            ExcelPackage ExcelPkg = new ExcelPackage();
            ExcelWorksheet wsSheet1 = ExcelPkg.Workbook.Worksheets.Add("Sheet1");
            using (ExcelRange Rng = wsSheet1.Cells[2, 2, 2, 2])
            {
                Rng.Value = "Welcome to Everyday be coding - tutorials for beginners";
                Rng.Style.Font.Size = 16;
                Rng.Style.Font.Bold = true;
                Rng.Style.Font.Italic = true;
            }
            wsSheet1.Protection.IsProtected = false;
            wsSheet1.Protection.AllowSelectLockedCells = false;
            //ExcelPkg.SaveAs(new FileInfo(@ "D:\New.xlsx"));
        }
        private void ExcelHeader(ExcelWorksheet workSheet)
        {
            string arabic_txt = "شركة سعدية للتجارة ذ.م.م";
            string address = "TEL: 03-7210885, FAX: 03-7219155, P.O.BOX: 80362. Email: saadia@eim.ae, Al-Ain-U.A.E";
            string emailAddress = "www.saadiatrading.com";
            string TRN = "TRN:100394617300003";

            workSheet.Cells["A1:G1"].Merge = true;
            workSheet.Cells["A2:G2"].Merge = true;
            workSheet.Cells["A3:G3"].Merge = true;

            workSheet.Row(1).Height = 31.20;
            workSheet.Row(1).Style.Font.Size = 20;
            workSheet.Row(1).Style.Font.Name = "Trebuchet MS";

            workSheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            workSheet.Row(2).Height = 14.7;
            workSheet.Row(2).Style.Font.Size = 9;
            workSheet.Row(2).Style.Font.Name = "Trebuchet MS";
            workSheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Row(2).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;

            workSheet.Row(3).Height = 14.7;
            workSheet.Row(3).Style.Font.Size = 9;
            workSheet.Row(3).Style.Font.Name = "Trebuchet MS";
            workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(3).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;


            // Header of the Excel sheet 
            var titleCell = workSheet.Cells[1, 1];
            titleCell.IsRichText = true;
            var emailCell = workSheet.Cells[3, 1];
            emailCell.IsRichText = true;

            var title = titleCell.RichText.Add("SAADIA TRADING CO.");
            var subtitle = titleCell.RichText.Add("LLC\t\t");
            title.FontName = "Trebuchet MS             ";
            title.Size = 20;
            subtitle.FontName = "Trebuchet MS";
            subtitle.Size = 11;

            var arabicTitle = titleCell.RichText.Add($"  \t{arabic_txt}");
            arabicTitle.FontName = "Traditional Arabic";
            arabicTitle.Size = 28;
            
            workSheet.Cells["A2:G2"].Value = address;
            var rich_email = emailCell.RichText.Add($"{emailAddress}, ");
            var rich_TRN = emailCell.RichText.Add($" {TRN} ");
            rich_email.Bold = true;
            rich_email.Italic = true;
            rich_email.UnderLine = true;

            rich_TRN.Bold = true;
            rich_TRN.Italic = true;
            rich_TRN.UnderLine = true;
            rich_TRN.Color = System.Drawing.Color.Red;
            ExcelShape shape = workSheet.Drawings.AddShape("Line1", eShapeStyle.Line);
            shape.SetPosition(3, 0, 0, 0);
            shape.SetSize(440, 1);
            shape.Border.Fill.Color = Color.Black;


        }
        private void ExcelFooter(ExcelWorksheet workSheet, int i)
        {

            //Note
            workSheet.Cells[$"A{i}"].Value = "Note";
            workSheet.Cells[$"A{i}"].Style.Font.Bold = true;
            workSheet.Cells[$"A{i}"].Style.Font.Italic = true;
            workSheet.Cells[$"A{i}"].Style.Font.UnderLine = true;
            i++;
            workSheet.Cells[i, 1, i + 4, 7].Merge = true;
            workSheet.Cells[i, 1, i + 4, 7].Style.Font.Italic = true;
            workSheet.Cells[i, 1, i + 4, 7].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[i, 1, i + 4, 7].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            workSheet.Cells[i, 1, i + 4, 7].Style.Border.Left.Style = ExcelBorderStyle.None;
            workSheet.Cells[i, 1, i + 4, 7].Style.Border.Right.Style = ExcelBorderStyle.None;
            workSheet.Cells[i, 1, i + 4, 7].Style.Border.Top.Style = ExcelBorderStyle.None;
            workSheet.Cells[i, 1, i + 4, 7].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{ i}"].Value = SelectedInvoice.Note;
            i++; i++;i++;i++;i++;
            
            i++;i++;i++;i++;i++;
            workSheet.Cells[i, 1, i, 2].Style.Border.Top.Style = ExcelBorderStyle.Dotted;
            workSheet.Cells[i, 4, i, 7].Style.Border.Top.Style = ExcelBorderStyle.Dotted;
            workSheet.Cells[$"A{ i}:B{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:B{i}"].Value = "Receiver's Signature";
            workSheet.Cells[$"F{ i}"].Value = "Sales Signature";
            
        }

        private void ReadIvoiceExcelEpp(string path)
        {
            //provide file path
            FileInfo existingFile = new FileInfo(path);
            //use EPPlus
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                ExcelWorkbook workbook = package.Workbook;

                foreach (var sheet in workbook.Worksheets)
                {
                    int colCount = sheet.Dimension.End.Column;  //get Column Count
                    int rowCount = sheet.Dimension.End.Row;     //get row count

                    for (int row = 1; row <= rowCount; row++)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            string value = worksheet.Cells[row, col].Value?.ToString().Trim();
                            //Print data, based on row and columns position
                            if (!String.IsNullOrEmpty(value))
                            {
                                Console.WriteLine(" Row:" + row + " column:" + col + " Value:" + value);
                            }

                        }
                    }

                    foreach (var drawing in sheet.Drawings)
                    {

                        var type = drawing.GetType().FullName;
                        var data = Convert.ToString(drawing);
                        Console.WriteLine("Drawing Type:" + type + " Data: " + data);
                    }

                }

            }



        }
        
        private async Task ReadInvoiceExcel(string path)
        {
            try
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var invoices = new List<Invoice>();
                        var updateinvoice = new List<Quotation>();
                        var addquotes = new List<Quotation>();
                        int tabs = result.Tables.Count;
                        bool noteflag = false;
                        bool orderitemflag = false;
                        for (int tab = 0; tab < tabs; tab++)
                        {
                            var q = new Invoice();
                            int rows = result.Tables[tab].Rows.Count;
                            int columns = result.Tables[tab].Columns.Count;

                            for (int row = 3; row < rows; row++)
                            {
                                for (int col = 0; col < columns; col++)
                                {

                                    var data = result.Tables[tab];
                                    var current = data.Rows[row][col].ToString();
                                    
                                    if (current.Contains("S.No"))
                                    {
                                        noteflag = false;
                                        orderitemflag = true;
                                        break;
                                    }
                                    if (orderitemflag && col == 1)
                                    {
                                        if (String.IsNullOrEmpty(data.Rows[row][1].ToString()) && String.IsNullOrEmpty(data.Rows[row][2].ToString()) && String.IsNullOrEmpty(data.Rows[row][3].ToString()))
                                        { break; }
                                        var item = new OrderItem();
                                        item.Inventory = new Inventory();
                                        item.Inventory.PartNumber = data.Rows[row][1].ToString().Trim();
                                        item.Inventory.Description = data.Rows[row][2].ToString().Trim();
                                        int qty = 0;
                                        bool parse = Int32.TryParse(data.Rows[row][3].ToString().Trim(), out qty);
                                        if (parse) item.OrderQty = qty;
                                        if (data.Rows[row][4].ToString().Contains("Ea")) item.OfferedPrice = Double.Parse(data.Rows[row][5].ToString().Trim());
                                        if (data.Rows[row][5].ToString().Contains("Ea")) item.OfferedPrice = Double.Parse(data.Rows[row][6].ToString().Trim());
                                        item.CalculateTotal();
                                        q.Order.OrderItems.Add(item);
                                        break;
                                    }
                                    if (data.Rows[row][0].ToString().Trim().Contains("Gross Total"))
                                    {
                                        orderitemflag = false;
                                        if (String.IsNullOrEmpty(current) || current.Contains("Gross Total")) continue;
                                        string price = current;
                                        q.Order.TotalPrice = Double.Parse(price);
                                        break;
                                    }
                                    if (data.Rows[row][0].ToString().Trim().Contains("VAT"))
                                    {
                                        orderitemflag = false;

                                        string vat = current.ToString().Trim();
                                        string res2 = vat.Split('%')[0];
                                        q.VAT = Int32.Parse(res2);
                                        q.CalculateNetTotal();
                                        break;
                                    }
                                   
                                    // await GetAll();
                                    // The result of each spreadsheet is in result.Tables
                                }
                            }
                            invoices.Add(q);
                        }
                        BulkInvoices = new ObservableCollection<Invoice>();
                        foreach (var item in invoices)
                        {
                            if (item.Id > 0)
                            {
                                BulkInvoices.Add(item);
                            }
                            else if (item.Id == 0)
                            {
                                BulkInvoices.Add(item);
                            }
                        }
                    }
                }
            }
            catch  (Exception ex)
            {
                MessageBox.Show($"Failed to import file. An error occured. Error details: {ex.Message}");
            }
        }

        public async void Delete()
        {
            if (await DeleteAsync())
            {
                MessageBox.Show("Invoice Deleted Successfully");
                await GetAll();
            }
            else
            {
                MessageBox.Show("Error Deleting Invoice");
                await GetAll();
            }
        }
        private void ImportInvoice()
        {
            FilePath = "";
            DuplicateState = "";
            var window = new ImportFileView();
            window.DataContext = this;
            window.ShowDialog();

        }
        private void ExportInvoice()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Invoice"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel(.xlsx)|*.xlsx|Excel(.xls)|*.xls"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                WriteFileExcel(filename);
              //  WriteFilePDF(filename);
            }
        }
        private void WriteFilePDF(string path)
        {
            string filename = path.Replace(".xlsx", ".pdf");
            string newFilePath = ExceltoPdf(path, filename);
            
        }
        public string ExceltoPdf(string excelLocation, string outputLocation)
        {
            try
            {
                /*
                    string filename = txtFile.Text.Replace(".xlsx", ".pdf");
                    const int xlQualityStandard = 0;
                    sheet.ExportAsFixedFormat(
                    Excel.XlFixedFormatType.xlTypePDF,
                    filename, xlQualityStandard, true, false,
                    Type.Missing, Type.Missing, true, Type.Missing);
                */
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                app.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook wkb = app.Workbooks.Open(excelLocation, ReadOnly: true);
                wkb.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, outputLocation);

                wkb.Close();
                app.Quit();

                return outputLocation;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        private void WriteFileExcel(string path)
        {
            ExcelPackage excel = new ExcelPackage();
            try
            {
                // name of the sheet 
                if (SelectedInvoice == null)
                {
                    MessageBox.Show("Error. Exporting file. No Invoice was selected. Please select an Invoice and try again");
                    return;
                }
                var workSheet = excel.Workbook.Worksheets.Add($"{SelectedInvoice.Id}");
                //Header
                ExcelHeader(workSheet);

                workSheet.Cells["A5"].Value = "Customer:. ";
                workSheet.Cells["A5"].Style.Font.Bold = true;
                
                if (SelectedInvoice.Customer == null)
                    SelectedInvoice.Customer = new Customer();
                if (SelectedInvoice.Order == null)
                    SelectedInvoice.Order = new Order();
                if (SelectedInvoice.Order.OrderItems == null)
                    SelectedInvoice.Order.OrderItems = new ObservableCollection<OrderItem>();

                string companyName = SelectedInvoice.Customer.CompanyName;
                companyName = !String.IsNullOrEmpty(companyName) ? companyName.ToUpper() : "";
                string address = (!string.IsNullOrEmpty(SelectedInvoice.Customer.Address)) ? SelectedInvoice.Customer.Address : "";
                DateTime date = SelectedInvoice.DateCreated;
                string _sdate = (date != null) ? date.ToShortDateString():"";
                string trn = (!string.IsNullOrEmpty(SelectedInvoice.Customer.Trn)) ? SelectedInvoice.Customer.Trn : "";

                workSheet.Cells["A6"].Value = "CUSTOMER NAME: ";
                workSheet.Cells["A6"].Style.Font.Bold = true;
                workSheet.Cells["B6"].Value = $"{SelectedInvoice.Customer.FirstName} {SelectedInvoice.Customer.LastName} ";
                workSheet.Cells["A7"].Value = "TRN: ";
                workSheet.Cells["A7"].Style.Font.Bold = true;
                workSheet.Cells["B7"].Value = $"{trn}";
                workSheet.Cells["D6"].Value = "DATE: ";
                workSheet.Cells["D6"].Style.Font.Bold = true;
                workSheet.Cells["E6"].Value = $"{_sdate}";
                workSheet.Cells["A8"].Value = "Company: ";
                workSheet.Cells["A8"].Style.Font.Bold = true;
                workSheet.Cells["B8"].Value = $"{companyName}";
                workSheet.Cells["D7"].Value = "Invoice No: ";
                workSheet.Cells["D7"].Style.Font.Bold = true;
                workSheet.Cells["E7"].Value = $"{SelectedInvoice.Id}";

                workSheet.Cells["A9"].Value = "Address: ";
                workSheet.Cells["A9"].Style.Font.Bold = true;
                workSheet.Cells["B9"].Value = $"{address}";
                workSheet.Cells["D8"].Value = "Quotation No: ";
                workSheet.Cells["D8"].Style.Font.Bold = true;
                string qno = "-";
                if (!String.IsNullOrEmpty(qno))
                    qno = $"{SelectedInvoice.QuotationId}";
                workSheet.Cells["E8"].Value = $"{qno}";

                workSheet.Cells["A10"].Value = "TEL: ";
                workSheet.Cells["A10"].Style.Font.Bold = true;
                workSheet.Cells["B10"].Value = $"{SelectedInvoice.Customer.PhoneNumber}";
                workSheet.Cells["D9"].Value = "Order Purchase No: ";
                workSheet.Cells["D9"].Style.Font.Bold = true;
                workSheet.Cells["E9"].Value = $"{SelectedInvoice.OrderPurchaseNumber}";

                workSheet.Row(5).Style.Font.Size = 9;
                workSheet.Row(6).Style.Font.Size = 9;
                workSheet.Row(7).Style.Font.Size = 9;
                workSheet.Row(8).Style.Font.Size = 9;
                workSheet.Row(9).Style.Font.Size = 9;
                workSheet.Row(10).Style.Font.Size = 9;

                workSheet.Cells["A11:G11"].Merge = true;
                workSheet.Cells["A11:G11"].Value = "INVOICE";
                workSheet.Cells["A11:G11"].Style.Font.Bold = true;
                workSheet.Cells["A11:G11"].Style.Font.Italic = true;
                workSheet.Cells["A11:G11"].Style.Font.UnderLine = true;
                workSheet.Row(11).Style.Font.Color.SetColor(Color.White);
                workSheet.Cells["A11:G11"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A11:G11"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A11:G11"].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);

                workSheet.Cells["A12"].Value = SelectedInvoice.Message;
                workSheet.Cells[12, 1, 13, 7].Merge = true;
                //workSheet.Cells["A11"].Value = "Thank you for your inquiry.";
                //workSheet.Cells["A12"].Value = "We are pleased to quote our best prices as follows:";
                workSheet.Row(9).Style.Font.Size = 9;
                workSheet.Row(10).Style.Font.Size = 9;
                workSheet.Row(11).Style.Font.Size = 9;
                workSheet.Row(12).Style.Font.Size = 9;

                workSheet.Cells["A15"].Value = "S.No";

                workSheet.Cells["B15"].Value = "Part No.";
                workSheet.Cells["C15"].Value = "Description";
                workSheet.Cells["D15"].Value = "Qty";

                workSheet.Cells["E15"].Value = "Units";
                workSheet.Cells["F15"].Value = "Unit Price";
                workSheet.Cells["G15"].Value = "Total Price";
                workSheet.Cells["A15:G15"].Style.Font.Bold = true;

                workSheet.Cells["A15:G15"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A15:G15"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A15:G15"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A15:G15"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                int i = 16;
                int count = 1;
                foreach (var items in SelectedInvoice.Order.OrderItems)
                {
                    workSheet.Cells[$"A{i}"].Value = $"{count}";
                    workSheet.Cells[$"B{i}"].Value = $"{items.Inventory.PartNumber.ToUpper()}";
                    workSheet.Cells[$"C{i}"].Value = $"{items.Inventory.Description.ToUpper()}";
                    workSheet.Cells[$"D{i}"].Value = $"{items.OrderQty}";
                    workSheet.Cells[$"E{i}"].Value = $"Ea";
                    if (items.OfferedPrice > 0)
                    {
                        workSheet.Cells[$"F{i}"].Value = $"{items.OfferedPrice}";
                    }
                    else
                    {
                        workSheet.Cells[$"F{i}"].Value = $"{items.Inventory.UnitPrice}";
                    }

                    workSheet.Cells[$"G{i}"].Value = $"{String.Format("{0:0.00}", items.Total)}";

                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    i++;
                    count++;
                }
                double total = SelectedInvoice.Order.TotalPrice;

                //Gross Total
                workSheet.Cells[$"A{i}:F{i}"].Merge = true;
                workSheet.Cells[$"A{i}:F{i}"].Value = "Gross Total";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"G{i}"].Value = $"{String.Format("{0:0.00}", SelectedInvoice.Order.TotalPrice)}";
                workSheet.Cells[$"G{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:G{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                i++;
                //Vat
                workSheet.Cells[$"A{i}:F{i}"].Merge = true;
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedInvoice.VAT}% Vat";
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                double vatCal = (SelectedInvoice.VAT / 100 * total);
                workSheet.Cells[$"G{i}"].Value = $"{String.Format("{0:0.00}", vatCal)}";
                workSheet.Cells[$"G{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"G{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                i++;
                //Discount
                workSheet.Cells[$"A{i}:F{i}"].Merge = true;
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedInvoice.OfferedDiscount}% Discount";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                double discount = SelectedInvoice.OfferedDiscount > 0 ? (SelectedInvoice.OfferedDiscount / 100 * total) : 0;
                workSheet.Cells[$"G{i}"].Value = $"{String.Format("{0:0.00}", discount)}";
                workSheet.Cells[$"G{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"G{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                i++;
                //Net Total
                workSheet.Cells[$"A{i}"].Value = "Total".ToUpper();
                workSheet.Cells[$"A{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"B{i}:F{i}"].Merge = true;
                workSheet.Cells[$"A{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                double net = SelectedInvoice.NetTotal;
                string nettotal = net.ToString();
                int dp = nettotal.IndexOf(".");
                string whole = "0", decimalVal = "0";

                if (dp >= 1)
                {
                    whole = nettotal.Substring(0, dp);
                    decimalVal = nettotal.Substring(dp + 1);
                }
                else
                {
                    whole = nettotal;
                    //decimalVal = "0";
                }
                int _whole = Int32.Parse(whole);
                int _fills = Int32.Parse(decimalVal);
                if (decimalVal.Length == 1)
                    _fills = _fills * 10;
                string netword = _whole.ToWords();
                string fills = $"& Fils  {_fills.ToWords().ToUpper()}/100 only";

                workSheet.Cells[$"B{i}:F{i}"].Value = $"AED. {netword.ToUpper()} {fills}";
                workSheet.Cells[$"B{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"G{i}"].Value = $"{String.Format("{0:0.00}", net)}";
                workSheet.Cells[$"G{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"G{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                i++;
                i++;
                ExcelFooter(workSheet, i);

                workSheet.Column(1).Width = 7.33;
                workSheet.Column(2).Width = 14;
                workSheet.Column(3).Width = 41;
                workSheet.Column(4).AutoFit();
                workSheet.Column(5).AutoFit();
                workSheet.Column(7).AutoFit();

                // file name with .xlsx extension  
                if (File.Exists(path))
                    File.Delete(path);

                // Create excel file on physical disk  
                FileStream objFileStrm = File.Create(path);
                objFileStrm.Close();

                // Write content to excel file  
                File.WriteAllBytes(path, excel.GetAsByteArray());
                //Close Excel package 
                excel.Dispose();
                MessageBox.Show("Excel successfully exported");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"File export failed. An error occured while exporting the file. \nError details: {ex.Message}");
                excel.Dispose();
            }

        }

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
                if (CurrentUserRole(AppProperties.ROLE_ADMIN))
                {
                    Invoices = new ObservableCollection<Invoice>(await service.CallAdminGetAllService());
                    foreach (var item in Invoices)
                    {
                        item.CalculateNetTotal();
                        foreach (var parts in item.Order.OrderItems)
                        {
                            parts.VatPercent = item.VAT;
                            parts.CalculateVAT();
                        }
                    }
                    IsAdmin = true;
                }
                else if (CurrentUserRole(AppProperties.ROLE_USER))
                {
                    Invoices = new ObservableCollection<Invoice>(await service.CallGetAllService());
                    foreach (var item in Invoices)
                    {
                        item.CalculateNetTotal();
                        foreach (var parts in item.Order.OrderItems)
                        {
                            parts.CalculateVAT();
                        }
                    }
                    IsAdmin = false;
                }
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
                SelectedInvoice = await service.CallGetService(SelectedInvoice.Id.ToString());
                foreach (var parts in SelectedInvoice.Order.OrderItems)
                {
                    parts.VatPercent = SelectedInvoice.VAT;
                    parts.CalculateVAT();
                }
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
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching invoice{ex.Message}");
                return false;
            }
        }
        private async void ActivateAsync()
        {
            if (await service.CallActivateService(SelectedInvoice.Id))
            {
                MessageBox.Show("Invoice Activated");
                await GetAll();
            }
        }
        private async void ConfirmInvoiceAsync()
        {
            if (await service.CallConfirmService(SelectedInvoice.Id))
            {
                MessageBox.Show("Invoice Confirmed");
                await GetAll();
            }
            else
            {
                MessageBox.Show("Invoice Confirmation failed");
                await GetAll();
            }
        }
        private async void DisableAsync()
        {
            if (await service.CallDeleteService(SelectedInvoice.Id))
            {
                MessageBox.Show("Invoice Disabled");
                await GetAll();
            }
        }

        public async Task<bool> DeleteAsync()
        {
            try
            {
                if (CurrentUserRole(AppProperties.ROLE_ADMIN))
                {
                    return await service.CallAdminDeleteService(SelectedInvoice.Id);
                }
                else
                {
                    return await service.CallDeleteService(SelectedInvoice.Id);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching invoice{ex.Message}");
                return false;
            }
        }
        bool CurrentUserRole(string role)
        {
            return AppProperties.RoleName == role;
        }

        #endregion
    }
}