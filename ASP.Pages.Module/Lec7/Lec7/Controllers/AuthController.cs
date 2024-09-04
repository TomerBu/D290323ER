using Lec7.Models;
using Lec7.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
                ModelState.AddModelError(string.Empty, error.Description);
            }

        }

        return View(vm);
    }

    //   /auth/login?ReturnUrl=/Products
    public IActionResult Login(string ReturnUrl = "/")
    {
        ViewBag.ReturnUrl = ReturnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm, string ReturnUrl = "/")
    {
        if (ModelState.IsValid)
        {

            //var user = await userManager.FindByEmailAsync(vm.Email);
            //var result = signInManager.PasswordSignInAsync(user, vm.Password, true, false);
            var result = await signInManager.PasswordSignInAsync(vm.Email, vm.Password, true, false);

            if (result.Succeeded)
            {
                return Redirect(ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        }
        return View(vm);
    }

    public async Task<IActionResult> Logout()
    {
        //1) logout the user - delete the cookie
        await signInManager.SignOutAsync();
        //2) redirect to "/"
        return Redirect("/");
    }

    public async Task<IActionResult> Manage()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return Redirect("/");
        }
        ViewBag.UserName = user.UserName;

        var vm = new ManageViewModel() { Language = user.Language };
        return View(vm);
    }


    [HttpPost]
    public async Task<IActionResult> Manage(ManageViewModel vm)
    {
        var user = await userManager.GetUserAsync(User);

        if (user is null)
        {
            return Redirect("/");
        }
        if (vm.Password is not null && vm.NewPassword is not null)
        {
            //userManager.ChangePasswordAsync
            var result = await userManager.ChangePasswordAsync(user, vm.Password, vm.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(vm); //the new pass is 2 short/passwords dont match
            }
        }

        if (vm.Language is not null)
        {
            user.Language = vm.Language;
            await userManager.UpdateAsync(user);
        }
        return Redirect("/");
    }
}
