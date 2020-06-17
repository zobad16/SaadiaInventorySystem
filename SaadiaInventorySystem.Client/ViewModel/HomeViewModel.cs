using SaadiaInventorySystem.Client.Util;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client.ViewModel
{
    public class HomeViewModel : BaseViewModel, IViewModel
    {
        private string _name;

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }
        public HomeViewModel()
        {
            Name = "Home";
        }

        public Task GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}