using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IFC.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}
