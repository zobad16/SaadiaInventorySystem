using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for InvoiceImportAddOrderItemView.xaml
    /// </summary>
    public partial class InvoiceImportAddOrderItemView : Window, IClosable
    {
        public InvoiceImportAddOrderItemView(InvoiceViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
