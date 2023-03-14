using System.Net;
using ImageBeautifier.WebApi.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImageBeautifier.WebApi.Infrastructure.Filters;

internal sealed class GlobalExceptionFilter : IExceptionFilter
{
    private readonly ILogger<GlobalExceptionFilter> _logger;

    public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        var exception = context.Exception;
        _logger.LogError(exception, exception.Message);
        
        if (exception is NotFoundException e)
        {
            context.Result = new JsonResult(e.Message)
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
    }
}