namespace Market.Application.Modules.Identity.UserRoles.Queries.GetUsersByRole;

public class GetUsersByRoleQueryHandler(IAppDbContext ctx) : IRequestHandler<GetUsersByRoleQuery, GetUsersByRoleQueryDto>
{
    public async Task<GetUsersByRoleQueryDto> Handle(GetUsersByRoleQuery request, CancellationToken ct)
    {
        var role = await ctx.Roles.Where(x => x.Id == request.RoleId)
            .Select(x => new GetUsersByRoleQueryDto
            {
                RoleId = x.Id,
                Name = x.Name,
                Users = x.UserRoles.Select(r => new UserDto
                {
                    Username = r.User.Username
                }).ToList()
            }).FirstOrDefaultAsync(ct);

        if(role is null)
        {
            throw new MarketNotFoundException("Role does not exist.");
        }

        return role;
    }
}