using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Services;
using LocknCharm.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LocknCharm.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMapping();
            services.AddServices();
        }

        private static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPreMadeKeychainService, PreMadeKeychainService>();
        }
    }
}
