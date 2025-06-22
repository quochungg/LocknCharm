namespace LocknCharm.Application.DTOs.RoleClaims
{
    public class CreateRoleClaimDTO
    {
        public string? RoleId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}
