using Bloggie.Web.DataContext;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Pages.Admin.Blogs;
public class ListModel : PageModel
{
    private readonly BloggieDbContext _context;

    public ListModel(BloggieDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public List<BlogPost> Posts { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        Posts = await _context.BlogPosts.ToListAsync();
        return Page();
    }
}
