using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Windows;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        private RelayCommand<IClosable> _loginCommand;
        private MainViewModel _mainVM;

        private string _userName;
        private string _password;
        private readonly LoginService service;
       
        public LoginViewModel(MainViewModel vm)
        {
            _mainVM = vm;
            UserName = "zobad16";
            Password = "12345";
            service = new LoginService();
        }
        #region Properties / Commands
        public RelayCommand<IClosable> LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand<IClosable>(
                        p => Login(p));
                }

                return _loginCommand;
            }
        }

        public MainViewModel MainVM { get => _mainVM; private set {; } }

        public string UserName { get => _userName; set { _userName = value; RaisePropertyChanged("UserName"); } }
        public string Password { get => _password; set { _password = value; RaisePropertyChanged("Password"); } }

        #endregion

        private async void Login(IClosable window)
        {
            try
            {
                bool login = true;
                await service.CallLoginService(new Model.User() { UserName = this.UserName, Password = this.Password });
                if (login == true)
                {
                    if (window != null)
                    {
                        MainVM.Active = Visibility.Visible;
                        window.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }


        }


    }
}
