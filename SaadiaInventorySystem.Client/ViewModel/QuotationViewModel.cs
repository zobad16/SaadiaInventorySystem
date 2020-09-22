using ExcelDataReader;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Humanizer;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class QuotationViewModel : BaseViewModel, IViewModel
    {
        public QuotationViewModel()
        {
            Name = "Quotation";
            service = new QuotationService();
            SelectedBulkQuotation = new Quotation();
            AddWindowCommand = new RelayCommand(i => OpenAddWindow(), i => true);
            RemovePartCommand = new RelayCommand(i=> RemovePart(), i =>  RemoveSelectedOrderItem != null );
            RemovePartImportCommand = new RelayCommand(i=> RemoveImportPart(), i => SelectedImportOrderItem != null );
            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => SelectedQuotation != null);
            OpenAddCustomerWindowCommand = new RelayCommand(i => OpenAddCustomerWindow(), i => true);
            //OpenAddCustomerImportWindowCommand = new RelayCommand(i => OpenAddCustomerWindow(), i => true);
            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            AddImportPartOpenCommand = new RelayCommand(i => OpenImportAddPartsWindow(), i => true);
            EditImportPartOpenCommand = new RelayCommand(i => OpenImportEditWindow(), (i )=> SelectedImportOrderItem != null);
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            SaveImportCommand = new RelayCommand<IClosable>(i => SaveImport(i), i => BulkQuotations.Count<=1);
            BulkSaveCommand = new RelayCommand<IClosable>(i => BulkSave(i), i => true);
            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a) => SelectedQuotation != null);
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedQuotation != null);
            DeleteCommand = new RelayCommand(i => Delete(), (a) => SelectedQuotation != null);
            ImportCommand = new RelayCommand(i => ImportQuotation(), i=> true);
            NextRecordCommand = new RelayCommand(i => NextRecord());
            PreviousRecordCommand = new RelayCommand(i => PreviousRecord());
            RemoveRecordCommand = new RelayCommand(i => RemoveImportRecord(), i => BulkQuotations.Count>=1);
            ExportCommand = new RelayCommand(i => ExportQuotation(), (i)=> SelectedQuotation != null);
            UploadCommand = new RelayCommand<IClosable>(i => Upload(i), i=> true);
            SelectCustomerCommand = new RelayCommand<IClosable>(i => SelectCustomersCommand(i),i=> true);
            SelectPartCommand = new RelayCommand<IClosable>(i => SelectPartsCommand(i),i=> true);
            AddOrderItemCommand = new RelayCommand<IClosable>(i => AddOrderItem(i), i => true);
            AddOrderItemImportCommand = new RelayCommand<IClosable>(i => AddOrderItemsImport(i), i => true);
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
        private Quotation _selectedBulkQuotation;
        private OrderItem _selectedImportOrderItem;
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
        private ObservableCollection<Quotation> _bulkQuotations;
        private ObservableCollection<Customer> _customersList;
        private Customer _selectedCustomer;
        private ObservableCollection<Inventory> _partsList;
        private OrderItem _selectedOrderItem;
        private OrderItem _removeSelectedOrderItem;
        
        private ICommand _addWindowCommand;
        private ICommand _removePartCommand;
        private ICommand _removeRecordCommand;
        private ICommand _removePartImportCommand;
        private RelayCommand _nextRecordCommand;
        private RelayCommand _previousRecordCommand;
        private RelayCommand _activateCommand;
        private RelayCommand _disableCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _importCommand;
        private RelayCommand _exportCommand;

       

        private RelayCommand _duplicateCommand;
        private RelayCommand<IClosable> _uploadCommand;

        private ICommand _openAddCustomerWindowCommand;
        private ICommand _openAddCustomerImportWindowCommand;
        private ICommand _openAddPartsWindowCommand;
        private ICommand _editImportPartOpenCommand;
        private ICommand _addImportPartOpenCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _saveImportCommand;
        private RelayCommand<IClosable> _bulkSaveCommand;

        private RelayCommand<IClosable> _selectCustomerCommand;
        private RelayCommand<IClosable> _selectPartCommand;
        private RelayCommand<IClosable> _addOrderItemCommand;
        private RelayCommand<IClosable> _addOrderItemImportCommand;
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
        public ObservableCollection<Quotation> BulkQuotations { get => _bulkQuotations; set { _bulkQuotations = value; RaisePropertyChanged(); } }
        public Quotation SelectedQuotation { get => _selectedQuotation; set { _selectedQuotation = value; RaisePropertyChanged(); } }
        public Quotation SelectedBulkQuotation { get => _selectedBulkQuotation; set { _selectedBulkQuotation = value; RaisePropertyChanged(); } }
        public OrderItem SelectedImportOrderItem { get => _selectedImportOrderItem; set { _selectedImportOrderItem = value; RaisePropertyChanged(); } }
        public Quotation NewQuotation { get => _newQuotation; set { _newQuotation = value; RaisePropertyChanged(); } }
        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }

        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand RemovePartCommand { get => _removePartCommand; set { _removePartCommand = value; RaisePropertyChanged(); } }
        public ICommand RemovePartImportCommand { get => _removePartImportCommand; set { _removePartImportCommand = value; RaisePropertyChanged(); } }
        public ICommand RemoveRecordCommand { get => _removeRecordCommand; set { _removeRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand NextRecordCommand { get => _nextRecordCommand; set { _nextRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand PreviousRecordCommand { get => _previousRecordCommand; set { _previousRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ImportCommand { get => _importCommand; set { _importCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ExportCommand{ get { return _exportCommand; } set { _exportCommand = value; RaisePropertyChanged(); }}
        public RelayCommand DuplicateCommand { get => _duplicateCommand; set { _duplicateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> UploadCommand { get => _uploadCommand; set { _uploadCommand = value; RaisePropertyChanged(); } }

        public ICommand OpenAddCustomerWindowCommand { get => _openAddCustomerWindowCommand; set { _openAddCustomerWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddCustomerImportWindowCommand { get => _openAddCustomerImportWindowCommand; set { _openAddCustomerImportWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddPartsWindowCommand { get => _addImportPartOpenCommand; set { _addImportPartOpenCommand = value; RaisePropertyChanged(); } }
        public ICommand AddImportPartOpenCommand { get => _openAddPartsWindowCommand; set { _openAddPartsWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditImportPartOpenCommand { get => _editImportPartOpenCommand; set { _editImportPartOpenCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveImportCommand { get => _saveImportCommand; set { _saveImportCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> BulkSaveCommand { get => _bulkSaveCommand; set { _bulkSaveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectCustomerCommand { get => _selectCustomerCommand; set { _selectCustomerCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SelectPartCommand { get => _selectPartCommand; set { _selectPartCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddOrderItemCommand { get => _addOrderItemCommand; set { _addOrderItemCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddOrderItemImportCommand { get => _addOrderItemImportCommand; set { _addOrderItemImportCommand = value; RaisePropertyChanged(); } }

        public ObservableCollection<Customer> CustomersList { get => _customersList; set { _customersList = value; RaisePropertyChanged(); } }
        public Customer SelectedCustomer { get => _selectedCustomer; set { _selectedCustomer = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> PartsList { get => _partsList; set { _partsList = value; RaisePropertyChanged(); } }
        public OrderItem SelectedOrderItem { get => _selectedOrderItem; set { _selectedOrderItem = value; RaisePropertyChanged(); } }
        public OrderItem RemoveSelectedOrderItem { get => _removeSelectedOrderItem; set { _removeSelectedOrderItem = value; RaisePropertyChanged(); } }

        public string Message { get => message; set { message = value; RaisePropertyChanged(); } }
        public string Note { get => note; set { note = value; RaisePropertyChanged(); } }
        public string DuplicateState { get => _duplicateState; set { _duplicateState = value; RaisePropertyChanged(); } }

        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }

        //public IEnumerable<object> Articles { get; private set; }

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
           
            foreach (var item in NewQuotation.Order.OrderItems)
            {
                if (item.InventoryId > 0)
                {
                    item.Inventory = null;
                }
                item.IsActive = 1;
                item.OrderId = NewQuotation.OrderId;
            }
            if( NewQuotation.Customer.Id > 0)
            {
                NewQuotation.CustomerId = NewQuotation.Customer.Id;
                NewQuotation.Customer = null;

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
        
        private async void SaveImport(IClosable p)
        {
            //Data Checks
            var list = await DuplicateChecks(BulkQuotations.ToList());
            BulkQuotations = new ObservableCollection<Quotation>(list);
            foreach (var quotes in BulkQuotations)
            {
                if(quotes.Order != null)
                {
                    if (quotes.Order.OrderItems != null)
                    {
                        foreach (var item in quotes.Order.OrderItems)
                        {
                            if (item.InventoryId > 0)
                            {
                                item.Inventory = null;
                            }
                            item.IsActive = 1;
                            item.OrderId = quotes.OrderId;
                        }
                    }

                }
                if (quotes.Customer != null) {
                    if (quotes.Customer.Id > 0)
                    {
                        quotes.CustomerId = quotes.Customer.Id;
                        quotes.Customer = null;
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
        

        private async void OpenAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedOrderItem = new OrderItem() { Inventory = new Inventory()};
            var window = new QuotationAddPartsView(this);
            window.ShowDialog();
        }
        private async void OpenImportAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedImportOrderItem = new OrderItem() { Inventory = new Inventory()};
            var window = new QuotationImportAddOrderItemView(this);
            isEdit = false;
            window.ShowDialog();
        }
        private async void OpenImportEditWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            isEdit = true;
            var window = new QuotationImportAddOrderItemView(this);
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
        private void AddOrderItemsImport(IClosable i)
        {
            //Add new Order Item
            if (!isEdit)
            {
                if (SelectedImportOrderItem.Inventory.PartNumber != "")
                {
                    SelectedImportOrderItem.Inventory.IsActive = 1;
                    SelectedImportOrderItem.CalculateTotal();
                    if (SelectedBulkQuotation.Order.OrderItems.Count == 0)
                    {
                        SelectedBulkQuotation.Order.OrderItems = new ObservableCollection<OrderItem>();
                    }
                    SelectedBulkQuotation.Order.OrderItems.Add(new OrderItem()
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
                    SelectedBulkQuotation.CalculateNetTotal();

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
                    var part = SelectedBulkQuotation.Order.OrderItems.Where(item =>
                        (item.Inventory.PartNumber == SelectedImportOrderItem.Inventory.PartNumber)).FirstOrDefault();
                    
                    part = SelectedImportOrderItem;                    
                    SelectedBulkQuotation.CalculateNetTotal();
                    i.Close();
                }
            }
            
            
            
        }
        private void RemovePart()
        {
            NewQuotation.Order.OrderItems.Remove(RemoveSelectedOrderItem);
            NewQuotation.CalculateNetTotal();
            
        }
        private void RemoveImportPart()
        {
            SelectedBulkQuotation.Order.OrderItems.Remove(SelectedImportOrderItem);
            SelectedBulkQuotation.CalculateNetTotal();
            
        }
        private void RemoveImportRecord()
        {
            if (BulkQuotations.Count > 1)
            {
                BulkQuotations.Remove(SelectedBulkQuotation);
                NextRecord();
            }
            else if(BulkQuotations.Count == 1)
            {
                BulkQuotations.Remove(SelectedBulkQuotation);
                SelectedBulkQuotation = new Quotation();
            }
            
        }
        
        
        private void SelectCustomersCommand(IClosable i)
        {

            i.Close();
        }
        private async Task Upload(IClosable i)
        {
            if(FilePath.IndexOf("quotation", StringComparison.OrdinalIgnoreCase) >= 0 && !string.IsNullOrWhiteSpace(FilePath))
            {
                if (IsIgnoreCheck)
                {
                    await ReadQuotationFileExcel(FilePath);
                    var window = new QuotationImportDisplayView(this);

                    //Instead of the whole of BulkQuotation use SelectedBulkQuotaion
                    if (BulkQuotations == null)
                    {
                        return;
                    }
                    foreach (var quote in BulkQuotations)
                    {
                        foreach (var part in quote.Order.OrderItems)
                        {
                            part.CalculateTotal();
                            part.CalculateVAT();
                        }
                    }
                    SelectedBulkQuotation = BulkQuotations[0];
                    i.Close();
                    window.ShowDialog();

                }
                else if (IsUpdateCheck)
                {
                    await ReadQuotationFileExcel(FilePath);
                    var window = new QuotationImportDisplayView(this);
                    if (BulkQuotations == null)
                    {
                        return;
                    }
                    i.Close();
                    foreach (var quote in BulkQuotations)
                    {
                        foreach (var part in quote.Order.OrderItems)
                        {
                            part.CalculateTotal();
                            part.CalculateVAT();
                        }
                    }
                    SelectedBulkQuotation = BulkQuotations[0];
                    window.ShowDialog();

                }

            }
            else
            {
                MessageBox.Show("Error: Invalid file path");
                return;
            }
            
            
        }
        private void NextRecord()
        {
            int length = BulkQuotations.Count;
            try
            {
                int index = BulkQuotations.IndexOf(SelectedBulkQuotation);
                SelectedBulkQuotation = BulkQuotations[index + 1];
                
            }
            catch(Exception ex) 
            {
                MessageBox.Show("No More records to display");
            }
        }
        private void PreviousRecord()
        {
            try
            {
                int index = BulkQuotations.IndexOf(SelectedBulkQuotation);
                SelectedBulkQuotation = BulkQuotations[index - 1];

            }
            catch (Exception ex ) 
            {
                MessageBox.Show("No More records to display");
            }
        }
        private void ImportQuotation()
        {
            FilePath = "";
            DuplicateState = "";
            var window = new ImportFileView();
            window.DataContext = this;
            window.ShowDialog();
            
        }
        private void ExportQuotation()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Quotation"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel(.xlsx)|*.xlsx |Excel(.xls)|*.xls"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                WriteFileExcel(filename);
            }
            
        }
        private void ExportFile(IClosable i)
        {
            if (IsIgnoreCheck) {  WriteFileExcel(FilePath); }
            else if (IsUpdateCheck) { WriteFileExcel(FilePath); }
            i.Close();
        }
        private void WriteFileExcel(string path)
        {
             
           ExcelPackage excel = new ExcelPackage();
           try
           {
                // name of the sheet 
                if (SelectedQuotation == null)
                {
                    MessageBox.Show("Error. Exporting file. No Quotation was selected. Please select a quotation and try again");
                    return;
                }
                var workSheet = excel.Workbook.Worksheets.Add($"{SelectedQuotation.Id}");
                //Header
                ExcelHeader(workSheet);
            
                workSheet.Cells["A4"].Value = "REF: ";
                workSheet.Cells["A4"].Style.Font.Bold = true;

                workSheet.Cells["B4:C4"].Merge= true;
                workSheet.Cells["B4"].Value = $"{SelectedQuotation.ReferenceNumber}";

                workSheet.Cells["D4"].Value = "DATE: ";
                workSheet.Cells["D4"].Style.Font.Bold= true;

                workSheet.Cells["E4"].Value = $"{SelectedQuotation.DateCreated.ToShortDateString()}";

                workSheet.Cells["A5"].Value = "To: ";
                workSheet.Cells["A5"].Style.Font.Bold = true;
                workSheet.Cells["B5"].Value = $"MR. {SelectedQuotation.Customer.FirstName.ToUpper() } {SelectedQuotation.Customer.LastName.ToUpper()}";

                workSheet.Cells["A6"].Value = "ATTN: ";
                workSheet.Cells["A6"].Style.Font.Bold = true;
                workSheet.Cells["B6"].Value = $"{SelectedQuotation.Attn}";

                workSheet.Cells["A7"].Value = "M/S";
                workSheet.Cells["A7"].Style.Font.Bold = true;
                workSheet.Cells["B7"].Value = $"{SelectedQuotation.MS}";
                workSheet.Row(4).Style.Font.Size = 9;
                workSheet.Row(5).Style.Font.Size = 9;
                workSheet.Row(6).Style.Font.Size = 9;
                workSheet.Row(7).Style.Font.Size = 9;
                workSheet.Cells["A8:G8"].Merge = true;
                workSheet.Cells["A8:G8"].Value = "QUOTATION";
                workSheet.Cells["A8:G8"].Style.Font.Bold = true;
                workSheet.Cells["A8:G8"].Style.Font.Italic = true;
                workSheet.Cells["A8:G8"].Style.Font.UnderLine = true;
                workSheet.Row(8).Style.Font.Color.SetColor(Color.White) ;
                workSheet.Cells["A8:G8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A8:G8"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A8:G8"].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue); 
            
                workSheet.Cells["A9"].Value = "Dear Sir."; 
                workSheet.Cells["A10"].Value = "Thank you for your inquiry."; 
                workSheet.Cells["A11"].Value = "We are pleased to quote our best prices as follows:";
                workSheet.Row(9).Style.Font.Size = 9;
                workSheet.Row(10).Style.Font.Size = 9;
                workSheet.Row(11).Style.Font.Size = 9;

                workSheet.Cells["A12"].Value = "S.No"; 
            
                workSheet.Cells["B12"].Value = "Part No."; 
                workSheet.Cells["C12"].Value = "Description"; 
                workSheet.Cells["D12"].Value = "Qty"; 
            
                workSheet.Cells["E12"].Value = "Units"; 
                workSheet.Cells["F12"].Value = "Unit Price"; 
                workSheet.Cells["G12"].Value = "Total Price";
                workSheet.Cells["A12:G12"].Style.Font.Bold = true;

                workSheet.Cells["A12:G12"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A12:G12"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A12:G12"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A12:G12"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;


                int i = 13;
                int count = 1;
                foreach(var items in SelectedQuotation.Order.OrderItems)
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
                
                    workSheet.Cells[$"G{i}"].Value = $"{items.Total}";
                
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    i++;
                    count++;
                }
                double total = SelectedQuotation.Order.TotalPrice;

                //Gross Total
                workSheet.Cells[$"A{i}:F{i}"].Merge = true;
                workSheet.Cells[$"A{i}:F{i}"].Value = "Gross Total";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"G{i}"].Value = $"{SelectedQuotation.Order.TotalPrice}";
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
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedQuotation.VAT}% Vat";
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                double vatCal = (SelectedQuotation.VAT / 100 * total);
                workSheet.Cells[$"G{i}"].Value = $"{vatCal}";
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
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedQuotation.OfferedDiscount}% Discount";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                double discount = SelectedQuotation.OfferedDiscount > 0?(SelectedQuotation.OfferedDiscount / 100 * total):0;
                workSheet.Cells[$"G{i}"].Value = $"{discount}";
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
                double net = Math.Round(SelectedQuotation.NetTotal, 2);
                string nettotal = net.ToString();
                string whole = "", decimalVal = "";
                int dp = nettotal.IndexOf(".");
                if (dp > 0)
                {
                    whole = nettotal.Substring(0, dp);
                    decimalVal = nettotal.Substring(dp + 1);
                }
                int _whole = Int32.Parse(whole);
                int _fills = Int32.Parse(decimalVal);
                if (decimalVal.Length == 1)
                    _fills = _fills * 10;
                string netword = _whole.ToWords();
                string fills = $"& Fils  {_fills.ToWords().ToUpper()}/100 only";
                workSheet.Cells[$"B{i}:F{i}"].Value = $"AED. {netword.ToUpper()} {fills}" ;
                workSheet.Cells[$"B{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"G{i}"].Value = $"{net}";
                workSheet.Cells[$"G{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"G{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                i++;
                ExcelFooter(workSheet, i);

                workSheet.Column(1).Width = 7.33;
                workSheet.Column(2).Width = 14;
                workSheet.Column(3).Width = 41;
                workSheet.Column(4).AutoFit();
                workSheet.Column(5).AutoFit();
                workSheet.Column(7).AutoFit();

                // file name with .xlsx extension  
                string p_strPath = "C:\\Users\\zobad\\Desktop\\Hamza\\ExcelTest\\test.xlsx";

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

            // workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Row(1).Style.Font.Bold = true;
            workSheet.Row(1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            workSheet.Row(2).Height = 14.7;
            workSheet.Row(2).Style.Font.Size = 9;
            workSheet.Row(2).Style.Font.Name = "Trebuchet MS";
            workSheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            // workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Row(2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            workSheet.Row(2).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;

            workSheet.Row(3).Height = 14.7;
            workSheet.Row(3).Style.Font.Size = 9;
            workSheet.Row(3).Style.Font.Name = "Trebuchet MS";
            workSheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            // workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
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
            int PixelTop = 0;
            int PixelLeft = 50 * 3;
            //Title logo
            Image logo = Image.FromFile(@"C:\Users\zobad\Desktop\Hamza\ExcelTest\logo.jpg");
            ExcelPicture pic = workSheet.Drawings.AddPicture("Logo", logo);
            pic.SetSize(4);
            pic.SetPosition(0, 0, 1, 110);
            // pic.SetPosition(PixelTop, PixelLeft);

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

            //workSheet.Cells["A3:G3"].Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            //workSheet.Cells["A3:G3"].Style.Border.Top.Style = ExcelBorderStyle.None;
            //workSheet.Cells["A3:G3"].Style.Border.Right.Style = ExcelBorderStyle.None;
            //workSheet.Cells["A3:G3"].Style.Border.Left.Style = ExcelBorderStyle.None;

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
            workSheet.Cells[$"A{ i}:G{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:G{i}"].Value = "Delivery: 5 days on order confirmation., ";
            workSheet.Cells[$"A{ i}:G{i}"].Style.Font.Italic = true;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;

            i++;
            workSheet.Cells[$"A{ i}:G{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:G{i}"].Value = "Price quoted Net in UAE Dirhams, ex-warehouse. ";
            workSheet.Cells[$"A{ i}:G{i}"].Style.Font.Italic = true;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;

            i++;
            workSheet.Cells[$"A{ i}:G{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:G{i}"].Value = "Make: Genuine Part";
            workSheet.Cells[$"A{ i}:G{i}"].Style.Font.Italic = true;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            i++;
            workSheet.Cells[$"A{ i}:G{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:G{i}"].Value = "Validity: 1 week";
            workSheet.Cells[$"A{ i}:G{i}"].Style.Font.Italic = true;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            i++;
            workSheet.Cells[$"A{ i}:G{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:G{i}"].Value = "Payment: 100% cash on order confirmation.";
            workSheet.Cells[$"A{ i}:G{i}"].Style.Font.Italic = true;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            workSheet.Cells[$"A{i}:G{i}"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Left.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Right.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Top.Style = ExcelBorderStyle.None;
            workSheet.Cells[$"A{i}:G{i}"].Style.Border.Bottom.Style = ExcelBorderStyle.None;
            i++;
            workSheet.Cells[$"A{ i}:G{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:G{i}"].Value = "Awaiting your valued order & assuring you of our best services always.";
            workSheet.Row(i).Height = 27;
            i++; i++;
            workSheet.Cells[$"A{ i}:B{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:B{i}"].Value = "Thanks & Regards,";
            i++;
            //Name of the user
            i++;
            //Company Name
            workSheet.Cells[$"A{ i}:B{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:B{i}"].Value = "For Saadia Trading Co.";
        }
        private async Task BulkInsert()
        {

            // The result of each spreadsheet is in result.Tables

        }

        /// <summary>
        /// Calls Bulk Save service and then closes the window
        /// </summary>
        /// <param name="p"></param>
        private async void BulkSave(IClosable p)
        {
            //Data Checks
            //Close the window and call the bulk insert service

            if (BulkQuotations.Count > 0)
            {
                if (await service.CallBulkInsert(BulkQuotations.ToList()))
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
        private async void BulkUpdate(IClosable p)
        {
            //Data Checks
            //Close the window and call the bulk insert service

            if (BulkQuotations.Count > 0)
            {
                if (await service.CallBulkUpdate(BulkQuotations.ToList()))
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
        private async Task ReadQuotationFileExcel(string path)
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
                        //quotes = await DuplicateChecks(quotes);
                        BulkQuotations = new ObservableCollection<Quotation>();
                        foreach (var item in quotes)
                        {
                            if (item.Id > 0)
                            {
                                BulkQuotations.Add(item);
                            }
                            else if (item.Id == 0)
                            {
                                BulkQuotations.Add(item);
                            }
                        }
                        
                        //if (addquotes.Count > 0)
                        //{
                        //    if (await service.CallBulkInsert(addquotes))
                        //    {
                        //        MessageBox.Show("Bulk Insert Success");
                        //    }
                        //}
                        //else if (updatequotes.Count > 0)
                        //{
                        //    await service.CallBulkUpdate(updatequotes);
                        //    MessageBox.Show("Bulk Insert Success. Duplicates records updated");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Nothing to insert.Records Already uptodate");
                        //}
                        //await GetAll();
                        //// The result of each spreadsheet is in result.Tables
                    }
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
                        foreach (var _item in item.Order.OrderItems)
                        {
                            _item.VatPercent = item.VAT;
                            _item.CalculateVAT();
                        }
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
                        foreach (var _item in item.Order.OrderItems)
                        {
                            _item.VatPercent = item.VAT;
                            _item.CalculateVAT();
                        }
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
                foreach(var item in SelectedQuotation.Order.OrderItems)
                {
                    item.VatPercent = SelectedQuotation.VAT;
                    item.CalculateVAT();
                }
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