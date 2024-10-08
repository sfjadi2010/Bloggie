using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain;

public class BlogPostLike
{
    [Key]
    public Guid Id { get; set; }

    public Guid BlogPostId { get; set; }

    public Guid UserId { get; set; }

    public virtual BlogPost BlogPost { get; set; } = null!;
}
