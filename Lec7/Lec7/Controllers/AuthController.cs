using Microsoft.AspNetCore.Mvc;

namespace Lec7.Controllers;

public class AuthController : Controller
{
    public async Task<IActionResult> Register()
    {
        return View();
    }  
    public async Task<IActionResult> Login()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        return View();
    }

    public async Task<IActionResult> Manage()
    {
        return View();
    }
}
