namespace Market.Application.Modules.Catalog.Games.Commands.Create;

public class CreateGameCommandHandler(IAppDbContext context)
    : IRequestHandler<CreateGameCommand, int>
{
    public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var normalized = request.Title?.Trim();

        if (string.IsNullOrWhiteSpace(normalized))
            throw new ValidationException("Title is required.");

        // Check if game with the same name already exists.
        bool exists = await context.Games
            .AnyAsync(x => x.Title == normalized, cancellationToken);

        if (exists)
        {
            throw new MarketConflictException("Title already exists.");
        }

        var game = new GameEntity
        {
            Title = request.Title!.Trim(),
            Description = request.Description?.Trim(),
            Price = request.Price,
            ReleaseDate = request.ReleaseDate,
            CoverImageUrl = request.CoverImageUrl?.Trim(),
            AverageRating = 0, // default AverageRating
            CreatedAtUtc = DateTime.UtcNow,
            IsEnabled = true // deault IsEnabled
        };

        context.Games.Add(game);
        await context.SaveChangesAsync(cancellationToken);

        return game.Id;
    }
}