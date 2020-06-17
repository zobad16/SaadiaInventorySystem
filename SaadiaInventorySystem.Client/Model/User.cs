using SaadiaInventorySystem.Client.Util;

namespace SaadiaInventorySystem.Client.Model
{
    public class User : BaseViewModel
    {
        private int id;
        private string userName;
        private string password;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string emailAddress;
        private int isActive;
        private Role role;
        private int roleId;

        public int Id { get => id; set { id = value; RaisePropertyChanged(); } }
        public string UserName { get => userName; set { userName = value; RaisePropertyChanged(); } }
        public string Password { get => password; set { password = value; RaisePropertyChanged(); } }
        public string LastName { get => lastName; set { lastName = value; RaisePropertyChanged(); } }
        public string FirstName { get => firstName; set { firstName = value; RaisePropertyChanged(); } }
        public string PhoneNumber { get => phoneNumber; set { phoneNumber = value; RaisePropertyChanged(); } }
        public string EmailAddress { get => emailAddress; set { emailAddress = value; RaisePropertyChanged(); } }

        public int IsActive { get => isActive; set { isActive = value; RaisePropertyChanged();} }
        public Role Role { get => role; set { role = value; RaisePropertyChanged(); } }
        public int RoleId { get => roleId; set { roleId = value; RaisePropertyChanged(); } }
    }
}
