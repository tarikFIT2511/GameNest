namespace Market.Application.Modules.Identity.Users.Queries.List;

public sealed class ListUsersQueryDto
{
    public required int Id { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
    public required bool IsEnabled { get; init; }
}
