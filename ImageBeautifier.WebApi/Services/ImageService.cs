using Amazon.DynamoDBv2.DataModel;
using ImageBeautifier.WebApi.Models;
using ImageBeautifier.WebApi.Services.Interfaces;

namespace ImageBeautifier.WebApi.Services;

internal sealed class ImageService : IImageService
{
    private readonly IDynamoDBContext _context;

    public ImageService(IDynamoDBContext context)
    {
        _context = context;
    }
    
    public async Task<Guid> UploadImageAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var task = new BeautifierTask
        {
            Id = Guid.NewGuid(),
            State = BeautifierTaskState.Created,
            FileName = file.FileName,
            OriginalFilePath = "path"
            
        };
        await _context.SaveAsync(task, cancellationToken);
        return task.Id;
    }

    public async Task<BeautifierTaskState> GetCurrentStateAsync(Guid id, CancellationToken cancellationToken)
    {
        var task = await _context.LoadAsync<BeautifierTask>(id, cancellationToken);
        if (task == null)
        {
            throw new InvalidOperationException();
        }
        
        return task.State;
    }
}