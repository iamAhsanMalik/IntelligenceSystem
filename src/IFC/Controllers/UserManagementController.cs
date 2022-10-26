using IFC.Application.Contracts.Identity;
using Microsoft.EntityFrameworkCore;

namespace IFC.Controllers;

public class UserManagementController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserInfoService _userInfoService;

    public UserManagementController(UserManager<IdentityUser> userManager, IUserInfoService userInfoService)
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
