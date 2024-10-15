using Bloggie.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Users;

public class CreateModel : PageModel
{
    [BindProperty]
    public RegisterViewModel RegisterViewModel { get; set; } = default!;
    public void OnGet()
    {
    }
}
