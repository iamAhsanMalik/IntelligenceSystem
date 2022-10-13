using IFC.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Security.Claims;

namespace IFC.Application.Extensions;

public static class ClaimsExtensions
{
    public static void GetPermissions(this List<RoleClaim> allPermissions, Type policy)
    {
        foreach (FieldInfo field in policy.GetFields(BindingFlags.Static | BindingFlags.Public))
        {
            allPermissions.Add(new RoleClaim { Value = field.GetValue(null)?.ToString(), Type = "Permissions" });
        }
    }
    public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string permission)
    {
        var allClaims = await roleManager.GetClaimsAsync(role);
        if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
        {
            await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
        }
    }
}
