using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for QuotationImportDisplayView.xaml
    /// </summary>
    public partial class QuotationImportDisplayView : Window, IClosable
    {
        public QuotationImportDisplayView(QuotationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
