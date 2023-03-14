using System.ComponentModel.DataAnnotations;
using ImageBeautifier.WebApi.Infrastructure.Validation;
using ImageBeautifier.WebApi.Models.Response;
using ImageBeautifier.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImageBeautifier.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }
    
    [HttpPost]
    public async Task<Guid> Upload([Required][Image]IFormFile file, CancellationToken cancellationToken) 
        => await _imageService.UploadImageAsync(file, cancellationToken);
    
    [HttpGet("{id:guid}")]
    public async Task<GetBeautifiedImageResponse> GetBeautifiedImage([Required]Guid id, CancellationToken cancellationToken) 
        => await _imageService.GetCurrentStateAsync(id, cancellationToken);
}