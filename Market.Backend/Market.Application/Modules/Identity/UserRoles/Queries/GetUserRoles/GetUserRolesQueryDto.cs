namespace Market.Application.Modules.Identity.UserRoles.Queries.GetUserRoles;

public class GetUserRolesQueryDto
{
    public required int UserId { get; init; }
    public required string Username { get; init; }
    public List<RoleDto> Roles { get; init; } = new();
}

public sealed class RoleDto
{
    public required string Name { get; init; }
}
