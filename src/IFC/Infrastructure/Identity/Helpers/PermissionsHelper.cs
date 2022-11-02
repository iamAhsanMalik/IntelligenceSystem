using IFC.ViewModels.Identity;

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
    public static List<string> GeneratePermissionsForModules(List<string> modules)
    {
        var permissionList = new List<string>();
        foreach (var module in modules)
        {
            var list = new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
            permissionList.AddRange(list);
        }
        return permissionList;
    }
    public static List<RoleClaimViewModel> GetPermissions(List<string> policy)
    {
        var allPermissions = new List<RoleClaimViewModel>();
        foreach (var fi in policy)
        {
            allPermissions.Add(new RoleClaimViewModel { Value = fi, Type = "Permissions" });
        }
        return allPermissions;
    }
}