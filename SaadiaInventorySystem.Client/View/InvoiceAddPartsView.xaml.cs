using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for InvoiceAddPartsView.xaml
    /// </summary>
    public partial class InvoiceAddPartsView : Window, IClosable
    {
        public InvoiceAddPartsView(InvoiceViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
