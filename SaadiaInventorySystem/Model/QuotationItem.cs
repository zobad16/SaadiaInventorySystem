namespace SaadiaInventorySystem.Model
{
    public class QuotationItem
    {
        public int Id { get; set; }
        public Part Part { get; set; }
        public int Qty { get; set; }
        public Quotation Quotation { get; set; }
    }
}
