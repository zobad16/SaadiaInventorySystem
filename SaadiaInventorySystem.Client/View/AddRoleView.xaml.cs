using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for AddRoleView.xaml
    /// </summary>
    public partial class AddRoleView : Window, IClosable
    {
        public AddRoleView(RoleViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
