namespace Market.Application.Modules.Identity.Users.Queries.GetById;

public class GetUserByIdQueryDto
{
    public required int Id { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
    public required bool IsEnabled { get; init; }
}
