using LocknCharm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Reflection;
using LocknCharm.Application.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LocknCharm.API.Middlewares;

namespace LocknCharm.API.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddApiServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddDatabase(configuration);
            services.AddMiddlewares();
            services.ConfigCors();
            services.ConfigSwagger();
            services.ConfigJwt(configuration, environment);
            services.AddJwtAuthenticate();
        }

        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =
                Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING") ??
                configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("Connection string is missing.");

            services.AddDbContext<KeyChainDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }

        public static void AddJwtAuthenticate(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var jwtSettings = serviceProvider.GetRequiredService<JwtSettings>();
            services.AddAuthentication(e =>
            {
                e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(e =>
            {
                e.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey!))

                };
                e.SaveToken = true;
                e.RequireHttpsMetadata = true;
            });
        }

        public static void AddMiddlewares(this IServiceCollection services)
        {
            services.AddExceptionHandler<ExceptionHandlerMiddleware>();
            services.AddProblemDetails();
        }

        public static void ConfigCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("*")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
        }

        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API"

                });

                c.MapType<TimeOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "time",
                    Example = new OpenApiString("00:00:00")
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header sử dụng scheme Bearer.",
                    Type = SecuritySchemeType.Http,
                    Name = "Authorization",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

                c.OrderActionsBy((apiDesc) =>
                {
                    if (apiDesc.HttpMethod == "POST") return "3";
                    if (apiDesc.HttpMethod == "GET") return "1";
                    if (apiDesc.HttpMethod == "PUT") return "2";
                    if (apiDesc.HttpMethod == "DELETE") return "4";
                    return "5";
                });
            });
        }

        public static void ConfigJwt(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddSingleton(_ =>
            {
                JwtSettings jwtSettings;

                if (env.IsProduction())
                {
                    jwtSettings = new JwtSettings
                    {
                        SecretKey = Environment.GetEnvironmentVariable("JWTSETTINGS__SECRETKEY")
                                     ?? throw new InvalidOperationException("Missing env var: JWTSETTINGS__SECRETKEY"),
                        Issuer = Environment.GetEnvironmentVariable("JWTSETTINGS__ISSUER")
                                     ?? throw new InvalidOperationException("Missing env var: JWTSETTINGS__ISSUER"),
                        Audience = Environment.GetEnvironmentVariable("JWTSETTINGS__AUDIENCE")
                                     ?? throw new InvalidOperationException("Missing env var: JWTSETTINGS__AUDIENCE"),
                        AccessTokenExpirationMinutes = int.Parse(Environment.GetEnvironmentVariable("JWTSETTINGS__ACCESSTOKENEXPIRATIONMINUTES") ?? "15"),
                        RefreshTokenExpirationDays = int.Parse(Environment.GetEnvironmentVariable("JWTSETTINGS__REFRESHTOKENEXPIRATIONDAYS") ?? "7")
                    };
                }
                else
                {
                    jwtSettings = new JwtSettings
                    {
                        SecretKey = configuration["JwtSettings:SecretKey"],
                        Issuer = configuration["JwtSettings:Issuer"],
                        Audience = configuration["JwtSettings:Audience"],
                        AccessTokenExpirationMinutes = configuration.GetValue<int>("JwtSettings:AccessTokenExpirationMinutes"),
                        RefreshTokenExpirationDays = configuration.GetValue<int>("JwtSettings:RefreshTokenExpirationDays")
                    };
                }

                jwtSettings.IsValid();
                return jwtSettings;
            });
        }


    }
}
