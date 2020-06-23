using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ICommand _changePageCommand;
        private RelayCommand<IClosable> _logoutCommand;
        private ICommand _exitCommand;
        
        private IViewModel _currentPageViewModel;
        private ObservableCollection<IViewModel> _pageViewModels;
        
        private Visibility _windowActive;
        private string _filePath;


        public MainViewModel()
        {
            FilePath = "";
            _windowActive = Visibility.Collapsed;
        }
        public MainViewModel(Visibility active)
        {
            FilePath = "";
            Active = _windowActive;
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((IViewModel)p),
                        p => p is IViewModel);
                }

                return _changePageCommand;
            }
        }
        public RelayCommand<IClosable> LogoutCommand
        {
            get
            {
                if (_logoutCommand == null)
                {
                    _logoutCommand = new RelayCommand<IClosable>(
                        p => OnLogout(p));
                }

                return _logoutCommand;
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                if (_exitCommand == null)
                {
                    _exitCommand = new RelayCommand(
                        p => OnExit());
                }

                return _exitCommand;
            }
        }

        public ObservableCollection<IViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new ObservableCollection<IViewModel>();
                }

                return _pageViewModels;
            }
            private set { _pageViewModels = value; RaisePropertyChanged(); }
        }

        public IViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    RaisePropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged("FilePath"); } }

        public Visibility Active { get => _windowActive; set { _windowActive = value; RaisePropertyChanged("Active");} }



        #endregion
        #region Methods
        public async void LoadViews()
        {
            PageViewModels = null;
            foreach (var vm in PageViewModels)
            {
                string name = vm.VMName();
                if (name == "Customer") { PageViewModels.Remove(vm); }
                if (name == "User") { PageViewModels.Remove(vm); }
                if (name == "Inventory") { PageViewModels.Remove(vm); }
                if (name == "Role") { PageViewModels.Remove(vm); }
                if (name == "Quotation") { PageViewModels.Remove(vm); }
                if (name == "Invoice") { PageViewModels.Remove(vm); }
            }
            
            if (AppProperties.RoleName == AppProperties.ROLE_ADMIN)
            {
                FilePath = "";
                PageViewModels.Add(new UserViewModel());
                PageViewModels.Add(new CustomerViewModel());
                PageViewModels.Add(new InventoryViewModel());
                PageViewModels.Add(new RoleViewModel());
                PageViewModels.Add(new QuotationViewModel());
                PageViewModels.Add(new InvoiceViewModel());
                // Set starting page
                CurrentPageViewModel = PageViewModels[1];
                CurrentPageViewModel.Activate();
            }
            else if (AppProperties.RoleName == AppProperties.ROLE_USER)
            {
                FilePath = "";
                PageViewModels.Add(new CustomerViewModel());
                PageViewModels.Add(new InventoryViewModel());
                PageViewModels.Add(new QuotationViewModel());
                PageViewModels.Add(new InvoiceViewModel());
                // Set starting page
                CurrentPageViewModel = PageViewModels[0];
                CurrentPageViewModel.Activate();
            }
            else 
            {
                MessageBox.Show("Error. Invalid Client state.\nExiting");
                OnExit();
            }
            await CurrentPageViewModel.GetAll();
        }
        private void ChangeViewModel(IViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            CurrentPageViewModel.Deactivate();
            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);

            CurrentPageViewModel.Activate();

            CurrentPageViewModel.GetAll();           
        }
        private void OnLogout(IClosable window)
        {
            try
            {
                bool login = true;
                if (login == true)
                {
                    if (window != null)
                    {
                        LoginViewModel vm = new LoginViewModel(this);
                        LoginView loginView = new LoginView() { DataContext = vm};
                        Active = Visibility.Hidden;
                        loginView.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }

        }
        private void OnExit()
        {
            System.Windows.Application.Current.Shutdown();
        }
        

        #endregion

    }
}
