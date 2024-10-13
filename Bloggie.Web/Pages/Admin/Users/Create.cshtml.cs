using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users;

public class CreateModel : PageModel
{
    [BindProperty]
    public UserViewModel UserViewModel { get; set; } = default!;
    public void OnGet()
    {
    }
}
