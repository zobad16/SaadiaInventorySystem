using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for InquiryImportAddItemView.xaml
    /// </summary>
    public partial class InquiryImportAddItemView : Window, IClosable
    {
        public InquiryImportAddItemView(InquiryViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
