namespace ImageBeautifier.WebApi.Infrastructure.Exceptions;

internal sealed class NotFoundException : Exception
{
    public NotFoundException(string message) 
        : base(message)
    {
    }
}