﻿namespace SaadiaInventorySystem.Model
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Inventory Part { get; set; }
        public int Qty { get; set; }
        public Order Order { get; set; }
    }
}
