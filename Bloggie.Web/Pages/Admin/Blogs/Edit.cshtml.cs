using Bloggie.Web.DataContext;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs;

public class EditModel : PageModel
{
    private readonly BloggieDbContext _context;

    public EditModel(BloggieDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var result = await _context.BlogPosts.FindAsync(id);

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

        _context.BlogPosts.Update(BlogPost);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Admin/Blogs/List");
    }
}
