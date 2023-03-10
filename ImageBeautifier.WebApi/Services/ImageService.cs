using ImageBeautifier.WebApi.Models;
using ImageBeautifier.WebApi.Services.Interfaces;

namespace ImageBeautifier.WebApi.Services;

internal sealed class ImageService : IImageService
{
    public async Task<Guid> UploadImageAsync(IFormFile file, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }

    public async Task<BeautifierTaskState> GetCurrentStateAsync(Guid id, CancellationToken cancellationToken)
    {
        return BeautifierTaskState.Created;
    }
}