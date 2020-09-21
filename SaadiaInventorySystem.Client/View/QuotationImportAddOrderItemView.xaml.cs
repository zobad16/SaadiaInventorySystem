using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for QuotationImportAddOrderItemView.xaml
    /// </summary>
    public partial class QuotationImportAddOrderItemView : Window, IClosable
    {
        public QuotationImportAddOrderItemView(QuotationViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
