using SaadiaInventorySystem.Client.Util;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace SaadiaInventorySystem.Client.View
{
    /// <summary>
    /// Interaction logic for ImportFileView.xaml
    /// </summary>
    public partial class ImportFileView :  Window, IClosable
    {
        public ImportFileView()
        {
            InitializeComponent();
        }

        private void FileExplorer_Click(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)FindName("FilePath_TB");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files| *.xlsx; *.xls; *.pdf";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = (string)openFileDialog.FileName;

            }
        }
    }
}
