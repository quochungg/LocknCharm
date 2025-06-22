namespace LocknCharm.Application.DTOs.RoleClaims
{
    public class RoleClaimDTO
    {
        public string? Id { get; set; }
        public string? RoleName { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
