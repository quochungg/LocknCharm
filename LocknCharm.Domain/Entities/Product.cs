using LocknCharm.Domain.Enums;

namespace LocknCharm.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = new Guid();
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!; //khi user tạo móc khóa custom, sẽ upload ảnh lên firebase storage và lấy link ảnh để lưu vào đây
        public int Stock { get; set; }
        public ProductType? Type { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
