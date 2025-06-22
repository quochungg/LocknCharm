namespace LocknCharm.Application.DTOs.Role
{
    public class RoleDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? FullName { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
