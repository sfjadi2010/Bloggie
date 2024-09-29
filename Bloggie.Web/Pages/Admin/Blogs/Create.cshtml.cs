using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class CreateModel : PageModel
{
    private readonly IBlogPostService _blogPostService;

    public CreateModel(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    public void OnGet()
    {
    }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        await _blogPostService.CreateAsync(BlogPost);

        return RedirectToPage("/Admin/Blogs/List");
    }
}
