namespace IFC.Controllers;

[Authorize(Roles = nameof(AppRoles.SuperAdmin))]
public class PermissionManagementController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    public PermissionManagementController(RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<ActionResult> Index(string roleId)
    {
        List<RoleClaimModel> allPermissions = PermissionsHelper.GetPermissions(PermissionsHelper.GeneratePermissionsForModule("Prodcut"));
        List<string?> allClaimValues = allPermissions.ConvertAll(a => a.Value);
        List<string> roleClaimValues = (await _roleManager.GetClaimsAsync(await _roleManager.FindByIdAsync(roleId))).Select(a => a.Value).ToList();
        var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
        foreach (var permission in allPermissions)
        {
            if (authorizedClaims.Any(a => a == permission.Value))
            {
                permission.Selected = true;
            }
        }
        return View(new PermissionModel()
        {
            RoleId = roleId,
            RoleClaims = allPermissions
        });
    }
    public async Task<IActionResult> Update(PermissionModel model)
    {
        var role = await _roleManager.FindByIdAsync(model.RoleId);
        var claims = await _roleManager.GetClaimsAsync(role);
        foreach (var claim in claims)
        {
            await _roleManager.RemoveClaimAsync(role, claim);
        }
        var selectedClaims = model.RoleClaims?.Where(a => a.Selected).ToList();
        foreach (var claim in selectedClaims!)
        {
            await _roleManager.AddPermissionClaimAsync(role.Name, claim.Value!);
        }
        return RedirectToAction("Index", new { roleId = model.RoleId });
    }
}
