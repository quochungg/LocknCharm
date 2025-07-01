namespace LocknCharm.Application.DTOs
{
    public class CategoryDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; } = null;
    }
}
