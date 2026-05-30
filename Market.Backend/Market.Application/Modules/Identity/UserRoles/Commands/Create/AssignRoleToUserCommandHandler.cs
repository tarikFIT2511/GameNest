namespace Market.Application.Modules.Identity.UserRoles.Commands.Create;

public class AssignRoleToUserCommandHandler(IAppDbContext ctx)
    : IRequestHandler<AssignRoleToUserCommand>
{
    public async Task Handle(AssignRoleToUserCommand request, CancellationToken ct)
    {
        // Check if a user exists.
        bool userExists = await ctx.Users
            .AnyAsync(x => x.Id == request.UserId, ct);
        // Check if a role exists.
        bool roleExists = await ctx.Roles
            .AnyAsync(x => x.Id == request.RoleId, ct);

        if (!userExists)
        {
            throw new MarketNotFoundException("User does not exist.");
        }
        if (!roleExists)
        {
            throw new MarketNotFoundException("Role does not exist.");
        }

        //check if relation already exists
        bool relationExists = await ctx.UserRoles
            .AnyAsync(x => x.UserId == request.UserId && x.RoleId == request.RoleId, ct);

        if (relationExists)
        {
            throw new MarketConflictException("User already has this role");
        }

        var userRole = new UserRoleEntity
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };

        ctx.UserRoles.Add(userRole);
        await ctx.SaveChangesAsync(ct);
    }
}