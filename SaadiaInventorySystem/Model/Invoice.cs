namespace SaadiaInventorySystem.Model
{
    public class Invoice
    {
        public int Id { get; set; }
        public Order Order { get; set; }
    }
}
