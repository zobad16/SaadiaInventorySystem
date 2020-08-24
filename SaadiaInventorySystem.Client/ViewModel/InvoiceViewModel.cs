﻿using ExcelDataReader;
using Microsoft.Office.Core;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InvoiceViewModel : BaseViewModel,IViewModel
    {
        string arabic_txt = "شركة سعدية للتجارة ذ.م.م";
        private string _name;
        private ObservableCollection<Invoice> _invoices;
        private ObservableCollection<Customer> _customersList;
        private Customer _selectedCustomer;
        private Invoice _selectedInvoice;
        private ObservableCollection<Inventory> _partsList;
        private Invoice _newInvoice;
        private OrderItem _selectedOrderItem;
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
        public Invoice SelectedInvoice { get => _selectedInvoice; set { _selectedInvoice = value; RaisePropertyChanged(); } }
        public Invoice NewInvoice { get => _newInvoice; set { _newInvoice = value; RaisePropertyChanged(); } }
        public ObservableCollection<Invoice> Invoices { get => _invoices; set { _invoices = value; RaisePropertyChanged(); } }
        public bool IsUpdateCheck { get => _isUpdateCheck; set { _isUpdateCheck = value; RaisePropertyChanged(); } }
        public bool IsIgnoreCheck { get => _isIgnoreCheck; set { _isIgnoreCheck = value; RaisePropertyChanged(); } }
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
            EditWindowCommand = new RelayCommand(i => OpenEditWindow(), i => SelectedInvoice != null);
            OpenAddCustomerWindowCommand = new RelayCommand(i => OpenAddCustomerWindow(), i => true);
            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a) => SelectedInvoice != null);
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedInvoice != null);
            DeleteCommand = new RelayCommand(i => Delete(), (a) => SelectedInvoice != null);
            ImportCommand = new RelayCommand(i => ImportInvoice(), i => true);
            UploadCommand = new RelayCommand<IClosable>(i => Upload(i), i => true);
            SelectCustomerCommand = new RelayCommand<IClosable>(i => SelectCustomersCommand(i), i => true);
            SelectPartCommand = new RelayCommand<IClosable>(i => SelectPartsCommand(i), i => true);
            AddOrderItemCommand = new RelayCommand<IClosable>(i => AddOrderItem(i), i => true);
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

        private void SelectPartsCommand(IClosable i)
        {
            throw new NotImplementedException();
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
            foreach (var item in NewInvoice.Order.OrderItems)
            {
                if (item.InventoryId > 0)
                {
                    item.Inventory = null;
                }
                item.IsActive = 1;
                item.OrderId = NewInvoice.OrderId;
            }
            NewInvoice.CustomerId = NewInvoice.Customer.Id;
            NewInvoice.Customer = null;

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
            await GetAll();
        }

        private async void OpenAddPartsWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            SelectedOrderItem = new OrderItem() { Inventory = new Inventory() };
            var window = new InvoiceAddPartsView(this);
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
        private async Task Upload(IClosable i)
        {
            /*if (IsIgnoreCheck) { await ReadInvoiceFileExcel(FilePath); }
            else if (IsUpdateCheck) { await ReadInvoiceFileExcel(FilePath); }
            i.Close();*/
            //ReadIvoiceExcelCom(FilePath);
            ReadIvoiceExcelEpp(FilePath);
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
               
                foreach(var sheet in workbook.Worksheets)
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
                        var data = Convert.ToString( drawing);
                        Console.WriteLine("Drawing Type:" + type + " Data: " + data);
                    }

                }
                
            }



        }
        private void ReadIvoiceExcelCom(string path)
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            int sheets = xlWorkbook.Sheets.Count;
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            for (int sheet = 1; sheet <= sheets;sheet++)
            {
                xlWorksheet = xlWorkbook.Sheets[sheet];

                xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        //new line
                        if (col == 1)
                            Console.Write("\r\n");
                        var xlobj = xlRange.Cells[row, col];
                        var data = Convert.ToString(xlobj.Value2);
                        //write the value to the console
                        if (xlobj != null && data != null)
                            Console.Write(data + "\t");

                        //add useful things here!   
                    }
                }
                Excel.Shapes shapes = xlWorksheet.Shapes;
                for (int i = 1; i <= shapes.Count; i++)
                {
                    Excel.Shape shape = shapes.Item(i);
                    
                    var type = shape.Type;
                    var title = shape.Title;
                    var tb1 = shape.TextFrame;
                    var tb2 = shape.TextFrame2;
                    var tb3 = shape.AlternativeText;
                    if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                    {
                        string shapeTxt = Convert.ToString(shape.TextFrame.Characters(Type.Missing, Type.Missing).Text);
                        Console.Write(shapeTxt + "\t");
                    }
                    if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoAutoShape)
                    {
                        //var grpEnumerator = shape.GroupItems.;
                        //List<string> grpItemList = grpEnumerator.ToList<string>();
                        //Console.Write(shapeTxt + "\t");
                    }
                }



            }
            
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);


        }
        private async Task ReadInvoiceFileExcel(string path)
        {
            if (path.IndexOf("invoice", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var invoice = new List<Invoice>();
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
                                   /* if (current.Contains("ATTN"))
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
                                    }*/
                                }
                            }
                            invoice.Add(q);
                        }
                        /*quotes = await DuplicateChecks(quotes);

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
                        }*/
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
                    }
                    IsAdmin = true;
                }
                else if (CurrentUserRole(AppProperties.ROLE_USER))
                {
                    Invoices = new ObservableCollection<Invoice>(await service.CallGetAllService());
                    foreach (var item in Invoices)
                    {
                        item.CalculateNetTotal();
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
        private async void ActivateAsync()
        {
            if (await service.CallActivateService(SelectedInvoice.Id))
            {
                MessageBox.Show("Invoice Activated");
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