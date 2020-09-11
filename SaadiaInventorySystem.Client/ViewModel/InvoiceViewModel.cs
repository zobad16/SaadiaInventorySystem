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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InvoiceViewModel : BaseViewModel, IViewModel
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
        private RelayCommand _exportCommand;


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
        public RelayCommand ExportCommand { get { return _exportCommand; } set { _exportCommand = value; RaisePropertyChanged(); } }

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
            ExportCommand = new RelayCommand(i => ExportInvoice(), (i) => SelectedInvoice != null);
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
            await ReadInvoiceExcel(FilePath);
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
            i++;
            i++;
            i++;
            i++;
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
        private void ReadIvoiceExcelCom(string path)
        {

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            int sheets = xlWorkbook.Sheets.Count;
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            for (int sheet = 1; sheet <= sheets; sheet++)
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
                                     }*/
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
                                    /*if (col > 0)
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
                                    }*
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
                                    // await GetAll();
                                    // The result of each spreadsheet is in result.Tables
                                }
                            }
                            invoices.Add(q);
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
                workSheet.Cells["D5"].Value = "TAX INVOICE: ";
                workSheet.Cells["D5:E5"].Merge = true;


                workSheet.Cells["A6"].Value = "TRN: ";
                workSheet.Cells["A6"].Style.Font.Bold = true;
                workSheet.Cells["B6"].Value = $"{SelectedInvoice.Customer.Trn }";
                workSheet.Cells["D6"].Value = "DATE: ";
                workSheet.Cells["D6"].Style.Font.Bold = true;
                workSheet.Cells["E6"].Value = $"{SelectedInvoice.DateCreated.ToShortDateString()}";

                workSheet.Cells["A7"].Value = "Company: ";
                workSheet.Cells["A7"].Style.Font.Bold = true;
                workSheet.Cells["B7"].Value = $"{SelectedInvoice.Customer.CompanyName.ToUpper()}";
                workSheet.Cells["D7"].Value = "Invoice No: ";
                workSheet.Cells["D7"].Style.Font.Bold = true;
                workSheet.Cells["E7"].Value = $"{SelectedInvoice.Id}";

                workSheet.Cells["A8"].Value = "Address: ";
                workSheet.Cells["A8"].Style.Font.Bold = true;
                workSheet.Cells["B8"].Value = $"{SelectedInvoice.Customer.Address.ToUpper()}";
                workSheet.Cells["D8"].Value = "Quotation No: ";
                workSheet.Cells["D8"].Style.Font.Bold = true;
                string qno = "-";
                if (!String.IsNullOrEmpty(qno))
                    qno = $"{SelectedInvoice.QuotationId}";
                workSheet.Cells["E8"].Value = $"{qno}";

                workSheet.Cells["A9"].Value = "TEL: ";
                workSheet.Cells["A8"].Style.Font.Bold = true;
                workSheet.Cells["B9"].Value = $"{SelectedInvoice.Customer.PhoneNumber}";
                workSheet.Cells["D9"].Value = "Order Purchase No: ";
                workSheet.Cells["D9"].Style.Font.Bold = true;
                workSheet.Cells["E9"].Value = $"{SelectedInvoice.OrderPurchaseNumber}";

                workSheet.Row(5).Style.Font.Size = 9;
                workSheet.Row(6).Style.Font.Size = 9;
                workSheet.Row(7).Style.Font.Size = 9;
                workSheet.Row(8).Style.Font.Size = 9;
                workSheet.Row(9).Style.Font.Size = 9;

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

                    workSheet.Cells[$"G{i}"].Value = $"{items.Total}";

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
                workSheet.Cells[$"G{i}"].Value = $"{SelectedInvoice.Order.TotalPrice}";
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
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedInvoice.OfferedDiscount}% Discount";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                double discount = SelectedInvoice.OfferedDiscount > 0 ? (SelectedInvoice.OfferedDiscount / 100 * total) : 0;
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
                double net = SelectedInvoice.NetTotal;
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

                workSheet.Cells[$"B{i}:F{i}"].Value = $"AED. {netword.ToUpper()} {fills}";
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