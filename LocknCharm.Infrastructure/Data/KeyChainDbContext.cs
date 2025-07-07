using LocknCharm.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocknCharm.Infrastructure.Data
{
    public class KeyChainDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public KeyChainDbContext(DbContextOptions<KeyChainDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<ApplicationRole>().ToTable("Roles");
            builder.Entity<ApplicationRoleClaim>().ToTable("RoleClaims");
            builder.Entity<ApplicationUserRoles>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<PreMadeKeychain>().ToTable("PreMadeKeychains");
            builder.Entity<Payment>().ToTable("Payments");

            var adminRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var userRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    CreatedTime = DateTime.UtcNow
                },
                new ApplicationRole
                {
                    Id = userRoleId,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    CreatedTime = DateTime.UtcNow
                }
            );

            var adminUserId = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var normalUserId = Guid.Parse("44444444-4444-4444-4444-444444444444");

            // Seed users
            var adminUser = new ApplicationUser
            {
                Id = adminUserId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedTime = DateTime.UtcNow,
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin@123");

            var normalUser = new ApplicationUser
            {
                Id = normalUserId,
                UserName = "user1",
                FirstName = "Application",
                LastName = "User",
                NormalizedUserName = "USER1",
                Email = "user1@example.com",
                NormalizedEmail = "USER1@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatedTime = DateTime.UtcNow,
            };
            normalUser.PasswordHash = hasher.HashPassword(normalUser, "user@123");

            builder.Entity<ApplicationUser>().HasData(adminUser, normalUser);

            builder.Entity<ApplicationUserRoles>().HasData(
                new ApplicationUserRoles
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId,
                    CreatedTime = DateTime.UtcNow
                },
                new ApplicationUserRoles
                {
                    UserId = normalUserId,
                    RoleId = userRoleId,
                    CreatedTime = DateTime.UtcNow
                }
            );

            // Seed Categories
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e"),
                    Name = "Móc khóa Thú Cưng",
                    ImageUrl = "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807280/7_tirqcu.png",
                    Description = "Bộ sưu tập móc khóa Thú Cưng đáng yêu dành cho những người yêu động vật. Từ những chú chó tinh nghịch đến mèo lười dễ thương, mỗi sản phẩm đều được thiết kế tỉ mỉ, mang lại cảm giác gần gũi và cá tính riêng. Phù hợp để treo trên balo, chìa khóa hoặc làm quà tặng đầy ý nghĩa."
                },
                new Category
                {
                    Id = Guid.Parse("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f"),
                    Name = "Móc khóa Chibi",
                    ImageUrl = "https://res.cloudinary.com/ddewgbug1/image/upload/v1751806861/edef84a7723416a1b2f0428f91b3f944_juhuh6.jpg",
                    Description = "Những chiếc móc khóa Chibi siêu dễ thương với thiết kế nhân vật mini độc đáo, đáng yêu đến từng chi tiết. Phù hợp cho các fan anime, manga hoặc bất kỳ ai yêu thích phong cách dễ thương và nổi bật. Một món phụ kiện nhỏ nhưng đầy cá tính để thể hiện gu thẩm mỹ riêng của bạn."
                },
                new Category
                {
                    Id = Guid.Parse("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f90"),
                    Name = "Móc khóa Couple",
                    ImageUrl = "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807225/11_y71hx0.png",
                    Description = "Móc khóa Couple là biểu tượng ngọt ngào dành cho các cặp đôi. Thiết kế đôi độc đáo, có thể ghép lại với nhau như một mảnh ghép hoàn hảo, thể hiện sự gắn kết và tình yêu bền chặt. Phù hợp làm quà tặng trong các dịp kỷ niệm, Valentine hay đơn giản là để luôn mang theo một phần của người thương bên cạnh."
                },
                new Category
                {
                    Id = Guid.Parse("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f90a1"),
                    Name = "Móc khóa Doanh Nghiệp",
                    ImageUrl = "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807173/MICA-14_trrgit.jpg",
                    Description = "Móc khóa Doanh Nghiệp là lựa chọn quà tặng tinh tế và chuyên nghiệp cho khách hàng, đối tác hoặc sự kiện. Thiết kế tối giản nhưng sang trọng, dễ dàng in logo, slogan hoặc thông tin thương hiệu, giúp tăng độ nhận diện và để lại ấn tượng tốt với người nhận. Phù hợp cho hội nghị, sự kiện quảng bá hoặc tri ân khách hàng."
                },
                new Category
                {
                    Id = Guid.Parse("6f7a8b9c-0d1e-2f3a-4b5c-6d7e8f90a1b2"),
                    Name = "Móc khóa Lời Nhắn",
                    ImageUrl = "https://res.cloudinary.com/ddewgbug1/image/upload/v1751807198/8_kdtfrk.jpg",
                    Description = "Móc khóa Lời Nhắn mang đến một cách đặc biệt để gửi gắm thông điệp yêu thương, động viên hoặc lời chúc đến người thân yêu. Mỗi chiếc móc khóa có thể in, khắc hoặc đính kèm lời nhắn ý nghĩa, tạo nên món quà nhỏ nhưng đong đầy cảm xúc. Phù hợp cho bạn bè, người yêu, gia đình – hoặc chính bản thân bạn như một lời nhắc nhở tích cực mỗi ngày."
                },
                new Category
                {
                    Id = Guid.Parse("7a8b9c0d-1e2f-3a4b-5c6d-7e8f90a1b2c3"),
                    Name = "Móc khóa Chất Việt",
                    ImageUrl = "https://res.cloudinary.com/ddewgbug1/image/upload/v1751806345/17_et0abi.png",
                    Description = "Lấy cảm hứng từ tinh hoa văn hóa Việt Nam, bộ sưu tập Móc khóa Chất Việt tái hiện sống động những biểu tượng quen thuộc như cà phê phin đậm đà, ổ bánh mì giòn rụm hay cuốn gỏi thanh mát. Mỗi chiếc móc khóa là một lát cắt nhỏ của đời sống Việt – bình dị, gần gũi mà đầy tự hào. Phù hợp làm quà tặng độc đáo cho bạn bè quốc tế, người yêu ẩm thực, hoặc đơn giản là để bạn luôn mang theo hương vị quê hương bên mình."
                }
            );
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PreMadeKeychain> PreMadeKeychains { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
