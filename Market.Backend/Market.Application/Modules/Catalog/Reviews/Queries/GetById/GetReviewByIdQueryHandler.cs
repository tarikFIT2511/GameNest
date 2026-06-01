namespace Market.Application.Modules.Catalog.Reviews.Queries.GetById;

public class GetReviewByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetReviewByIdQuery, GetReviewByIdQueryDto>
{
    public async Task<GetReviewByIdQueryDto> Handle(GetReviewByIdQuery request, CancellationToken ct)
    {
        var review = await context.Reviews
            .Where(c => c.Id == request.Id)
            .Select(x => new GetReviewByIdQueryDto
            {
                Id = x.Id,
                Rating = x.Rating,
                Comment = x.Comment,
                User = new GetReviewByIdUserDto
                {
                    Id = x.UserId,
                    Username = x.User.Username,
                    Profile = new GetReviewByIdQueryUserProfileDto
                    {
                        AvatarUrl = x.User.Profile.AvatarUrl
                    }
                }
            })
            .FirstOrDefaultAsync(ct);

        if (review == null)
        {
            throw new MarketNotFoundException($"Review with Id {request.Id} not found.");
        }

        return review;
    }
}