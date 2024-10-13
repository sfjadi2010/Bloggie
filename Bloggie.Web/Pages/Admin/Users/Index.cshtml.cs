using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users;

public class IndexModel : PageModel
{
    private readonly IUserService _userService;

    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public IEnumerable<IdentityUser> Users { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var result = await _userService.GetAllAsync();

        if (result is not null)
        {
            Users = result;
        }

        return Page();
    }
}
