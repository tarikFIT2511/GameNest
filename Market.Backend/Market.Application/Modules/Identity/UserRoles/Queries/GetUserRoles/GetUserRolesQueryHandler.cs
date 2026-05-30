namespace Market.Application.Modules.Identity.UserRoles.Queries.GetUserRoles;

public class GetUserRolesQueryHandler(IAppDbContext ctx) : IRequestHandler<GetUserRolesQuery, GetUserRolesQueryDto>
{
    public async Task<GetUserRolesQueryDto> Handle(GetUserRolesQuery request, CancellationToken ct)
    {
        var user = await ctx.Users.Where(x => x.Id == request.UserId)
            .Select(x => new GetUserRolesQueryDto
            {
                UserId = x.Id,
                Username = x.Username,
                Roles = x.UserRoles.Select(ur => new RoleDto
                {
                    Name = ur.Role.Name
                }).ToList()
            }).FirstOrDefaultAsync(ct);

        if(user is null)
        {
            throw new MarketNotFoundException("User does not exist.");
        }

        return user;
    }
}