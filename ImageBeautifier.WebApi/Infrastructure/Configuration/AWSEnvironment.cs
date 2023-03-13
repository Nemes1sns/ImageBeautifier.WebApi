namespace ImageBeautifier.WebApi.Infrastructure.Configuration;

public sealed class AWSEnvironmentOptions
{
    public string BucketName { get; init; } = string.Empty;
    public string QueueUrl { get; init; } = string.Empty;
}