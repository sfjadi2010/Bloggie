using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog;

public class DetailsModel : PageModel
{
    private readonly IBlogPostService _blogPostService;
    private readonly IBlogPostLikeService _blogPostLikeService;

    public DetailsModel(IBlogPostService blogPostService, IBlogPostLikeService blogPostLikeService)
    {
        _blogPostService = blogPostService;
        _blogPostLikeService = blogPostLikeService;
    }
    [BindProperty]
    public int Likes { get; set; }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnGet(string urlHandle)
    {
        var result = await _blogPostService.GetByUrlHandleAsync(urlHandle);

        if (result is null)
        {
            return NotFound();
        }
        else
        {
            BlogPost = result;
            Likes = await _blogPostLikeService.GetLikesCountByBlogPostIdAsync(BlogPost.Id);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostLikeAsync([FromBody] BlogPostLikeViewModel likeViewModel)
    {
        var isLikedExist = await _blogPostLikeService.GetByBlogPostIdAndUserIdAsync(likeViewModel.BlogPostId, likeViewModel.UserId);
        if (isLikedExist is null)
        {
            await _blogPostLikeService.LikeAsync(likeViewModel.BlogPostId, likeViewModel.UserId);
        }

        return Page();
    }

    public async Task<IActionResult> OnPostLikesAsync([FromBody] Guid BlogPostId)
    {
        var result = await _blogPostLikeService.GetLikesCountByBlogPostIdAsync(BlogPostId);
        return new JsonResult(result);
    }
}
