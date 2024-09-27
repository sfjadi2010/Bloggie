using Bloggie.Web.DataContext;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class CreateModel : PageModel
{
    private readonly BloggieDbContext _context;

    public CreateModel(BloggieDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
    }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.BlogPosts.Add(BlogPost);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
