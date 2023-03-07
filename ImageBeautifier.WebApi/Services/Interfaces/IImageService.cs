namespace ImageBeautifier.WebApi.Services.Interfaces;

public interface IImageService
{
    Task<Guid> UploadImageAsync(IFormFile file);
}