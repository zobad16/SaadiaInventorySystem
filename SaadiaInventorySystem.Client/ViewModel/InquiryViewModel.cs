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
        private readonly InquiryService service;
        private ICommand _addWindowCommand;
        private ICommand _openAddPartsWindowCommand;
        private RelayCommand<IClosable> _cancelCommand;
        private RelayCommand<IClosable> _saveCommand;
        private bool isEdit;

        public InquiryViewModel()
        {
            AddWindowCommand = new RelayCommand(i => OpenAddWindow(), i => true);          
            CancelCommand = new RelayCommand<IClosable>(i => Cancel(i), i => true);
            _name = "Inquiry";

            OpenAddPartsWindowCommand = new RelayCommand(i => OpenAddPartsWindow(), i => true);
            SaveCommand = new RelayCommand<IClosable>(i => Save(i), i => true);
            service = new InquiryService();

        }

       
        public string Name { get => _name; private set { _name = value; RaisePropertyChanged(); } }

        public int Active { get => active; set { active = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> CancelCommand { get => _cancelCommand; set { _cancelCommand = value; RaisePropertyChanged(); } }
        
        public Inquiry NewInquiry { get => _newInquiry;  set { _newInquiry = value; RaisePropertyChanged(); } }
        public Inquiry SelectedInquiry { get => _selectedInquiry;  set { _selectedInquiry = value; RaisePropertyChanged(); } }
        public RelayCommand<IClosable> SaveCommand { get => _saveCommand; set { _saveCommand = value; RaisePropertyChanged(); } }

        public ObservableCollection<Inquiry> Inquirys { get => inquirys; set { inquirys = value; RaisePropertyChanged(); } }
        public ObservableCollection<Inventory> PartsList { get => _partsList; set { _partsList = value; RaisePropertyChanged(); } }
        public InquiryItem SelectedItem { get => _selectedItem; set { _selectedItem = value; RaisePropertyChanged(); } }

        public ICommand AddWindowCommand { get => _addWindowCommand; set { _addWindowCommand = value; RaisePropertyChanged(); } }
        public ICommand OpenAddPartsWindowCommand { get => _openAddPartsWindowCommand; set { _openAddPartsWindowCommand = value; RaisePropertyChanged(); } }
        public bool IsEdit { get => isEdit; set { isEdit = value; RaisePropertyChanged(); } }
        public bool Activate()
        {
            Active = 1;
            return Active == 1;
        }

        public Task<bool> AddAsync()
        {
            throw new NotImplementedException();
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
            await GetAll();
        }
        private void OpenAddWindow()
        {
            NewInquiry = new Inquiry();
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

        public bool Deactivate()
        {
            Active = 0;
            return Active == 0;
        }

        public Task<bool> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task Get()
        {
            try
            {
                await service.CallGetService(SelectedInquiry.Id);
                //SelectedQuotation.CalculateNetTotal();
                //foreach (var item in SelectedQuotation.Order.OrderItems)
                //{
                //    item.VatPercent = SelectedQuotation.VAT;
                //    item.CalculateVAT();
                //}
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
                    //foreach (var i in Inquirys)
                    //{

                    //    foreach (var item in i.Items)
                    //    {
                    //        item..VatPercent = item.VAT;
                    //        item.CalculateVAT();
                    //    }
                    //    item.CalculateNetTotal();
                    //    foreach (var _item in item.Order.OrderItems)
                    //    {
                    //        _item.VatPercent = item.VAT;
                    //        _item.CalculateVAT();
                    //    }
                    //}
                    //Message = Inquirys[0].Message;
                    //Note = Inquirys[0].Note;
                    //IsAdmin = true;
                }
                else if (CurrentUserRole(AppProperties.ROLE_USER))
                {

                    Inquirys = new ObservableCollection<Inquiry>(await service.CallGetAllService());
                    //foreach (var item in Inquirys)
                    //{
                    //    item.CalculateNetTotal();
                    //    foreach (var _item in item.Order.OrderItems)
                    //    {
                    //        _item.VatPercent = item.VAT;
                    //        _item.CalculateVAT();
                    //    }
                    //}
                    //Message = Inquirys[0].Message;
                    //Note = Inquirys[0].Note;
                    //IsAdmin = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching Inquiry: {ex.Message}");

            }
        }

        public Task<bool> UpdateAsync()
        {
            throw new NotImplementedException();
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
