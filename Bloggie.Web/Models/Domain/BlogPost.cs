using System.ComponentModel.DataAnnotations;

namespace Bloggie.Web.Models.Domain;

public partial class BlogPost
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Heading")]
    public required string Heading { get; set; }

    [Display(Name = "Page Title")]
    public required string PageTitle { get; set; }

    [Display(Name = "Short Description")]
    public required string ShortDescription { get; set; }

    [Display(Name = "Content")]
    public required string Content { get; set; }

    [Display(Name = "Feature Image Url")]
    public required string FeatureImageUrl { get; set; }

    [Display(Name = "Url Handle")]
    public required string UrlHandle { get; set; }

    [Display(Name = "Publication Date")]
    public DateTime PublicationDate { get; set; }

    [Display(Name = "Author")]
    public required string Author { get; set; }

    [Display(Name = "Is Visible")]
    public bool Visible { get; set; }

    public virtual List<Tag> Tags { get; set; } = new();
}
