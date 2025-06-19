namespace LocknCharm.Application.DTOs
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}
