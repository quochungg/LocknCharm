using LocknCharm.API.ExceptionHandlers;
using LocknCharm.Application;
using LocknCharm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LocknCharm.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddExceptionHandler<ExceptionHandlerMiddleware>();
            services.AddApplication();
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KeyChainDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultSQLConnection"));
            });
        }
    }
}
