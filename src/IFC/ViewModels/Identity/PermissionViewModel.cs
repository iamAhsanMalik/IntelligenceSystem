namespace IFC.ViewModels.Identity;
public class PermissionViewModel
{
    public string? RoleId { get; set; }
    public IList<RoleClaimViewModel>? RoleClaims { get; set; }
}
