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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InquiryViewModel : BaseViewModel, IViewModel
    {
        private string _name;
        private string _filePath;
        private string _duplicateState;
        private int active;
        private Inquiry _selectedInquiry;
        private Inquiry _newInquiry;
        private ObservableCollection<Inquiry> inquirys;
        private ObservableCollection<Inventory> _partsList;
        private ObservableCollection<Inquiry> _bulkInquiry;
        private InquiryItem _selectedInquiryItem;
        private Inquiry _selectedBulkInquiry;
        private InquiryItem _selectedItem;
        private InquiryItem _removeSelectedItem;
        private readonly InquiryService service;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private ICommand _openAddPartsWindowCommand;
        private ICommand _removePartCommand;
        private ICommand _removePartImportCommand;
        private ICommand _removeRecordCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _activateCommand;
        private RelayCommand _disableCommand;
        private RelayCommand _importCommand;
        private RelayCommand _exportCommand;
        private RelayCommand _nextRecordCommand;
        private RelayCommand _previousRecordCommand;
        private RelayCommand _duplicateCommand;
        private RelayCommand<IClosable> _uploadCommand;
        private RelayCommand<IClosable> _addInquiryItemCommand;
        private RelayCommand  _addImportPartOpenCommand;
        private RelayCommand<IClosable> _addInquiryItemImportCommand;
        private RelayCommand _editImportPartOpenCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _saveImportCommand;
        private RelayCommand<IClosable> _bulkSaveImportCommand;

        private bool _isUpdateCheck;
        private bool _isIgnoreCheck;
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
            RemovePartImportCommand = new RelayCommand(i => RemoveImportPart(), i => SelectedInquiryItem != null);
            RemoveRecordCommand = new RelayCommand(i => RemoveImportRecord(), i => BulkInquiry.Count >= 1);

            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a) => SelectedInquiry != null);
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedInquiry != null);
            DeleteCommand = new RelayCommand(i => DeleteAsync(), (a) => SelectedInquiry != null);
            ImportCommand = new RelayCommand(i => ImportInvoice(), i => true);
            ExportCommand = new RelayCommand(i => ExportInquiry(), (i) => SelectedInquiry != null); 
            NextRecordCommand = new RelayCommand(i => NextRecord());
            PreviousRecordCommand = new RelayCommand(i => PreviousRecord());
            SaveImportCommand = new RelayCommand<IClosable>(i => SaveImport(i), i => BulkInquiry.Count <= 1);
            BulkSaveCommand = new RelayCommand<IClosable>(i => BulkSave(i), i => true);
            AddImportPartOpenCommand = new RelayCommand(i => OpenImportAddPartsWindow(), i => true);
            AddInquiryItemCommand = new RelayCommand<IClosable>(i => AddInquiryItem(i), i => true);
            AddInquiryItemImportCommand = new RelayCommand<IClosable>(i => AddImportInquiryItem(i), i => true);
            EditImportPartOpenCommand = new RelayCommand(i => OpenImportEditWindow(), (i) => SelectedInquiryItem != null);
            DuplicateCommand = new RelayCommand(i => SetDuplicateSet(i), i => true);
            UploadCommand = new RelayCommand<IClosable>(i => Upload(i), i => true);
        }

        

        public string Name { get => _name; private set { _name = value; RaisePropertyChanged(); } }
        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }
        public bool IsUpdateCheck { get => _isUpdateCheck; set { _isUpdateCheck = value; RaisePropertyChanged(); } }
        public bool IsIgnoreCheck { get => _isIgnoreCheck; set { _isIgnoreCheck = value; RaisePropertyChanged(); } }

        public RelayCommand AddImportPartOpenCommand { get => _addImportPartOpenCommand; set { _addImportPartOpenCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddInquiryItemImportCommand { get => _addInquiryItemImportCommand; set { _addInquiryItemImportCommand = value; RaisePropertyChanged(); } }
        public RelayCommand EditImportPartOpenCommand { get => _editImportPartOpenCommand; set { _editImportPartOpenCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> AddInquiryItemCommand { get => _addInquiryItemCommand; set { _addInquiryItemCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        
        public Inquiry NewInquiry { get => _newInquiry;  set { _newInquiry = value; RaisePropertyChanged(); } }
        public Inquiry SelectedInquiry { get => _selectedInquiry;  set { _selectedInquiry = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveImportCommand { get => _saveImportCommand; set { _saveImportCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> BulkSaveCommand { get => _bulkSaveImportCommand; set { _bulkSaveImportCommand = value; RaisePropertyChanged(); } }

        public ObservableCollection<Inquiry> Inquirys { get => inquirys; set { inquirys = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> PartsList { get => _partsList; set { _partsList = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inquiry> BulkInquiry { get => _bulkInquiry; set { _bulkInquiry = value; RaisePropertyChanged(); } }
        public InquiryItem SelectedInquiryItem { get => _selectedInquiryItem; set { _selectedInquiryItem = value; RaisePropertyChanged(); } }
        public Inquiry SelectedBulkInquiry { get => _selectedBulkInquiry; set { _selectedBulkInquiry = value; RaisePropertyChanged(); } }

        public InquiryItem SelectedItem { get => _selectedItem; set { _selectedItem = value; RaisePropertyChanged(); } }
        public InquiryItem RemoveSelectedItem { get => _removeSelectedItem; set { _removeSelectedItem = value; RaisePropertyChanged(); } }

        public ICommand RemovePartCommand { get => _removePartCommand; set { _removePartCommand = value; RaisePropertyChanged(); } }
        public ICommand RemovePartImportCommand { get => _removePartImportCommand; set { _removePartImportCommand = value; RaisePropertyChanged(); } }
        public ICommand RemoveRecordCommand { get => _removeRecordCommand; set { _removeRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ImportCommand { get => _importCommand; set { _importCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ExportCommand { get => _exportCommand; set { _exportCommand = value; RaisePropertyChanged(); } }
        public RelayCommand NextRecordCommand { get => _nextRecordCommand; set { _nextRecordCommand = value; RaisePropertyChanged(); } }
        public RelayCommand PreviousRecordCommand{ get => _previousRecordCommand; set { _previousRecordCommand = value; RaisePropertyChanged(); } }
        
        public RelayCommand DuplicateCommand { get => _duplicateCommand; set { _duplicateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> UploadCommand { get => _uploadCommand; set { _uploadCommand = value; RaisePropertyChanged(); } }
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddPartsWindowCommand { get => _openAddPartsWindowCommand; set { _openAddPartsWindowCommand = value; RaisePropertyChanged(); } }
        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }
        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }
        public string DuplicateState { get => _duplicateState; set { _duplicateState = value; RaisePropertyChanged(); } }

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
        private void AddImportInquiryItem(IClosable i)
        {
           if (SelectedInquiryItem.Inventory.PartNumber != "")
            {
                SelectedInquiryItem.Inventory.IsActive = 1;
               if (SelectedBulkInquiry.Items.Count == 0)
                {
                    SelectedBulkInquiry.Items = new ObservableCollection<InquiryItem>();
                }
                SelectedBulkInquiry.Items.Add(new InquiryItem()
                {
                    Inventory = SelectedInquiryItem.Inventory,
                    InventoryId = SelectedInquiryItem.Inventory.Id,
                    OfferedPrice = SelectedInquiryItem.OfferedPrice,
                    OfferedQty = SelectedInquiryItem.OfferedQty,
                    IsActive = 1

                });
                SelectedBulkInquiry.CalculateNetTotal();

                i.Close();
            }
        }
        private void RemovePart()
        {
            NewInquiry.Items.Remove(RemoveSelectedItem);
            NewInquiry.CalculateNetTotal();
        }
        private void RemoveImportPart()
        {
            SelectedBulkInquiry.Items.Remove(SelectedInquiryItem);
            SelectedBulkInquiry.CalculateNetTotal();

        }
        private void RemoveImportRecord()
        {
            if (BulkInquiry.Count > 1)
            {
                BulkInquiry.Remove(SelectedBulkInquiry);
                NextRecord();
            }
            else if (BulkInquiry.Count == 1)
            {
                BulkInquiry.Remove(SelectedBulkInquiry);
                SelectedBulkInquiry = new Inquiry();
            }

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
        private async void SaveImport(IClosable p)
        {
            //Data Checks
            var list = await DuplicateChecks(BulkInquiry.ToList());
            BulkInquiry = new ObservableCollection<Inquiry>(list);
            foreach (var inquiry in BulkInquiry)
            {
                if (inquiry.Items!= null)
                {
                    foreach (var item in inquiry.Items)
                    {
                        if (item.InventoryId > 0)
                        {
                            item.Inventory = null;
                        }
                        item.IsActive = 1;                        
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
        /// <summary>
        /// Calls Bulk Save service and then closes the window
        /// </summary>
        /// <param name="p"></param>
        private async void BulkSave(IClosable p)
        {
            //Data Checks
            //Close the window and call the bulk insert service

            if (BulkInquiry.Count > 0)
            {
                if (await service.CallBulkInsert(BulkInquiry.ToList()))
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
            if (CurrentUserRole(AppProperties.ROLE_ADMIN))
            {
                PartsList = new ObservableCollection<Inventory>(await _service.CallAdminGetAllService());
            }
            else
            {
                PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            }
            SelectedInquiryItem = new InquiryItem() { Inventory = new Inventory() };
            var window = new InquiryImportAddItemView(this);
            isEdit = false;
            window.ShowDialog();
        }
        private async void BulkUpdate(IClosable p)
        {
            //Data Checks
            //Close the window and call the bulk insert service

            if (BulkInquiry.Count > 0)
            {
                if (await service.CallBulkUpdate(BulkInquiry.ToList()))
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
        private async Task<List<Inquiry>> DuplicateChecks(List<Inquiry> inquiry)
        {
            var _partsService = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _partsService.CallGetAllService());
            var inquiry_list = new List<Inquiry>();
            foreach (var q in inquiry)
            {
                if (q != null)
                {
                    var _inquiries = Inquirys.Where(i => (q.InquiryNumber != null && q.InquiryNumber == i.InquiryNumber) ).FirstOrDefault();
                    if (_inquiries != null && IsIgnoreCheck)
                    {
                        continue;
                    }
                    else if (_inquiries != null && IsUpdateCheck)
                    {
                        q.Id = _inquiries.Id;
                        foreach (var item in q.Items)
                        {
                            item.InquiryId = _inquiries.Id;
                            //item.Inquiry.Id = _inquiries.Id;
                        }
                    }
                    //Check order Parts
                    foreach (var part in q.Items)
                    {
                        part.IsActive = 1;
                        part.Inventory.IsActive = 1;
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
                    inquiry_list.Add(q);
                }
            }

            return inquiry_list;
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
            if (CurrentUserRole(AppProperties.ROLE_ADMIN))
            {
                PartsList = new ObservableCollection<Inventory>(await _service.CallAdminGetAllService());
            }
            else
            {
                PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            }
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
        private async void OpenImportEditWindow()
        {
            var _service = new InventoryService();
            if (CurrentUserRole(AppProperties.ROLE_ADMIN))
            {
                PartsList = new ObservableCollection<Inventory>(await _service.CallAdminGetAllService());
            }
            else
            {
                PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
            }
            isEdit = true;
            var window = new InquiryImportAddItemView(this);
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
        private void SetDuplicateSet(object param)
        {
            DuplicateState = (string)param;
        }
        private void ImportInvoice()
        {
            FilePath = "";
            DuplicateState = "";
            var window = new ImportFileView();
            window.DataContext = this;
            window.ShowDialog();

        }
        private void ExportInquiry()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Inquiry"; // Default file name
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
        private void WriteFileExcel(string path)
        {

            ExcelPackage excel = new ExcelPackage();
            try
            {
                // name of the sheet 
                if (SelectedInquiry== null)
                {
                    MessageBox.Show("Error. Exporting file. No Inquiry was selected. Please select an inquiry and try again");
                    return;
                }
                var workSheet = excel.Workbook.Worksheets.Add($"{SelectedInquiry.Id}");
                //Header
                ExcelHeader(workSheet);

                workSheet.Cells["A4"].Value = "Inquiry Number: ";
                workSheet.Cells["A4"].Style.Font.Bold = true;

                workSheet.Cells["B4:C4"].Merge = true;
                workSheet.Cells["B4"].Value = $"{SelectedInquiry.InquiryNumber}";

                workSheet.Cells["D4"].Value = "DATE: ";
                workSheet.Cells["D4"].Style.Font.Bold = true;

                workSheet.Cells["E4"].Value = $"{SelectedInquiry.DateCreated.ToShortDateString()}";

                //workSheet.Cells["A5"].Value = "To: ";
                //workSheet.Cells["A5"].Style.Font.Bold = true;
                //workSheet.Cells["B5"].Value = $"MR. {SelectedInquiry.Customer.FirstName.ToUpper() } {SelectedInquiry.Customer.LastName.ToUpper()}";
                workSheet.Cells["A5"].Value = "M/S";
                workSheet.Cells["A5"].Style.Font.Bold = true;
                workSheet.Cells["B5"].Value = $"{SelectedInquiry.Ms}";

                workSheet.Cells["A6"].Value = "ATTN: ";
                workSheet.Cells["A6"].Style.Font.Bold = true;
                workSheet.Cells["B6"].Value = $"{SelectedInquiry.Attn}";

                workSheet.Cells["A8"].Value = "S.No";

                workSheet.Cells["B8"].Value = "Part No.";
                workSheet.Cells["C8"].Value = "Description";
                workSheet.Cells["D8"].Value = "Qty";
                
                workSheet.Cells["E8"].Value = "Units";
                workSheet.Cells["F8"].Value = "U.Price";
                workSheet.Cells["G8"].Value = "Total Price";
                workSheet.Cells["A8:G8"].Style.Font.Bold = true;

                workSheet.Cells["A8:G8"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A8:G8"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A8:G8"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A8:G8"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells["A8:G8"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A8:G8"].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                workSheet.Row(8).Style.Font.Color.SetColor(Color.White);


                int i = 10;
                int count = 1;
                foreach (var items in SelectedInquiry.Items)
                {
                    workSheet.Cells[$"A{i}"].Value = $"{count}";
                    workSheet.Cells[$"B{i}"].Value = $"{items.Inventory.PartNumber.ToUpper()}";
                    workSheet.Cells[$"C{i}"].Value = $"{items.Inventory.Description.ToUpper()}";
                    workSheet.Cells[$"D{i}"].Value = $"{items.OfferedQty}";
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
                double total = SelectedInquiry.Total;
                i++;
                //Gross Total
                workSheet.Cells[$"A{i}:F{i}"].Merge = true;
                workSheet.Cells[$"A{i}:F{i}"].Value = "Gross Total";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"G{i}"].Value = $"{SelectedInquiry.Total}";
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
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedInquiry.VatPercent}% Vat";
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                double vatCal = (SelectedInquiry.Vat / 100 * total);
                workSheet.Cells[$"G{i}"].Value = $"{SelectedInquiry.Vat}";
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
                workSheet.Cells[$"A{i}:F{i}"].Value = $"{SelectedInquiry.Discount}% Discount";
                workSheet.Cells[$"A{i}:F{i}"].Style.Font.Bold = true;
                workSheet.Cells[$"A{i}:F{i}"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                double discount = SelectedInquiry.Discount > 0 ? (SelectedInquiry.Discount/ 100 * total) : 0;
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
                double net = Math.Round(SelectedInquiry.NetTotal, 2);
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
            //Image logo = Image.FromFile(@"C:\Users\zobad\Desktop\Hamza\ExcelTest\logo.jpg");
            //ExcelPicture pic = workSheet.Drawings.AddPicture("Logo", logo);
            //pic.SetSize(4);
            //pic.SetPosition(0, 0, 1, 110);
            //// pic.SetPosition(PixelTop, PixelLeft);

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

            
            workSheet.Cells[$"A{ i}:B{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:B{i}"].Value = "Thanks & Regards,";
            i++;
            //Name of the user
            i++;
            //Company Name
            workSheet.Cells[$"A{ i}:B{i}"].Merge = true;
            workSheet.Cells[$"A{ i}:B{i}"].Value = "For Saadia Trading Co.";
        }
        private async Task Upload(IClosable i)
        {
            if (FilePath.IndexOf("inquiry", StringComparison.OrdinalIgnoreCase) >= 0 && !string.IsNullOrWhiteSpace(FilePath))
            {
                BulkInquiry = new ObservableCollection<Inquiry>();
                if (IsIgnoreCheck)
                {
                    
                    await ReadInquiryFileExcel(FilePath);
                    var window = new InquiryImportDisplayView(this);

                    //Instead of the whole of BulkQuotation use SelectedBulkQuotaion
                    if (BulkInquiry == null)
                    {
                        return;
                    }
                    foreach (var inquiry in BulkInquiry)
                    {
                        foreach (var part in inquiry.Items)
                        {
                            part.CalculateTotal();
                        }
                        inquiry.CalculateNetTotal();
                    }
                    SelectedBulkInquiry = BulkInquiry[0];
                    i.Close();
                    window.ShowDialog();

                }
                else if (IsUpdateCheck)
                {
                    await ReadInquiryFileExcel(FilePath);
                    var window = new InquiryImportDisplayView(this);
                    if (BulkInquiry == null)
                    {
                        return;
                    }
                    i.Close();
                    foreach (var inquiry in BulkInquiry)
                    {
                        foreach (var part in inquiry.Items)
                        {
                            part.CalculateTotal();                           
                        }
                        inquiry.CalculateNetTotal();
                    }
                    SelectedBulkInquiry = BulkInquiry[0];
                    window.ShowDialog();

                }

            }
            else
            {
                MessageBox.Show("Error: Invalid file path");
                return;
            }

        }
        private async Task ReadInquiryFileExcel(string path)
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
                        var inquiries = new Inquiry();
                        int tabs = result.Tables.Count;
                        bool itemflag = false;
                        for (int tab = 0; tab < tabs; tab++)
                        {
                            var q = new Inquiry();
                            int rows = result.Tables[tab].Rows.Count;
                            int columns = result.Tables[tab].Columns.Count;

                            for (int row = 7; row < rows; row++)
                            {
                                InquiryItem _item = new InquiryItem();
                                for (int col = 0; col < columns; col++)
                                {
                                    var data = result.Tables[tab];
                                    var current = data.Rows[row][col].ToString();
                                    var next = data.Rows[row][col + 1].ToString();

                                    if (string.IsNullOrEmpty(current))
                                        break;

                                    if (current.Contains("S.No"))
                                    {
                                        itemflag = true;
                                        break;
                                    }
                                    if (current.ToLower().Equals("total"))
                                    {
                                        string total = next;
                                        itemflag = false;
                                        break;
                                        //q.NetTotal = float.Parse(next);
                                    }
                                    else if (current.ToLower().Contains("sub-total"))
                                    {
                                        itemflag = false;
                                        break;
                                    }
                                    else if (current.ToLower().Contains("discount"))
                                    {
                                        double des = 0.0;   
                                        double.TryParse(next,out des);
                                        q.Discount = des;
                                        itemflag = false;
                                        break;
                                    }
                                    
                                    if (itemflag)
                                    {
                                        switch (col)
                                        {
                                            case 1:
                                                _item.Inventory.PartNumber = current.ToString();
                                                break;
                                            case 2:
                                                _item.Inventory.Description = current.ToString();
                                                break;
                                            case 3:
                                                _item.OfferedQty = string.IsNullOrWhiteSpace(current.ToString().Trim()) ? 0 : Int32.Parse(current);
                                                break;
                                            case 4:
                                                //EA
                                                break;
                                            case 5:
                                                _item.OfferedPrice = string.IsNullOrWhiteSpace(current.ToString().Trim()) ? 0.0 : double.Parse(current);
                                                break;
                                            case 6:
                                                _item.Total = string.IsNullOrWhiteSpace(current.ToString().Trim()) ? 0.0:double.Parse(current);
                                                break;

                                            default:
                                                break;
                                        }
                                       
                                    }
                                }
                                if (itemflag && !string.IsNullOrWhiteSpace(_item.Inventory.PartNumber) && !string.IsNullOrWhiteSpace(_item.Inventory.Description) )
                                {
                                    q.Items.Add(_item);
                                }
                            }
                           // inquiries.Items.Add(q);
                            BulkInquiry.Add(new Inquiry(q));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to import file. An error occured. Error details: {ex.Message}");
            }
        }
        private void NextRecord()
        {
            int length = BulkInquiry.Count;
            try
            {
                int index = BulkInquiry.IndexOf(SelectedBulkInquiry);
                SelectedBulkInquiry = BulkInquiry[index + 1];

            }
            catch (Exception ex)
            {
                MessageBox.Show("No More records to display");
            }
        }
        private void PreviousRecord()
        {
            try
            {
                int index = BulkInquiry.IndexOf(SelectedBulkInquiry);
                SelectedBulkInquiry = BulkInquiry[index - 1];

            }
            catch (Exception ex)
            {
                MessageBox.Show("No More records to display");
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
