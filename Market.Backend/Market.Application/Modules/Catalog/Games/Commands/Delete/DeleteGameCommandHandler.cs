namespace Market.Application.Modules.Catalog.Games.Commands.Delete;

public class DeleteGameCommandHandler(IAppDbContext context )
      : IRequestHandler<DeleteGameCommand, Unit>
{
    public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await context.Games
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (game is null)
            throw new MarketNotFoundException("Game not found");


        game.IsDeleted = true; // Soft delete
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
