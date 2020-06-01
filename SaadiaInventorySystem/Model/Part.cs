namespace SaadiaInventorySystem.Model
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableQty { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string Rem { get; set; }
        public OldPart OldPart { get; set; }
    }
}
