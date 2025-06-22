namespace LocknCharm.Application.DTOs.RoleClaims
{
    public class UpdateRoleClaimDTO
    {
        public string? RoleClaimId { get; set; }
        public string? RoleId { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}
