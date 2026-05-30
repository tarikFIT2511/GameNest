namespace Market.Application.Modules.Identity.UserRoles.Queries.GetUsersByRole;

public sealed class GetUsersByRoleQueryDto
{
    public required int RoleId { get; init; }
    public required string Name { get; init; }
    public List<UserDto> Users { get; init; } = new();
}

public sealed class UserDto
{
    public required string Username { get; init; }
}