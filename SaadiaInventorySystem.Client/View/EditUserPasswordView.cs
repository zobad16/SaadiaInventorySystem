using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

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
    }
}
