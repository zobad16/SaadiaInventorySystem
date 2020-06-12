using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class Role : BaseViewModel
    {
        private string roleName;
        private int id;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public string RoleName { get => roleName; set { roleName = value; RaisePropertyChanged(); } }
    }
}