using LocknCharm.Domain.Common;

namespace LocknCharm.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<PreMadeKeychain>? PreMadeKeychains { get; set; }
    }
}
