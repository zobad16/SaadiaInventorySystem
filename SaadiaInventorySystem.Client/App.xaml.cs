using SaadiaInventorySystem.Client.View;
using SaadiaInventorySystem.Client.ViewModel;
using System.Configuration;
using System.Windows;

namespace SaadiaInventorySystem.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppProperties.Url = ConfigurationManager.AppSettings["server"];

            var app = new MainWindow();
            var login = new LoginView();
            //FileBrowseView app = new FileBrowseView();
            
            var datacontext = new MainViewModel() { Active = Visibility.Collapsed};
            var logincontext = new LoginViewModel(datacontext);
            login.DataContext = logincontext;
            app.DataContext = datacontext;
            login.ShowDialog();
            

        }
    }
}
