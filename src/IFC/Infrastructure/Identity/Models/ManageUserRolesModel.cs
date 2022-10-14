namespace IFC.Infrastructure.Identity.Models;

public class ManageUserRolesModel
{
    public string? UserId { get; set; }
    public IList<UserRolesModel>? UserRoles { get; set; }
}
