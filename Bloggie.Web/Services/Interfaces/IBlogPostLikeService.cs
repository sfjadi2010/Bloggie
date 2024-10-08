using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Services.Interfaces;

public interface IBlogPostLikeService
{
    Task<BlogPostLike> LikeAsync(Guid blogPostId, Guid userId);

    Task<BlogPostLike> DislikeAsync(Guid blogPostId, Guid userId);

    Task<IEnumerable<BlogPostLike>> GetAllAsync();

    Task<IEnumerable<BlogPostLike>> GetAllByBlogPostIdAsync(Guid blogPostId);

    Task<IEnumerable<BlogPostLike>> GetAllByUserIdAsync(Guid userId);

    Task<BlogPostLike> GetByBlogPostIdAndUserIdAsync(Guid blogPostId, Guid userId);

    Task<int> GetLikesCountByBlogPostIdAsync(Guid blogPostId);
}
