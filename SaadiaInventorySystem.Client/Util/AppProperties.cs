using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaadiaInventorySystem.Client
{
    public class AppProperties
    {
        public static string UserName { get; set; }
        public static string Url{ get; set; }
        public static string SecurityTokenName = "API_Token";
        public static string SecutiyTokenValue { get; set; }
        public static string RoleName { get; set; }

        public static List<KeyValuePair<String, String>> UserRoles = new List<KeyValuePair<String, String>>()
        {
            new KeyValuePair<String,String>("0","User"),
            new KeyValuePair<String,String>("1","Admin"),
        };
        public static string ROLE_ADMIN = "Admin";
        public static string ROLE_USER = "User";
    }
}
