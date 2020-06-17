namespace SaadiaInventorySystem.Model
{
    public class OldPart
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Rem { get; set; }
        public string PartNumber { get; internal set; }
    }
}
