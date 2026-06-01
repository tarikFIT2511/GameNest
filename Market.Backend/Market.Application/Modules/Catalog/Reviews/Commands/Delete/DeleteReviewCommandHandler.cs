namespace Market.Application.Modules.Catalog.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler(IAppDbContext ctx)
      : IRequestHandler<DeleteReviewCommand, Unit>
{
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken ct)
    {
        var review = await ctx.Reviews
            .Where(r => r.Id == request.Id)
            .FirstOrDefaultAsync(ct);

        if (review is null)
        {
            throw new MarketNotFoundException("Review not found.");
        }

        review.IsDeleted = true;
        await ctx.SaveChangesAsync(ct);
        return Unit.Value;
    }
}
