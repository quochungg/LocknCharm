using LocknCharm.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocknCharm.Domain.Entities
{
    public class PreMadeKeychain : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

    }

}
