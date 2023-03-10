using ImageBeautifier.WebApi.Models;

namespace ImageBeautifier.WebApi.Services.Interfaces;

public interface IImageService
{
    Task<Guid> UploadImageAsync(IFormFile file, CancellationToken cancellationToken);
    Task<BeautifierTaskState> GetCurrentStateAsync(Guid id, CancellationToken cancellationToken);
}