using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocknCharm.Infrastructure.Data
{
    public class KeyChainDbContextFactory : IDesignTimeDbContextFactory<KeyChainDbContext>
    {
        public KeyChainDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "LocknCharm.API"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .Build();


            string? connectionString = configuration.GetConnectionString("LocalConnection");

            var builder = new DbContextOptionsBuilder<KeyChainDbContext>();
            builder.UseSqlServer(connectionString);

            return new KeyChainDbContext(builder.Options);
        }
    }
}