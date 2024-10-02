using Bloggie.Web.DataContext;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Services;

/// <inheritdoc />
public class BlogPostService : IBlogPostService
{
    private readonly BloggieDbContext _context;

    public BlogPostService(BloggieDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc />
    public async Task<BlogPost> CreateAsync(BlogPost post)
    {
        await _context.BlogPosts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(Guid id)
    {
        var post = await _context.BlogPosts.FindAsync(id);

        if (post is not null)
        {
            _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context
            .BlogPosts
            .AsNoTracking()
            .ToListAsync();
    }

    /// <inheritdoc />
    public async Task<BlogPost> GetAsync(Guid id)
    {
        var blogPost = await _context.BlogPosts.FindAsync(id);

        if (blogPost is null)
        {
            throw new KeyNotFoundException($"The blog post with ID {id} was not found.");
        }

        return blogPost;
    }

    /// <inheritdoc />
    public async Task<BlogPost> GetByUrlHandleAsync(string urlHandle)
    {
        var blogPost = await _context
            .BlogPosts
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.UrlHandle.ToLower() == urlHandle.ToLower());

        if (blogPost is null)
        {
            throw new KeyNotFoundException($"The blog post with ID {urlHandle} was not found.");
        }

        return blogPost;
    }

    /// <inheritdoc />
    public async Task<BlogPost> UpdateAsync(BlogPost post)
    {
        _context.BlogPosts.Update(post);
        await _context.SaveChangesAsync();

        return post;
    }
}
