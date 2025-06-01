using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class PreMadeKeychain : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; } = null!;

    }

}
