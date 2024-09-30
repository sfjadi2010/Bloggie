using Bloggie.Web.Services.Interfaces;
using CDN = CloudinaryDotNet;

namespace Bloggie.Web.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadAsync(IFormFile file)
        {
            CDN.Account account = new CDN.Account(
                "drlzi129a",
                "461891919474275",
                "dDvqjdKzD4OIKL0RtIvlXsf62BQ"
            );

            CDN.Cloudinary cloudinaryClient = new(account);

            var uploadFileResult = await cloudinaryClient.UploadAsync(
                new CDN.Actions.ImageUploadParams()
                {
                    File = new CDN.FileDescription(file.FileName, file.OpenReadStream()),
                    DisplayName = file.FileName
                });

            if (uploadFileResult is not null && uploadFileResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadFileResult.SecureUrl.AbsoluteUri;
            }

            return string.Empty;
        }
    }
}
