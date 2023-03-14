using Amazon.S3;
using Amazon.S3.Model;
using ImageBeautifier.WebApi.Infrastructure.Configuration;
using ImageBeautifier.WebApi.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ImageBeautifier.WebApi.Services;

internal sealed class ImageStorage : IImageStorage
{
    private readonly IAmazonS3 _amazonS3;
    private readonly AWSEnvironmentOptions _awsEnvironmentOptions;
    private const string OriginalFilePrefix = "original";

    public ImageStorage(IAmazonS3 amazonS3, IOptions<AWSEnvironmentOptions> awsEnvironmentOptions)
    {
        _amazonS3 = amazonS3;
        _awsEnvironmentOptions = awsEnvironmentOptions.Value;
    }

    public async Task<string> UploadImageAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var request = new PutObjectRequest
        {
            BucketName = _awsEnvironmentOptions.BucketName,
            Key = $"{OriginalFilePrefix}/{file.FileName}",
            InputStream = file.OpenReadStream()
        };
        request.Metadata.Add("Content-Type", file.ContentType);
        await _amazonS3.PutObjectAsync(request, cancellationToken);
        return request.Key;
    }

    public string GetPublicUrl(string key) 
        => $"https://{_awsEnvironmentOptions.BucketName}.s3.amazonaws.com/{key.Replace(' ', '+')}";
}