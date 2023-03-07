using ImageBeautifier.WebApi.Services.Interfaces;

namespace ImageBeautifier.WebApi.Services;

internal sealed class ImageService : IImageService
{
    public async Task<Guid> UploadImageAsync(IFormFile file)
    {
        return Guid.NewGuid();
    }
}