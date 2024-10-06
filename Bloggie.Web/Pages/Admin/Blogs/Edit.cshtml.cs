using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    private readonly IBlogPostService _blogPostService;

    public EditModel(IBlogPostService blogPostService)
    {
        _blogPostService = blogPostService;
    }

    [BindProperty]
    public BlogPostViewModel BlogPostViewModel { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var result = await _blogPostService.GetAsync(id);

        if (result is not null)
        {
            BlogPostViewModel.BlogPost = result;

            BlogPostViewModel.Tags = string.Join(", ", BlogPostViewModel.BlogPost.Tags.Select(t => t.Name));
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        BlogPostViewModel.BlogPost.Tags = BlogPostViewModel.Tags.Split(',').Select(t => new Tag { Name = t.Trim() }).ToList();

        await _blogPostService.UpdateAsync(BlogPostViewModel.BlogPost);

        return RedirectToPage("/Admin/Blogs/List");
    }
}
