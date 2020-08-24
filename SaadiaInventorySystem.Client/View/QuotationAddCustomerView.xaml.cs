using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for QuotationAddCustomerView.xaml
    /// </summary>
    public partial class QuotationAddCustomerView : Window, IClosable
    {
        public QuotationAddCustomerView(QuotationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
        public QuotationAddCustomerView(InvoiceViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
