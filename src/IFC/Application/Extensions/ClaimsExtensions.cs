using IFC.ViewModels.Identity;

namespace IFC.Application.Extensions;

public static class ClaimsExtensions
{
    public static void GetPermissionsWithTypePolicy(this List<RoleClaimViewModel> allPermissions, Type policy)
    {
        foreach (FieldInfo field in policy.GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            allPermissions.Add(new RoleClaimViewModel { Value = field.GetValue(null)?.ToString(), Type = "Permissions" });
        }
    }
    public static async Task AddPermissionClaimSeedingAsync(this RoleManager<IdentityRole> roleManager, string role, string moduleName)
    {
        IdentityRole? adminRole = await roleManager.FindByNameAsync(role);
        var allClaims = await roleManager.GetClaimsAsync(adminRole);
        foreach (var permission in PermissionsHelper.GeneratePermissionsForModule(moduleName))
        {
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                await roleManager.AddClaimAsync(adminRole, new Claim("Permission", permission));
            }
        }
    }
    public static async Task AddPermissionClaimAsync(this RoleManager<IdentityRole> roleManager, string roleName, string permission)
    {
        IdentityRole? role = await roleManager.FindByNameAsync(roleName);
        var allClaims = await roleManager.GetClaimsAsync(role);
        if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
        {
            await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
        }
    }
}
