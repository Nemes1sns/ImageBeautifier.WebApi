using ImageBeautifier.WebApi.Models;

namespace ImageBeautifier.WebApi.Services.Interfaces;

internal interface IMessageClient
{
    Task SendMessageAsync(BeautifierTask beautifierTask, CancellationToken cancellationToken);
}