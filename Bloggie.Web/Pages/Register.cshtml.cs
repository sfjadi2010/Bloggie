using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; } = new();

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = new IdentityUser
            {
                UserName = RegisterViewModel.Username,
                Email = RegisterViewModel.Email
            };

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, RegisterViewModel.Password);

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
            {
                var addUserRoleResult = await _userManager.AddToRoleAsync(user, "User");

                if (addUserRoleResult.Succeeded)
                {
                    return RedirectToPage("/Login");
                }
            }

            return Page();
        }
    }
}
