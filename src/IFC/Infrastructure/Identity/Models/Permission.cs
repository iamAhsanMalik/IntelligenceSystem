namespace IFC.Infrastructure.Identity.Models;
public class Permission
{
    public string? RoleId { get; set; }
    public IList<RoleClaim>? RoleClaims { get; set; }
}
