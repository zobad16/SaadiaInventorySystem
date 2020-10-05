using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.ViewModel;
using System.Windows;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for AddInquiryView.xaml
    /// </summary>
    public partial class AddInquiryView : Window,IClosable
    {
        public AddInquiryView(InquiryViewModel vm)
        {
            this.DataContext = vm;
            InitializeComponent();
        }
    }
}
