using Market.Domain.Enums;

namespace Market.Application.Modules.Identity.UserProfiles.Queries.GetById;

public class GetUserProfileByIdQueryDto
{
    public int Id { get; init; }
    public required string Username { get; init; }
    public required string AvatarUrl { get; init; }
    public required Country Country { get; init; }
    public required string Bio { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
}
