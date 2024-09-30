namespace Bloggie.Web.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
