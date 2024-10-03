using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Models;

public sealed class BlogPostViewModel
{
    public BlogPost BlogPost { get; set; } = default!;
    public string Tags { get; set; } = string.Empty;
}
