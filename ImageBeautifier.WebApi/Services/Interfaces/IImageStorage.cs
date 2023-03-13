namespace ImageBeautifier.WebApi.Services.Interfaces;

internal interface IImageStorage
{
    Task<string> UploadImageAsync(IFormFile file, CancellationToken cancellationToken);
}