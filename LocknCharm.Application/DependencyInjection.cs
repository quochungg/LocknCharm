using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LocknCharm.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMapping();
        }

        private static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddServices(this IServiceCollection services)
        {

        }
    }
}
