using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for InquiryImportDisplayView.xaml
    /// </summary>
    public partial class InquiryImportDisplayView : Window,IClosable
    {
        public InquiryImportDisplayView(InquiryViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
