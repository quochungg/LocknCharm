using LocknCharm.Application.Common;
using LocknCharm.Application.Interfaces;
using LocknCharm.Application.Services;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Net.payOS;
using System.Reflection;

namespace LocknCharm.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMapping();
            services.AddServices();
            services.AddPayOs();
        }

        private static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPreMadeKeychainService, PreMadeKeychainService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRoleClaimService, RoleClaimService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDeliveryDetailService, DeliveryDetailService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }

        private static void AddPayOs(this IServiceCollection services)
        {
            services.AddSingleton<PayOS>(sp =>
            {
                var env = sp.GetRequiredService<IHostEnvironment>();
                var config = sp.GetRequiredService<IConfiguration>();

                string clientId, apiKey, checksum;

                if (env.IsProduction())
                {
                    clientId = Environment.GetEnvironmentVariable("PAYOS_CLIENT_ID")
                        ?? throw new InvalidOperationException("PAYOS_CLIENT_ID is not set.");

                    apiKey = Environment.GetEnvironmentVariable("PAYOS_API_KEY")
                        ?? throw new InvalidOperationException("PAYOS_API_KEY is not set.");

                    checksum = Environment.GetEnvironmentVariable("PAYOS_CHECKSUM")
                        ?? throw new InvalidOperationException("PAYOS_CHECKSUM is not set.");
                }
                else
                {
                    var options = config.GetSection("PayOS").Get<PayOSOptions>()
                        ?? throw new InvalidOperationException("PayOS config is missing in appsettings.");

                    clientId = options.ClientId;
                    apiKey = options.ApiKey;
                    checksum = options.ChecksumKey;
                }

                return new PayOS(clientId, apiKey, checksum);
            });

        }
    }
}
