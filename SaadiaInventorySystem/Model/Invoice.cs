namespace SaadiaInventorySystem.Model
{
    public class Invoice
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
