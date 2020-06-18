using SaadiaInventorySystem.Model;

namespace SaadiaInventorySystem.Session
{
    public class SessionData
    {
        public SessionData()
        {

        }
        public User User { get; set; }
        public string Token { get; set; }
    }
}
