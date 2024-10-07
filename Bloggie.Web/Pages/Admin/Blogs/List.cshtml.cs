using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

[Authorize(Roles = "Admin")]
public class ListModel : PageModel
{
    private readonly IBlogPostService _blogPostService;

    public ListModel(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [BindProperty]
    public IEnumerable<BlogPost> Posts { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        Posts = await _blogPostService.GetAllAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync([FromBody] Guid id)
    {
        await _blogPostService.DeleteAsync(id);

        return RedirectToPage();
    }
}
