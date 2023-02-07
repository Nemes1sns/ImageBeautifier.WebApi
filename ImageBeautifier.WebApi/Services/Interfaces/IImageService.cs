namespace ImageBeautifier.WebApi.Services.Interfaces;

public interface IImageService
{
    Task UploadImageAsync(IFormFile file);
}