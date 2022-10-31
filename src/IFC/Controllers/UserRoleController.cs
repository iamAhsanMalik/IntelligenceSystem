namespace IFC.Controllers;

[Authorize(Roles = nameof(AppRoles.SuperAdmin))]
public class UserRoleController : Controller
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRoleController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index(string userId)
    {
        var viewModel = new List<UserRolesModel>();
        var user = await _userManager.FindByIdAsync(userId);
        foreach (var role in _roleManager.Roles.ToList())
        {
            var userRolesViewModel = new UserRolesModel
            {
                RoleName = role.Name
            };
            userRolesViewModel.Selected = await _userManager.IsInRoleAsync(user, role.Name);
            viewModel.Add(userRolesViewModel);
        }
        var model = new ManageUserRolesModel()
        {
            UserId = userId,
            UserRoles = viewModel
        };

        return View(model);
    }

    public async Task<IActionResult> Update(string id, ManageUserRolesModel model)
    {
        var user = await _userManager.FindByIdAsync(id);
        var roles = await _userManager.GetRolesAsync(user);
        var result = await _userManager.RemoveFromRolesAsync(user, roles);
        result = await _userManager.AddToRolesAsync(user, model.UserRoles?.Where(x => x.Selected).Select(y => y.RoleName));
        var currentUser = await _userManager.GetUserAsync(User);
        await _signInManager.RefreshSignInAsync(currentUser);
        return RedirectToAction(nameof(UserRoleController.Index), new { userId = id });
    }
}