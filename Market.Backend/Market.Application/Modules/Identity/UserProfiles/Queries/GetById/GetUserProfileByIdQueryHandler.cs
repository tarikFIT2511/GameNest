using Market.Domain.Enums;

namespace Market.Application.Modules.Identity.UserProfiles.Queries.GetById;

public class GetUserProfileByIdQueryHandler(IAppDbContext context)
    : IRequestHandler<GetUserProfileByIdQuery, object>
{
    public async Task<object> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(x => x.Profile)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user == null)
            throw new MarketNotFoundException($"User with Id {request.Id} not found.");

        if (user.Profile == null)
        {
            throw new MarketNotFoundException($"Profile missing");
        }

        object dto;

        switch (request.Type)
        {
            case ProfileViewType.Full:
                dto = new GetUserProfileByIdQueryDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    AvatarUrl = user.Profile.AvatarUrl ?? "",
                    Country = user.Profile.Country,
                    Bio = user.Profile.Bio ?? "",
                    CreatedAtUtc = user.CreatedAtUtc
                };
                break;

            case ProfileViewType.MyProfile:
                dto = new GetMyProfileQueryDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    AvatarUrl = user.Profile.AvatarUrl ?? "",
                    Country = user.Profile.Country,
                    Bio = user.Profile.Bio ?? "",
                    CreatedAtUtc = user.CreatedAtUtc
                };
                break;

            case ProfileViewType.Summary:
                dto = new GetUserProfileSummaryByIdQueryDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    AvatarUrl = user.Profile.AvatarUrl ?? ""
                };
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(request.Type));
        }

        return dto;
    }
}