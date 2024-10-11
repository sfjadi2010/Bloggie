using Bloggie.Web.DataContext;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Services;

public class BlogPostLikeService : IBlogPostLikeService
{
    private readonly BloggieDbContext _context;

    public BlogPostLikeService(BloggieDbContext context)
    {
        _context = context;
    }

    public Task<BlogPostLike> DislikeAsync(Guid blogPostId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<BlogPostLike>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<BlogPostLike>> GetAllByBlogPostIdAsync(Guid blogPostId)
    {
        return await _context.BlogPostLikes
            .AsNoTracking()
            .Where(b => b.BlogPostId == blogPostId)
            .ToListAsync();
    }

    public Task<IEnumerable<BlogPostLike>> GetAllByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task<BlogPostLike> GetByBlogPostIdAndUserIdAsync(Guid blogPostId, Guid userId)
    {
        var result = await _context
            .BlogPostLikes
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.BlogPostId == blogPostId && b.UserId == userId);

        return result;
    }

    public async Task<int> GetLikesCountByBlogPostIdAsync(Guid blogPostId)
    {
        return await _context.BlogPostLikes.CountAsync(x => x.BlogPostId == blogPostId);
    }

    public async Task<BlogPostLike> LikeAsync(Guid blogPostId, Guid userId)
    {
        BlogPostLike blogPostLike = new() { Id = Guid.NewGuid(), BlogPostId = blogPostId, UserId = userId };
        await _context.BlogPostLikes.AddAsync(blogPostLike);

        await _context.SaveChangesAsync();

        return blogPostLike;
    }
}
