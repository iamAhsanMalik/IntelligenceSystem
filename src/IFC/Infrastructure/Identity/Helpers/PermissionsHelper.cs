namespace IFC.Infrastructure.Identity.Helpers;

public static class PermissionsHelper
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
    }
    public static List<RoleClaimModel> GetPermissions(List<string> policy)
    {
        var allPermissions = new List<RoleClaimModel>();
        foreach (var fi in policy)
        {
            allPermissions.Add(new RoleClaimModel { Value = fi, Type = "Permissions" });
        }
        return allPermissions;
    }
}