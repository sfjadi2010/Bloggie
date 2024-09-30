using Bloggie.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var result = await _imageService.UploadAsync(file);

            return !string.IsNullOrWhiteSpace(result)
                ? Ok(result)
                : BadRequest();
        }
    }
}
