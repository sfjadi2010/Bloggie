using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain;

public partial class BlogPostComment
{
    [Key]
    public Guid Id { get; set; }

    public Guid BlogPostId { get; set; }

    public string Description { get; set; } = null!;

    public Guid UserId { get; set; }

    public DateOnly CommentDate { get; set; }

    public virtual BlogPost BlogPost { get; set; } = null!;
}
