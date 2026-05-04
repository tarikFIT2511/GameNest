namespace Market.Shared.Dtos;

public sealed class ErrorDto
{
    public required string Code { get; init; }     // e.g. "internal.error"
    public required string Message { get; init; }  // short message
}