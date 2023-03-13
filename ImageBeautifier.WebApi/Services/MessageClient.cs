using System.Text.Json;
using Amazon.SQS;
using Amazon.SQS.Model;
using ImageBeautifier.WebApi.Infrastructure.Configuration;
using ImageBeautifier.WebApi.Models;
using ImageBeautifier.WebApi.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace ImageBeautifier.WebApi.Services;

internal sealed class MessageClient : IMessageClient
{
    private readonly IAmazonSQS _amazonSqs;
    private readonly AWSEnvironmentOptions _awsEnvironmentOptions;

    public MessageClient(IAmazonSQS amazonSqs, IOptions<AWSEnvironmentOptions> awsEnvironmentOptions)
    {
        _amazonSqs = amazonSqs;
        _awsEnvironmentOptions = awsEnvironmentOptions.Value;
    }

    public async Task SendMessageAsync(BeautifierTask beautifierTask, CancellationToken cancellationToken)
    {
        var request = new SendMessageRequest
        {
            QueueUrl = _awsEnvironmentOptions.QueueUrl,
            MessageBody = JsonSerializer.Serialize(beautifierTask)
        };
        await _amazonSqs.SendMessageAsync(request, cancellationToken);
    }
}