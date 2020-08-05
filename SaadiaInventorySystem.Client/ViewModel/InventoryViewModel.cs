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
            DisableCommand = new RelayCommand(i => DisableAsync(), (a) => SelectedInventory != null);
            DeleteCommand = new RelayCommand(i => DeleteInventory(), (a) => SelectedInventory != null);
            ActivateCommand = new RelayCommand(i => ActivateAsync(), (a )=> SelectedInventory !=null );
            UploadCommand = new RelayCommand<IClosable>(i => Upload(i), i => true);
            ImportCommand = new RelayCommand(i => Import(), i => true);
            NewInventory = new Inventory() { IsActive = 1};
            DuplicateCommand = new RelayCommand(i => SetDuplicateSet(i), i => true);
            IsIgnoreCheck = true;
            IsEdit = false;
            IsAdmin = false;
            Active = 0;
        }

        

        private ICommand _addCommand;
        private string _name;
        private string _duplicateState;
        private string _filePath;
        private bool _isUpdateCheck;
        private bool _isIgnoreCheck;
        private ObservableCollection<Inventory> _inventories;
        private Inventory _selectedInventory;
        private Inventory _newInventory;
        private ObservableCollection<OldPart> _oldParts;
        private readonly InventoryService service;
        private ICommand _addWindowCommand;
        private ICommand _editWindowCommand;
        private RelayCommand<IClosable> _saveCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand _importCommand;
        private RelayCommand<IClosable> _uploadCommand;
        private RelayCommand<IClosable> _cancelCloseCommand;
        private RelayCommand _disableCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _activateCommand;
        private RelayCommand _duplicateCommand;
        private bool isEdit;

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public string DuplicateState { get => _duplicateState; set { _duplicateState = value; RaisePropertyChanged(); } }
        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }
        public bool IsUpdateCheck { get => _isUpdateCheck; set { _isUpdateCheck = value;RaisePropertyChanged(); } }
        public bool IsIgnoreCheck { get => _isIgnoreCheck; set { _isIgnoreCheck = value;RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> Inventories { get => _inventories; set { _inventories = value; RaisePropertyChanged(); } }
        public Inventory SelectedInventory { get => _selectedInventory; set { _selectedInventory = value; RaisePropertyChanged(); } }
        public Inventory NewInventory { get => _newInventory; set { _newInventory = value; RaisePropertyChanged(); } }
        public ObservableCollection<OldPart> OldParts { get => _oldParts; set { _oldParts = value; RaisePropertyChanged(); } }

        #region Commands
        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand EditWindowCommand { get => _editWindowCommand; set { _editWindowCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ImportCommand { get => _importCommand; set { _importCommand = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> UploadCommand { get => _uploadCommand; set { _uploadCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DisableCommand { get => _disableCommand; set { _disableCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DeleteCommand { get => _deleteCommand; set { _deleteCommand = value; RaisePropertyChanged(); } }
        public RelayCommand ActivateCommand { get => _activateCommand; set { _activateCommand = value; RaisePropertyChanged(); } }
        public RelayCommand DuplicateCommand { get => _duplicateCommand; set { _duplicateCommand = value; RaisePropertyChanged(); } }

        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }
        public bool IsAdmin { get => isAdmin; set { isAdmin = value; RaisePropertyChanged(); } }
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
        private void SetDuplicateSet(object param)
        {
            DuplicateState = (string)param;
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

        public bool CanAdd()
        {
            return true;
        }
        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }

        private int active;
        private bool isAdmin;

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
        public async void ActivateAsyncCommand()
        {
             await service.CallActivateService(SelectedInventory.Id);
        }
        public async void DeactivateAsyncCommand()
        {
             await service.CallDeactivateService(SelectedInventory.Id);
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
        private async Task Upload(IClosable i)
        {
            if (IsUpdateCheck) {await ReadFileExcel(FilePath); }
            else if (IsIgnoreCheck) {await ReadFileExcel(FilePath); }
            i.Close();
        }
        private void Import()
        {
            FilePath = "";
            DuplicateState = "";
            var window = new ImportFileView();
            window.DataContext = this;
            window.ShowDialog();

        }
        private async Task ReadFileExcel(string path)
        {
            if (path.IndexOf("Inventory", StringComparison.OrdinalIgnoreCase) >= 0)
            {

                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        var parts = new List<Inventory>();
                        var updateparts = new List<Inventory>();
                        var addparts = new List<Inventory>();
                        int tabs = result.Tables.Count;

                        for (int tab = 0; tab < tabs; tab++)
                        {

                            int rows = result.Tables[tab].Rows.Count;
                            int columns = result.Tables[tab].Columns.Count;
                            var data = result.Tables[tab];
                            for (int row = 1; row < rows; row++)
                            {
                                var q = new Inventory();
                                if (!String.IsNullOrEmpty(data.Rows[row][1].ToString()))
                                {
                                    q.PartNumber = data.Rows[row][1].ToString();
                                }
                                if (!String.IsNullOrEmpty(data.Rows[row][2].ToString()))
                                {
                                    q.Description = data.Rows[row][2].ToString();
                                }
                                if (!String.IsNullOrEmpty(data.Rows[row][3].ToString()))
                                {
                                    q.Location = data.Rows[row][3].ToString();
                                }
                                if (!String.IsNullOrEmpty(data.Rows[row][4].ToString()))
                                {
                                    q.UnitPrice = Decimal.Parse(data.Rows[row][4].ToString());
                                }
                                if (!String.IsNullOrEmpty(data.Rows[row][5].ToString()))
                                {
                                    q.AvailableQty = Int32.Parse(data.Rows[row][5].ToString());
                                }
                                if (!String.IsNullOrEmpty(data.Rows[row][6].ToString()))
                                {
                                    q.Rem = data.Rows[row][6].ToString();
                                }
                                if (!String.IsNullOrEmpty(data.Rows[row][7].ToString()))
                                {
                                    q.OldPart = new OldPart();
                                    q.OldPart.PartNumber = data.Rows[row][7].ToString();
                                }
                                parts.Add(q);
                            }

                        }
                        parts = DuplicateChecks(parts);

                        foreach (var item in parts)
                        {
                            if (item.Id > 0)
                            {
                                updateparts.Add(item);
                            }
                            else if (item.Id == 0)
                            {
                                addparts.Add(item);
                            }
                        }

                        if (addparts.Count > 0)
                        {
                            await service.CallBulkInsert(addparts);
                            MessageBox.Show("Bulk Insert Success");
                        }
                        else if (updateparts.Count > 0)
                        {
                            await service.CallBulkUpdate(updateparts);
                            MessageBox.Show("Bulk Insert Success. Duplicate Records Updated");
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
                MessageBox.Show("Error reading file: Make sure the file contains Inventory");
            }

        }
        private List<Inventory> DuplicateChecks(List<Inventory> parts)
        {
            //If Records missing Customer
            //Skip Them, Count the number of records
            //List Reasons
            var PartsList = Inventories;
            var list = new List<Inventory>();
            foreach (var q in parts)
            {
                // if quotation ! found
                if (q != null)
                {
                    var _parts = PartsList.Where(i => (q.PartNumber == i.PartNumber) && (q.Description == i.Description)).FirstOrDefault();
                    if (_parts != null)
                    {
                        if (IsIgnoreCheck) 
                        {
                            continue;
                        }
                        else if (IsUpdateCheck) 
                        {
                            q.Id = _parts.Id;
                        }
                    }
                    
                    list.Add(q);
                }
            }

            return list;
        }


        public async Task GetAll()
        {
            try
            {
                if (AppProperties.RoleName == AppProperties.ROLE_ADMIN)
                {
                    Inventories = new ObservableCollection<Inventory>(await service.CallAdminGetAllService());
                    IsAdmin = true;
                }
                if (AppProperties.RoleName == AppProperties.ROLE_USER)
                {
                    Inventories = new ObservableCollection<Inventory>(await service.CallGetAllService());
                    isAdmin = false;
                }
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
        public async void DeleteInventory()
        {
            if (await DeleteAsync())
            {
                MessageBox.Show("Inventory Deleted Successfully");
                await GetAll();
            }
            else 
            {
                MessageBox.Show("Error Deleting Inventory");
                await GetAll();
            }
        }
        public async Task<bool> DeleteAsync()
        {
            try
            {
                if (CurrentUserRole(AppProperties.ROLE_ADMIN))
                {
                    return (await service.CallAdminDeleteService(SelectedInventory.Id));
                }
                else if (CurrentUserRole(AppProperties.ROLE_USER)) 
                {
                    return (await service.CallDeleteService(SelectedInventory.Id));
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occured: {ex.Message}");
                return false;
            }
        }
        private async void DisableAsync()
        {
            if (await service.CallDeleteService(SelectedInventory.Id))
            {
                MessageBox.Show("User Disabled");
                await GetAll();
            }
        }
        private async void ActivateAsync()
        {
            if (await service.CallActivateService(SelectedInventory.Id))
            {
                MessageBox.Show("User Activated");
                await GetAll();
            }
        }


        #endregion
        bool CurrentUserRole(string role)
        {
            return AppProperties.RoleName == role;
        }
    }
    
}