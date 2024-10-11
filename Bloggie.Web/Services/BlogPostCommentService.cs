using Bloggie.Web.DataContext;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Services;

public class BlogPostCommentService : IBlogPostCommentService
{
    private readonly BloggieDbContext _context;

    public BlogPostCommentService(BloggieDbContext context)
    {
        _context = context;
    }

    public async Task<BlogPostComment> AddCommentAsync(BlogPostComment blogPostComment)
    {
        await _context.BlogPostComments.AddAsync(blogPostComment);
        await _context.SaveChangesAsync();

        return blogPostComment;
    }

    public async Task<IEnumerable<BlogPostComment>> GetAllCommentsByIdAsync(Guid blogPostId)
    {
        var result = await _context
            .BlogPostComments
            .AsNoTracking()
            .Where(c => c.BlogPostId == blogPostId)
            .ToListAsync();

        return result;
    }
}
