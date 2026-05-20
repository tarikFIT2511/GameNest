namespace Market.Application.Modules.Identity.Users.Commands.Delete;

public class DeleteUserCommandHandler(IAppDbContext context)
      : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user is null)
            throw new MarketNotFoundException("User not found.");

        if (user.IsDeleted)
            throw new MarketConflictException("User is already deleted.");

        user.IsDeleted = true; // Soft delete
        user.ModifiedAtUtc = DateTime.UtcNow;
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
