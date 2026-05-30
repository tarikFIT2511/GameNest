namespace Market.Application.Modules.Identity.UserRoles.Commands.Delete;

public class RemoveRoleFromUserCommandHandler(IAppDbContext ctx)
      : IRequestHandler<RemoveRoleFromUserCommand, Unit>
{
    public async Task<Unit> Handle(RemoveRoleFromUserCommand request, CancellationToken ct)
    {
        var userRole = await ctx.UserRoles
            .FirstOrDefaultAsync(x => x.UserId == request.UserId && x.RoleId == request.RoleId, ct);

        if (userRole is null)
        {
            throw new MarketNotFoundException("User does not have this role.");
        }

        userRole.IsDeleted = true; // Soft delete

        userRole.ModifiedAtUtc = DateTime.UtcNow;
        await ctx.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
