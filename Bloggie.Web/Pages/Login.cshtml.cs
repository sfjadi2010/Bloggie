using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public LoginModel(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [BindProperty]
    public LoginViewModel LoginViewModel { get; set; } = new();

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync(string ReturnUrl)
    {
        var result = await _signInManager.PasswordSignInAsync(LoginViewModel.Username, LoginViewModel.Password, false, false);

        if (result.Succeeded)
        {
            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            {
                return RedirectToPage(ReturnUrl);
            }

            if (User.IsInRole("Admin"))
            {
                return RedirectToPage("/Admin/Blogs/List");
            }

            return RedirectToPage("/Index");
        }

        return Page();
    }
}
