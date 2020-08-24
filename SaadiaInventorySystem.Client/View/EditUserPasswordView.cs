using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for EditUserPassword.xaml
    /// </summary>
    public partial class EditUserPasswordView : Window, IClosable
    {
        public EditUserPasswordView(UserViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).NewUser.Password = ((PasswordBox)sender).Password; }
        }

        private void PasswordBox_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).ConfirmPassword = ((PasswordBox)sender).Password; }
        }
    }
}
