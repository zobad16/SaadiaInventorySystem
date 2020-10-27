using Newtonsoft.Json;
using SaadiaInventorySystem.Client.Backend;
using SaadiaInventorySystem.Client.Model;
using SaadiaInventorySystem.Client.Services;
using SaadiaInventorySystem.Client.Util;
using System;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;
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
        private readonly UserService userservice;
       
        public LoginViewModel(MainViewModel vm)
        {
            _mainVM = vm;
            service = new LoginService();
            userservice = new UserService();
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

        public MainViewModel MainVM { get => _mainVM; private set {_mainVM = value; } }

        public string UserName { get => _userName; set { _userName = value; RaisePropertyChanged("UserName"); } }
        public string Password { private get => _password; set { _password = value; RaisePropertyChanged("Password"); } }

        #endregion

        private async void Login(IClosable window)
        {
            try
            {
                bool login = true;
                if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password))
                {
                    string token = await service.CallLoginService(new Model.User() { UserName = this.UserName, Password = this.Password });
                    if (login == true && !string.IsNullOrEmpty(token))
                    {
                        token = JsonConvert.DeserializeObject<string>(token);
                        //Initialize Client
                        User user = await userservice.CallGetServiceByUserName(this.UserName);
                        if (user != null)
                        {
                            AppProperties.UserName = user.UserName;
                            AppProperties.RoleName = user.Role.RoleName;
                            AppProperties.SecutiyTokenValue = token;
                        }
                        if (window != null)
                        {
                            MainVM.Active = Visibility.Visible;
                            MainVM.LoadViews();
                            window.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetFullMessage());
            }


        }


    }
}
