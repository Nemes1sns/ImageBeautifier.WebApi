using ImageBeautifier.WebApi.Models.Response;

namespace ImageBeautifier.WebApi.Services.Interfaces;

public interface IImageService
{
    Task<Guid> UploadImageAsync(IFormFile file, CancellationToken cancellationToken);
    Task<GetBeautifiedImageResponse> GetCurrentStateAsync(Guid id, CancellationToken cancellationToken);
}