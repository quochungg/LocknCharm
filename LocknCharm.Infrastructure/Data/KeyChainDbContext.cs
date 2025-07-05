using LocknCharm.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

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
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PreMadeKeychain> PreMadeKeychains { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
    }
}
