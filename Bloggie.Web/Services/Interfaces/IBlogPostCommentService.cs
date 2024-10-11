using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Services.Interfaces;

public interface IBlogPostCommentService
{
    Task<BlogPostComment> AddCommentAsync(BlogPostComment blogPostComment);
    Task<IEnumerable<BlogPostComment>> GetAllCommentsByIdAsync(Guid blogPostId);
}
