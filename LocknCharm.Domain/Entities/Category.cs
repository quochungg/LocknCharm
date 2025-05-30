namespace LocknCharm.Domain.Entities
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<PreMadeKeychain>? PreMadeKeychains { get; set; }
    }
}
