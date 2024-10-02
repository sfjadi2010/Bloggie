using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Services.Interfaces;

/// <summary>
/// Represents the interface for the BlogPostService.
/// </summary>
public interface IBlogPostService
{
    /// <summary>
    /// Retrieves all blog posts asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of blog posts.</returns>
    Task<IEnumerable<BlogPost>> GetAllAsync();

    /// <summary>
    /// Retrieves a blog post by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the blog post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the blog post.</returns>
    Task<BlogPost> GetAsync(Guid id);

    /// <summary>
    /// Retrieves a blog post by its ID asynchronously.
    /// </summary>
    /// <param name="urlHandle">The urlHandle of the blog post.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the blog post.</returns>
    Task<BlogPost> GetByUrlHandleAsync(string urlHandle);

    /// <summary>
    /// Creates a new blog post asynchronously.
    /// </summary>
    /// <param name="post">The blog post to create.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created blog post.</returns>
    Task<BlogPost> CreateAsync(BlogPost post);

    /// <summary>
    /// Updates an existing blog post asynchronously.
    /// </summary>
    /// <param name="post">The blog post to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the updated blog post.</returns>
    Task<BlogPost> UpdateAsync(BlogPost post);

    /// <summary>
    /// Deletes a blog post by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the blog post to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a boolean value indicating whether the deletion was successful or not.</returns>
    Task<bool> DeleteAsync(Guid id);
}
