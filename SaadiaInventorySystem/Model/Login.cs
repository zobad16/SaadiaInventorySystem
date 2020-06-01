﻿namespace SaadiaInventorySystem.Model
{
    public class Login
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Customer Customer { get; set; }
    }
}
