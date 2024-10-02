using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog;

public class DetailsModel : PageModel
{
    private readonly IBlogPostService _blogPostService;

    public DetailsModel(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnGet(string urlHandle)
    {
        var result = await _blogPostService.GetByUrlHandleAsync(urlHandle);

        if (result is null)
        {
            return NotFound();
        }
        else
        {
            BlogPost = result;
        }

        return Page();
    }
}
