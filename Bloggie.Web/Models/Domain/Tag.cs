using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain;

public partial class Tag
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Name")]
    public required string Name { get; set; }

    public Guid BlogPostId { get; set; }
    public virtual BlogPost BlogPost { get; set; } = null!;
}
