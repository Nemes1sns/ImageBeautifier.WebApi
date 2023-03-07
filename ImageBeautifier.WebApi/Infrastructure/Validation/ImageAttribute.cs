using System.ComponentModel.DataAnnotations;

namespace ImageBeautifier.WebApi.Infrastructure.Validation;

internal sealed class ImageAttribute : ValidationAttribute
{
    private readonly string[] _supportedFormats =
    {
        ".bmp",
        ".jpg",
        ".jpeg",
        ".png",
        ".gif"
    };
    
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile file || 
            _supportedFormats.Contains(Path.GetExtension(file.FileName).ToLower()))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Only .bmp, .jpg, .jpeg, .png, .gif formats are supported.");
    } 
}