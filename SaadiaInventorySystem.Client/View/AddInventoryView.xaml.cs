using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for AddInventoryView.xaml
    /// </summary>
    public partial class AddInventoryView : Window, IClosable
    {
        public AddInventoryView(InventoryViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
