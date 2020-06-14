using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System;
using System.Collections.Generic;
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
        
        private BaseViewModel _currentPageViewModel;
        private List<BaseViewModel> _pageViewModels;
        
        private Visibility _windowActive;
        private string _filePath;


        public MainViewModel()
        {
            FilePath = "";
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new QuotationViewModel());
            PageViewModels.Add(new InvoiceViewModel());
            PageViewModels.Add(new InventoryViewModel());           
            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
            _windowActive = Visibility.Collapsed;
        }
        public MainViewModel(Visibility active)
        {
            FilePath = "";
            PageViewModels.Add(new HomeViewModel());
            PageViewModels.Add(new QuotationViewModel());
            PageViewModels.Add(new InvoiceViewModel());
            PageViewModels.Add(new InventoryViewModel());
            Active = _windowActive;
            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties / Commands

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((BaseViewModel)p),
                        p => p is BaseViewModel);
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

        public List<BaseViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<BaseViewModel>();
                }

                return _pageViewModels;
            }
        }

        public BaseViewModel CurrentPageViewModel
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

        private void ChangeViewModel(BaseViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
            
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
