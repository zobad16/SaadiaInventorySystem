using SaadiaInventorySystem.Client.Util;
using SaadiaInventorySystem.Client.View;
using System.Windows.Input;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class InventoryViewModel : BaseViewModel
    {
        private ICommand _addCommand;
        private string _name;
        private string _filePath;

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public string FilePath { get => _filePath; set { _filePath = value; RaisePropertyChanged(); } }

        public ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        p => Add(),
                        p => CanAdd());
                }

                return _addCommand;
            }
        }

        public bool CanAdd()
        {
            return true;
        }

        public InventoryViewModel()
        {
            Name = "Inventory";
            FilePath = "";
        }
        public void Add()
        {
            AddInventoryView addInventory = new AddInventoryView();
            addInventory.ShowDialog();
            //Open Add Inventory Window
        }
    }
}