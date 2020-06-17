using System;

namespace SaadiaInventorySystem.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public DateTime DateCreated { get; internal set; }
        public DateTime DateUpdate { get; internal set; }
        public int IsActive { get; internal set; }
    }
}
