namespace LocknCharm.Application.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
