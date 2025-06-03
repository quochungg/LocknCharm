namespace LocknCharm.Application.DTOs
{
    public class PreMadeKeychainDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int Stock { get; set; }

        public string CategoryName { get; set; } = null!;
    }
}
