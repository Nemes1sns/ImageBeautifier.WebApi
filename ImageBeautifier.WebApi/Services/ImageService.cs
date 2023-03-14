using Amazon.DynamoDBv2.DataModel;
using ImageBeautifier.WebApi.Models;
using ImageBeautifier.WebApi.Models.Response;
using ImageBeautifier.WebApi.Services.Interfaces;

namespace ImageBeautifier.WebApi.Services;

internal sealed class ImageService : IImageService
{
    private readonly IDynamoDBContext _context;
    private readonly IImageStorage _imageStorage;
    private readonly IMessageClient _messageClient;

    public ImageService(
        IDynamoDBContext context, 
        IImageStorage imageStorage,
        IMessageClient messageClient)
    {
        _context = context;
        _imageStorage = imageStorage;
        _messageClient = messageClient;
    }
    
    public async Task<Guid> UploadImageAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var path = await _imageStorage.UploadImageAsync(file, cancellationToken);
        var task = new BeautifierTask
        {
            Id = Guid.NewGuid(),
            State = BeautifierTaskState.Created,
            FileName = file.FileName,
            OriginalFilePath = path
        };
        await _context.SaveAsync(task, cancellationToken);
        await _messageClient.SendMessageAsync(task, cancellationToken);
        return task.Id;
    }

    public async Task<GetBeautifiedImageResponse> GetCurrentStateAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _context.LoadAsync<BeautifierTask>(id, cancellationToken);
        if (task == null)
        {
            throw new InvalidOperationException();
        }

        var imageUrl = !string.IsNullOrEmpty(task.FinishedFilePath)
            ? _imageStorage.GetPublicUrl(task.FinishedFilePath)
            : null;
        return new(task.State, imageUrl);
    }
}