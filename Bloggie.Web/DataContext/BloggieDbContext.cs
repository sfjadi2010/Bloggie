using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.DataContext;

public class BloggieDbContext : DbContext
{
    public BloggieDbContext(DbContextOptions<BloggieDbContext> options) : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogPost>()
            .HasMany(b => b.Tags)
            .WithOne(t => t.BlogPost)
            .HasForeignKey(t => t.BlogPostId);
    }
}
