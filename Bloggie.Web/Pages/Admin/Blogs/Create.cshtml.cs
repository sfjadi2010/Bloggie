using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

[Authorize(Roles = "Admin")]
public class CreateModel : PageModel
{
    private readonly IBlogPostService _blogPostService;
    private readonly IImageService _imageService;

    [BindProperty]
    public BlogPostViewModel BlogPostViewModel { get; set; } = new();

    public CreateModel(IBlogPostService blogPostService, IImageService imageService)
    {
        _blogPostService = blogPostService;
        _imageService = imageService;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        BlogPostViewModel.BlogPost.Tags = BlogPostViewModel.Tags.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(t => new Tag { Name = t.Trim() })
            .ToList();

        await _blogPostService.CreateAsync(BlogPostViewModel.BlogPost);

        return RedirectToPage("/Admin/Blogs/List");
    }
}
