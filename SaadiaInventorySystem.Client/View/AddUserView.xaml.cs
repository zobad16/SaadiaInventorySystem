using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window, IClosable
    {
        public AddUserView(UserViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
