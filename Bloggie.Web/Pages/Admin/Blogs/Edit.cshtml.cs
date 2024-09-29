using Bloggie.Web.Models.Domain;
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
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var result = await _blogPostService.GetAsync(id);

        if (result is not null)
        {
            BlogPost = result;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _blogPostService.UpdateAsync(BlogPost);

        return RedirectToPage("/Admin/Blogs/List");
    }
}
