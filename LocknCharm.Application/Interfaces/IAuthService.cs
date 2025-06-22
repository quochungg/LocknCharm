using LocknCharm.Application.DTOs.ApplicationUser;
using LocknCharm.Application.DTOs.Auth;

namespace LocknCharm.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDTO> Login(LoginRequestDTO model);

        Task<ApplicationUserDTO> Register(RegisterRequestDTO model);

        Task<ApplicationUserDTO> GetUserInfo(string? id);

        Task Delete(string id);

    }
}
