using LocknCharm.Domain.Interfaces.Repositories;
using LocknCharm.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LocknCharm.Infrastructure
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
