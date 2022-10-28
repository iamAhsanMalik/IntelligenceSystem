namespace IFC.Controllers;

public class UserManagementController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserInfoService _userInfoService;

    public UserManagementController(UserManager<ApplicationUser> userManager, IUserInfoService userInfoService)
    {
        _userManager = userManager;
        _userInfoService = userInfoService;
    }
    public async Task<IActionResult> Index()
    {
        var currentUser = await _userInfoService.GetCurrentLoginUserAsync();
        return View(await _userManager.Users.Where(a => a.Id != currentUser!.Id).ToListAsync());
    }
}