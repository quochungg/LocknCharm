using LocknCharm.Application.Common;
using LocknCharm.Application.DTOs.ApplicationUser;

namespace LocknCharm.Application.DTOs.Auth
{
    public class LoginResponseDTO
    {
        public ApplicationUserDTO? User { get; set; }

        public TokenResponse Token { get; set; } = null!;
        
    }
}
