using LocknCharm.Application.Repositories;
using LocknCharm.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LocknCharm.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
