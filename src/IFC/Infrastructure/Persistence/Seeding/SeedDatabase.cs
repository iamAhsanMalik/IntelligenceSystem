using IFC.Application.Extensions;
using IFC.Domain.Enums;
using IFC.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace IFC.Infrastructure.Persistence.Seeding;
public class SeedDatabase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public SeedDatabase(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(nameof(AppRoles.SuperAdmin)));
        await roleManager.CreateAsync(new IdentityRole(nameof(AppRoles.Admin)));
        await roleManager.CreateAsync(new IdentityRole(nameof(AppRoles.Basic)));
    }
    public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager)
    {
        //Seed Default User
        var defaultUser = new ApplicationUser
        {
            UserName = "basicuser",
            Email = "basicuser@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            FirstName = "Basic",
            LastName = "User"
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123");
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRoles.Basic));
            }
        }
    }
    public static async Task SeedSuperAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new ApplicationUser
        {
            UserName = "superadmin",
            Email = "superadmin@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            FirstName = "Super",
            LastName = "Admin"
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123");
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRoles.Basic));
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRoles.Admin));
                await userManager.AddToRoleAsync(defaultUser, nameof(AppRoles.SuperAdmin));
            }
            await roleManager.AddPermissionClaim("SuperAdmin", "Product");
        }
    }
    public async Task DatabaseSeederAsync()
    {
        //Roles Seeder
        await SeedRolesAsync(_roleManager);
        await SeedBasicUserAsync(_userManager);
        await SeedSuperAdminAsync(_userManager, _roleManager);
    }
}
