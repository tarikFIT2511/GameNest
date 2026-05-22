namespace Market.Application.Modules.Identity.UserProfiles.Queries.GetById;

public class GetUserProfileSummaryByIdQueryDto
{
    public required int Id { get; init; }
    public required string Username { get; init; }
    public required string AvatarUrl { get; init; }
}
