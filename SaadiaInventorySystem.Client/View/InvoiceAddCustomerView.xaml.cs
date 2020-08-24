using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for InvoiceAddCustomerView.xaml
    /// </summary>
    public partial class InvoiceAddCustomerView : Window, IClosable
    {
        public InvoiceAddCustomerView(InvoiceViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
