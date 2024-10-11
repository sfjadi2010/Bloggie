using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Blog;

public class DetailsModel : PageModel
{
    private readonly IBlogPostService _blogPostService;
    private readonly IBlogPostLikeService _blogPostLikeService;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public DetailsModel(IBlogPostService blogPostService,
        IBlogPostLikeService blogPostLikeService,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager)
    {
        _blogPostService = blogPostService;
        _blogPostLikeService = blogPostLikeService;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [BindProperty]
    public bool Liked { get; set; }

    [BindProperty]
    public int Likes { get; set; }

    [BindProperty]
    public BlogPost BlogPost { get; set; } = default!;

    public async Task<IActionResult> OnGet(string urlHandle)
    {
        var result = await _blogPostService.GetByUrlHandleAsync(urlHandle);

        if (result is not null)
        {
            BlogPost = result;

            if (_signInManager.IsSignedIn(User))
            {
                var blogPostLikes = await _blogPostLikeService.GetAllByBlogPostIdAsync(BlogPost.Id);

                var userId = _userManager.GetUserId(User);

                Liked = blogPostLikes.Any(b => b.UserId == new Guid(userId));
            }

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
