using Lec7.Models;
using Lec7.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lec7.Controllers;

public class AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel vm)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser() { Language = vm.Language, Email = vm.Email, UserName = vm.Email };
            var result = await userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: true);
                return Redirect("/");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Register Failed", error.Description);
            }

        }

        return View(vm);
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
