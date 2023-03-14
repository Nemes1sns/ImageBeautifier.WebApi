namespace ImageBeautifier.WebApi.Models.Response;

public sealed record GetBeautifiedImageResponse(BeautifierTaskState State, string? Path);