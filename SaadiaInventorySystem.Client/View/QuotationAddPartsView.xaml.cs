using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for QuotationAddPartsView.xaml
    /// </summary>
    public partial class QuotationAddPartsView : Window, IClosable
    {
        public QuotationAddPartsView(QuotationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
