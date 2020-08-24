using ExcelDataReader;
using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
            RemovePartCommand = new RelayCommand(i=> RemovePart(), i =>  RemoveSelectedOrderItem != null );
            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => SelectedQuotation != null);
            OpenAddCustomerWindowCommand = new RelayCommand(i => OpenAddCustomerWindow(), i => true);
            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a) => SelectedQuotation != null);
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedQuotation != null);
            DeleteCommand = new RelayCommand(i => Delete(), (a) => SelectedQuotation != null);
            ImportCommand = new RelayCommand(i => ImportQuotation(), i=> true);
            UploadCommand = new RelayCommand<IClosable>(i => Upload(i), i=> true);
            SelectCustomerCommand = new RelayCommand<IClosable>(i => SelectCustomersCommand(i),i=> true);
            SelectPartCommand = new RelayCommand<IClosable>(i => SelectPartsCommand(i),i=> true);
            AddOrderItemCommand = new RelayCommand<IClosable>(i => AddOrderItem(i), i => true);
            DuplicateCommand = new RelayCommand(i => SetDuplicateSet(i), i => true);
            isEdit = false;
            isAdmin = false;
            IsIgnoreCheck = true;
         //   NewQuotation = new Quotation();
        }

        private void SetDuplicateSet(object param)
        {
            DuplicateState = (string)param;
        }

        private string _name;
        private static bool isEdit;
        private readonly QuotationService service;
        private Quotation _quotation;
        private Quotation _selectedQuotation;
        private Quotation _newQuotation;
        private double _netTotal;
        private string message;
        private string note;
        private bool isAdmin;
        private string _duplicateState;
        private string _filePath;
        private bool _isUpdateCheck;
        private bool _isIgnoreCheck;

        public bool IsUpdateCheck { get => _isUpdateCheck; set { _isUpdateCheck = value; RaisePropertyChanged(); } }
        public bool IsIgnoreCheck { get => _isIgnoreCheck; set { _isIgnoreCheck = value; RaisePropertyChanged(); } }
        private ObservableCollection<Quotation> _quotations;
        private ObservableCollection<Customer> _customersList;
        private Customer _selectedCustomer;
        private ObservableCollection<Inventory> _partsList;
        private OrderItem _selectedOrderItem;
        private OrderItem _removeSelectedOrderItem;
        
        private ICommand _addWindowCommand;
        private ICommand _removePartCommand;
        private RelayCommand _activateCommand;
        private RelayCommand _disableCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _importCommand;
        private RelayCommand _duplicateCommand;
        private RelayCommand<IClosable> _uploadCommand;

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
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }

        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand RemovePartCommand { get => _removePartCommand; set { _removePartCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ImportCommand { get => _importCommand; set { _importCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DuplicateCommand { get => _duplicateCommand; set { _duplicateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> UploadCommand { get => _uploadCommand; set { _uploadCommand = value; RaisePropertyChanged(); } }

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
        public OrderItem RemoveSelectedOrderItem { get => _removeSelectedOrderItem; set { _removeSelectedOrderItem = value; RaisePropertyChanged(); } }

        public string Message { get => message; set { message = value; RaisePropertyChanged(); } }
        public string Note { get => note; set { note = value; RaisePropertyChanged(); } }
        public string DuplicateState { get => _duplicateState; set { _duplicateState = value; RaisePropertyChanged(); } }

        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }

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
            foreach (var item in NewQuotation.Order.OrderItems)
            {
                if (item.InventoryId > 0)
                {
                    item.Inventory = null;
                }
                item.IsActive = 1;
                item.OrderId = NewQuotation.OrderId;
            }
            NewQuotation.CustomerId = NewQuotation.Customer.Id;
            NewQuotation.Customer = null;

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
            isEdit = true;
            NewQuotation = SelectedQuotation;
            var window = new AddQuotationView(this);
            window.ShowDialog();
            
        }

        private void OpenAddWindow()
        {
            NewQuotation = new Quotation();
            NewQuotation.IsActive = 1;
            NewQuotation.Message = Message;
            NewQuotation.Note = Note;
            isEdit = false;
            
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
                SelectedOrderItem.Inventory.IsActive = 1;
                SelectedOrderItem.CalculateTotal();
                if (NewQuotation.Order.OrderItems.Count == 0)
                {
                    NewQuotation.Order.OrderItems = new ObservableCollection<OrderItem>();
                }
                NewQuotation.Order.OrderItems.Add( new OrderItem() {
                    Inventory = SelectedOrderItem.Inventory ,
                    InventoryId = SelectedOrderItem.Inventory.Id,
                    OfferedPrice = SelectedOrderItem.OfferedPrice,
                    Order = SelectedOrderItem.Order,
                    OrderId = SelectedOrderItem.OrderId,
                    OrderQty = SelectedOrderItem.OrderQty,
                    Total = SelectedOrderItem.Total,
                    IsActive =1
                   
                } );
                NewQuotation.CalculateNetTotal();
                
                i.Close();
            }
            
        }
        private void RemovePart()
        {
            NewQuotation.Order.OrderItems.Remove(RemoveSelectedOrderItem);
            NewQuotation.CalculateNetTotal();
            
        }
        
        
        private void SelectCustomersCommand(IClosable i)
        {

            i.Close();
        }
        private async Task Upload(IClosable i)
        {
            if (IsIgnoreCheck) { await ReadQuotationFileExcel(FilePath); }
            else if (IsUpdateCheck) { await ReadQuotationFileExcel(FilePath); }
            i.Close();            
        }
        private void ImportQuotation()
        {
            FilePath = "";
            DuplicateState = "";
            var window = new ImportFileView();
            window.DataContext = this;
            window.ShowDialog();
            
        }
        private async Task ReadQuotationFileExcel(string path)
        {
            if (path.IndexOf("quotation", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var quotes = new List<Quotation>();
                        var updatequotes = new List<Quotation>();
                        var addquotes = new List<Quotation>();
                        int tabs = result.Tables.Count;
                        bool noteflag = false;
                        bool orderitemflag = false;
                        for (int tab = 0; tab < tabs; tab++)
                        {
                            var q = new Quotation();
                            int rows = result.Tables[tab].Rows.Count;
                            int columns = result.Tables[tab].Columns.Count;

                            for (int row = 3; row < rows; row++)
                            {
                                for (int col = 0; col < columns; col++)
                                {

                                    var data = result.Tables[tab];
                                    var current = data.Rows[row][col].ToString();
                                    if (current.Contains("ATTN"))
                                    {
                                        string input = current;
                                        string res2 = input.Split(':')[1];
                                        string pattern = @"\bATTN:\b";
                                        string replace = " ";
                                        string res = Regex.Replace(input, pattern, replace, RegexOptions.IgnoreCase);
                                        q.Attn = res2.Trim();

                                    }
                                    if (current.Contains("Dear"))
                                        noteflag = true;
                                    if (noteflag)
                                    {
                                        if (String.IsNullOrEmpty(current)) continue;
                                        if (!current.Contains("S.No"))
                                        {
                                            q.Note += current;
                                        }
                                    }
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
                                    if (col > 0)
                                    {
                                        if (String.IsNullOrEmpty(current)) continue;
                                        var prev = data.Rows[row][col - 1].ToString();

                                        if (prev.Contains("REF"))
                                        {
                                            q.ReferenceNumber += current.Trim();
                                        }
                                        if (prev.Contains("M/S"))
                                        {
                                            q.MS = current;
                                        }
                                        if (prev.Contains("To"))
                                        {
                                            string input = current;
                                            if (String.IsNullOrEmpty(input)) continue;
                                            char[] delimiter = new char[] { '\t', '.', ' ' };
                                            string[] words = input.Split(' ');
                                            q.Customer.FirstName = $"{words[0] + words[1] }";
                                            q.Customer.LastName = $"{words[2] }";
                                        }
                                        if (prev.Contains("DATE") || prev.Contains("Date"))
                                        {
                                            string date = current;
                                            if (String.IsNullOrEmpty(date)) { continue; }
                                            q.Date = current;
                                            q.DateCreated = Convert.ToDateTime(current);
                                        }
                                        if (col > 1)
                                        {
                                            var prevM1 = data.Rows[row][col - 2].ToString();
                                            if (prevM1.Contains("REF"))
                                                q.ReferenceNumber += current.Trim();
                                        }
                                    }
                                }
                            }
                            quotes.Add(q);
                        }
                        quotes = await DuplicateChecks(quotes);

                        foreach (var item in quotes)
                        {
                            if (item.Id > 0)
                            {
                                updatequotes.Add(item);
                            }
                            else if (item.Id == 0)
                            {
                                addquotes.Add(item);
                            }
                        }

                        if (addquotes.Count > 0)
                        {
                            if (await service.CallBulkInsert(addquotes))
                            {
                                MessageBox.Show("Bulk Insert Success");
                            }
                        }
                        else if (updatequotes.Count > 0)
                        {
                            await service.CallBulkUpdate(updatequotes);
                            MessageBox.Show("Bulk Insert Success. Duplicates records updated");
                        }
                        else
                        {
                            MessageBox.Show("Nothing to insert.Records Already uptodate");
                        }
                        await GetAll();
                        // The result of each spreadsheet is in result.Tables
                    }
                }
            }
            else 
            {
                MessageBox.Show("Error Reading File. Make sure the file path contains quotation");
            }

        }
        private async Task< List<Quotation>>  DuplicateChecks(List<Quotation> quotes )
        {
            var _service = new CustomerService();
            var _partsService = new InventoryService();
            CustomersList = new ObservableCollection<Customer>(await _service.CallGetAllService());
            PartsList = new ObservableCollection<Inventory>(await _partsService.CallGetAllService());
            var quote_list = new List<Quotation>();
            foreach (var q in quotes)
            {
                if (q!= null)
                {
                    var _quotes = Quotations.Where(i => (q.QuotationNumber != null && q.QuotationNumber == i.QuotationNumber) ||(q.ReferenceNumber == i.ReferenceNumber)).FirstOrDefault();
                    if(_quotes != null && IsIgnoreCheck)
                    {
                        continue;
                    }
                    else if(_quotes != null && IsUpdateCheck)
                    {
                        q.Id = _quotes.Id;
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
                        var item = PartsList.Where(i => i.PartNumber.Equals(part.Inventory.PartNumber) || i.Description.Equals(part.Inventory.Description)).FirstOrDefault();
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
                    quote_list.Add(q);
                }             
            }

            return quote_list;
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
        private async void ActivateAsync()
        {
            if (await service.CallActivateService(SelectedQuotation.Id))
            {
                MessageBox.Show("Quotation Activated");
                await GetAll();
            }
        }

        private async void DisableAsync()
        {
            if (await service.CallDeleteService(SelectedQuotation.Id))
            {
                MessageBox.Show("Quoatation Disabled");
                await GetAll();
            }
        }
        public async void Delete()
        {
            if (await DeleteAsync())
            {
                MessageBox.Show("Quotation Deleted Successfully");
                await GetAll();
            }
            else
            {
                MessageBox.Show("Error Deleting Quotation");
                await GetAll();
            }
        }
        public async Task<bool> UpdateAsync()
        {
            try
            {
                if (await service.CallUpdateService(NewQuotation))
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
                if (CurrentUserRole(AppProperties.ROLE_ADMIN))
                {
                    return (await service.CallAdminDeleteService(SelectedQuotation.Id));
                }
                else if (CurrentUserRole(AppProperties.ROLE_USER))
                {
                    return (await service.CallDeleteService(SelectedQuotation.Id));
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                return false;
            }
        }

        public async Task GetAll()
        {
            try
            {
                if (CurrentUserRole(AppProperties.ROLE_ADMIN))
                {

                    Quotations = new ObservableCollection<Quotation>(await service.CallAdminGetAllService());
                    foreach (var item in Quotations)
                    {
                        item.CalculateNetTotal();
                    }
                    Message = Quotations[0].Message;
                    Note = Quotations[0].Note;
                    IsAdmin = true;
                }
            else if (CurrentUserRole(AppProperties.ROLE_USER))
                {

                    Quotations = new ObservableCollection<Quotation>(await service.CallGetAllService());
                    foreach (var item in Quotations)
                    {
                        item.CalculateNetTotal();
                    }
                    Message = Quotations[0].Message;
                    Note = Quotations[0].Note;
                    IsAdmin = false;
                }
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
        bool CurrentUserRole(string role)
        {
            return AppProperties.RoleName == role;
        }
        #endregion
    }
}