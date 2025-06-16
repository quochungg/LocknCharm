using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocknCharm.Infrastructure.Data
{
    public class KeyChainDbContextFactory : IDesignTimeDbContextFactory<KeyChainDbContext>
    {
        public KeyChainDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "LocknCharm.API"))
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                    .Build();

                connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string not found in environment or appsettings.");

            var builder = new DbContextOptionsBuilder<KeyChainDbContext>();
            builder.UseNpgsql(connectionString);

            return new KeyChainDbContext(builder.Options);
        }
    }
}
