using IFC.ViewModels;

namespace IFC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Incidents()
    {
        return View();
    }
    public IActionResult Threat()
    {
        return View();
    }
    public IActionResult Organization()
    {
        return View();
    }
    public IActionResult Terrorist()
    {
        return View();
    }
    public IActionResult UserManagement()
    {
        return View();
    }
    public IActionResult ApprovalManagement()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}