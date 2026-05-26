using Market.Domain.Enums;

namespace Market.Application.Modules.Identity.UserProfiles.Queries.List;

public sealed class ListUserProfilesQueryDto
{
    public required int Id { get; init; }
    public required string Username { get; init; }
    public required string AvatarUrl { get; init; }
    public required Country Country { get; init; }
}
