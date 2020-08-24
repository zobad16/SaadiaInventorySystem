using SaadiaInventorySystem.Client.Util;
using System.Windows;
using System.Windows.Controls;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window, IClosable
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void tb_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; }
        }
    }
}
