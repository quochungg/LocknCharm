using LocknCharm.Domain.Enums;

namespace LocknCharm.Domain.Entities
{
    public class PreMadeKeychain : Product
    {
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public PreMadeKeychain()
        {
            Type = ProductType.PreMadeKeychain;
        }
    }

}
