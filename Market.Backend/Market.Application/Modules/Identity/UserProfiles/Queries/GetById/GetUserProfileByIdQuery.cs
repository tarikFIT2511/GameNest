namespace Market.Application.Modules.Identity.UserProfiles.Queries.GetById;

public class GetUserProfileByIdQuery : IRequest<GetUserProfileByIdQueryDto>
{
    public int Id { get; set; }
    public ProfileViewType Type { get; set; }
}