namespace Market.Application.Modules.Catalog.Reviews.Commands.Update;

public sealed class UpdateReviewCommandHandler(IAppDbContext ctx)
            : IRequestHandler<UpdateReviewCommand, Unit>
{
    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken ct)
    {
        var review = await ctx.Reviews
            .FirstOrDefaultAsync(x => x.Id == request.Id, ct);

        if (review is null)
            throw new MarketNotFoundException("Review not found.");

        if (request.Rating < 1 || request.Rating > 5)
        {
            throw new MarketBusinessRuleException("100", "Rating must be between 1 and 5.");
        }

        review.Rating = request.Rating;
        if (request.Comment != null) 
            review.Comment = request.Comment.Trim();

        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}