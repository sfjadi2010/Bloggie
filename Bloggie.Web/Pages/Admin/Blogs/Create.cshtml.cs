using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class CreateModel : PageModel
{
    private readonly IBlogPostService _blogPostService;
    private readonly IImageService _imageService;

    public CreateModel(IBlogPostService blogPostService, IImageService imageService)
    {
        _blogPostService = blogPostService;
        _imageService = imageService;
    }

    public void OnGet()
    {
    }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    [BindProperty]
    public string ImageUrl { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        await _blogPostService.CreateAsync(BlogPost);

        return RedirectToPage("/Admin/Blogs/List");
    }
}
