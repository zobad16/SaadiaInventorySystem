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
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
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
                            item.Inquiry.Id = _inquiries.Id;
                        }
                    }
                    //Check order Parts
                    foreach (var part in q.Items)
                    {
                        part.IsActive = 1;
                        part.Inventory.IsActive = 1;
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
        private async void OpenImportEditWindow()
        {
            var _service = new InventoryService();
            PartsList = new ObservableCollection<Inventory>(await _service.CallGetAllService());
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
