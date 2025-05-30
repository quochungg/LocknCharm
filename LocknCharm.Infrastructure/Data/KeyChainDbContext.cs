using LocknCharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocknCharm.Infrastructure.Data
{
    public class KeyChainDbContext : DbContext
    {
        public KeyChainDbContext(DbContextOptions<KeyChainDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<PreMadeKeychain> PreMadeKeychains { get; set; }
    }
}
