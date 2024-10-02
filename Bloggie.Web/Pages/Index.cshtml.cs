using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IBlogPostService _blogPostService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(IBlogPostService blogPostService, ILogger<IndexModel> logger)
    {
        _blogPostService = blogPostService;
        _logger = logger;
    }

    public IEnumerable<BlogPost> BlogPosts { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        var result = await _blogPostService.GetAllAsync();

        if (result is null)
        {
            return NotFound();
        }
        else
        {
            BlogPosts = result;
        }

        return Page();
    }
}
