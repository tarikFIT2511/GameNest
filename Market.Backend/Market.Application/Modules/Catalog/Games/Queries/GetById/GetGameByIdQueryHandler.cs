namespace Market.Application.Modules.Catalog.Games.Queries.GetById;

public class GetGameByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetGameByIdQuery, GetGameByIdQueryDto>
{
    public async Task<GetGameByIdQueryDto> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await context.Games
            .Where(c => c.Id == request.Id)
            .Select(x => new GetGameByIdQueryDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Price = x.Price,
                ReleaseDate = x.ReleaseDate,
                CoverImageUrl = x.CoverImageUrl,
                AverageRating = x.AverageRating //Implement average rating system

            })
            .FirstOrDefaultAsync(cancellationToken);

        if (category == null)
        {
            throw new MarketNotFoundException($"Game with Id {request.Id} not found.");
        }

        return category;
    }
}