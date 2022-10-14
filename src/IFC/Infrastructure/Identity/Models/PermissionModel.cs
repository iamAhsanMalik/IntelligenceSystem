namespace IFC.Infrastructure.Identity.Models;
public class PermissionModel
{
    public string? RoleId { get; set; }
    public IList<RoleClaimModel>? RoleClaims { get; set; }
}
