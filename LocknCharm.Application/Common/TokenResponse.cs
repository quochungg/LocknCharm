using LocknCharm.Application.DTOs.ApplicationUser;

namespace LocknCharm.Application.Common
{
    public class TokenResponse
    {
        public required string AccessToken { get; set; }

        public required string RefreshToken { get; set; }

    }
}
