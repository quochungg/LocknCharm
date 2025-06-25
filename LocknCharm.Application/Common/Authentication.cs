using AutoMapper;
using LocknCharm.Application.DTOs.ApplicationUser;
using LocknCharm.Application.DTOs.Auth;
using LocknCharm.Application.Repositories;
using LocknCharm.Domain.Entities;
using LocknCharm.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace LocknCharm.Application.Common
{
    public class Authentication
    {
        private static readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ApplicationUser, ApplicationUserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));
        }).CreateMapper();
        public static TokenResponse CreateToken(ApplicationUser? user, string role, JwtSettings jwtSettings, bool isRefresh = false)
        {
            // tạo ra claims 
            DateTime now = DateTime.UtcNow;

            List<Claim> claims =
            [
                new Claim("id", user!.Id.ToString()),
            ];

            claims.Add(new Claim("role", role));

            //đăng kí khóa bảo mật
            SymmetricSecurityKey? key = new(Encoding.UTF8.GetBytes(jwtSettings.SecretKey ?? string.Empty));
            SigningCredentials? creds = new(key, SecurityAlgorithms.HmacSha512Signature);

            // Generate access token
            DateTime dateTimeAccessExpr = now.AddMinutes(jwtSettings.AccessTokenExpirationMinutes);
            claims.Add(new Claim("token_type", "access"));
            JwtSecurityToken accessToken = new(
                claims: claims,
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                expires: dateTimeAccessExpr,
                signingCredentials: creds
            );

            string refreshTokenString = string.Empty;
            string accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);

            if (isRefresh == false)
            {
                // tạo ra refresh Token
                DateTime datetimeRefrestExpr = now.AddDays(jwtSettings.RefreshTokenExpirationDays);

                claims.Remove(claims.First(c => c.Type == "token_type"));
                claims.Add(new Claim("token_type", "refresh"));

                JwtSecurityToken? refreshToken = new(
                    claims: claims,
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    expires: datetimeRefrestExpr,
                    signingCredentials: creds
                );

                refreshTokenString = new JwtSecurityTokenHandler().WriteToken(refreshToken);
            }

            return new TokenResponse
            {
                AccessToken = accessTokenString,
                RefreshToken = refreshTokenString
            };
        }
        public static string GetUserIdFromHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                if (httpContextAccessor.HttpContext == null || !httpContextAccessor.HttpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    throw new UnauthorizedException("Need Authorization");
                }

                string? authorizationHeader = httpContextAccessor.HttpContext.Request.Headers.Authorization;

                if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    throw new UnauthorizedException($"Invalid authorization header: {authorizationHeader}");
                }

                string jwtToken = authorizationHeader["Bearer ".Length..].Trim();

                var tokenHandler = new JwtSecurityTokenHandler();

                if (!tokenHandler.CanReadToken(jwtToken))
                {
                    throw new UnauthorizedException("Invalid token format");
                }

                var token = tokenHandler.ReadJwtToken(jwtToken);
                var idClaim = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return idClaim ?? "Unknown";
            }
            catch (UnauthorizedException ex)
            {
                var errorResponse = new
                {
                    data = "An unexpected error occurred.",
                    message = ex.Message,
                    statusCode = StatusCodes.Status401Unauthorized,
                    code = "Unauthorized!"
                };

                var jsonResponse = JsonSerializer.Serialize(errorResponse);

                if (httpContextAccessor.HttpContext != null)
                {
                    httpContextAccessor.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    httpContextAccessor.HttpContext.Response.ContentType = "application/json";
                    httpContextAccessor.HttpContext.Response.WriteAsync(jsonResponse).Wait();
                }

                throw new UnauthorizedException(ex.Message);
            }
        }
        public static string GetUserIdFromHttpContext(HttpContext httpContext)
        {
            try
            {
                if (!httpContext.Request.Headers.ContainsKey("Authorization"))
                {
                    throw new UnauthorizedException("Need Authorization");
                }

                string? authorizationHeader = httpContext.Request.Headers.Authorization;

                if (string.IsNullOrWhiteSpace(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    throw new UnauthorizedException($"Invalid authorization header: {authorizationHeader}");
                }

                string jwtToken = authorizationHeader["Bearer ".Length..].Trim();
                var tokenHandler = new JwtSecurityTokenHandler();

                if (!tokenHandler.CanReadToken(jwtToken))
                {
                    throw new UnauthorizedException("Invalid token format");
                }

                var token = tokenHandler.ReadJwtToken(jwtToken);
                var idClaim = token.Claims.FirstOrDefault(claim => claim.Type == "id");

                return idClaim?.Value ?? throw new UnauthorizedException("Cannot get userId from token");
            }
            catch (UnauthorizedException ex)
            {
                var errorResponse = new
                {
                    data = "An unexpected error occurred.",
                    message = ex.Message,
                    statusCode = StatusCodes.Status401Unauthorized,
                    code = "Unauthorized!"
                };

                var jsonResponse = JsonSerializer.Serialize(errorResponse);
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.WriteAsync(jsonResponse).Wait();
                throw;
            }
        }


        public static void HandleForbiddenRequest(HttpContext context)
        {
            throw new UnauthorizedException("You do not have permission to access this resource.");
        }

    }
}


