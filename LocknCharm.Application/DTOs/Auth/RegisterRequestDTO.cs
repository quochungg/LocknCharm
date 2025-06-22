namespace LocknCharm.Application.DTOs.Auth
{
    public class RegisterRequestDTO
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string RoleId { get; set; } = null!;
    }
}
