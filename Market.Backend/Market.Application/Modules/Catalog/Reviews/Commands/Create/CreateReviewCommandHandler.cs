namespace Market.Application.Modules.Catalog.Reviews.Commands.Create;

public class CreateReviewCommandHandler(IAppDbContext ctx)
    : IRequestHandler<CreateReviewCommand, int>
{
    public async Task<int> Handle(CreateReviewCommand request, CancellationToken ct)
    {
        var user = await ctx.Users
            .Where(r => r.Id == request.UserId)
            .FirstOrDefaultAsync(ct);

        if(user is null)
        {
            throw new MarketNotFoundException("User not found.");
        }

        var game = await ctx.Games
            .Where(r => r.Id == request.GameId)
            .FirstOrDefaultAsync(ct);

        if (game is null)
        {
            throw new MarketNotFoundException("Game not found.");
        }

        bool exists = await ctx.Reviews
            .Where(r => r.UserId == request.UserId && r.GameId == request.GameId)
            .AnyAsync(ct);

        if (exists)
        {
            throw new MarketConflictException("User already has a review on this game.");
        }

        if (request.Rating < 1 || request.Rating > 5)
        {
            throw new MarketBusinessRuleException("100", "Rating must be between 1 and 5.");
        }

        var review = new ReviewEntity
        {
            UserId = user.Id,
            GameId = game.Id,
            Rating = request.Rating,
            Comment = request.Comment?.Trim() ?? ""
        };

        ctx.Reviews.Add(review);
        await ctx.SaveChangesAsync(ct);

        return review.Id;
    }
}