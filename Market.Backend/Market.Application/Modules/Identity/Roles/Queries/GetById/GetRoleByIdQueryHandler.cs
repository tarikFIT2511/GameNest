namespace Market.Application.Modules.Identity.Roles.Queries.GetById;

public class GetRoleByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetRoleByIdQuery, GetRoleByIdQueryDto>
{
    public async Task<GetRoleByIdQueryDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var role = await context.Roles
            .Where(c => c.Id == request.Id)
            .Select(x => new GetRoleByIdQueryDto
            {
                Id = x.Id,
                Name = x.Name
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (role == null)
        {
            throw new MarketNotFoundException($"Role with Id {request.Id} not found.");
        }

        return role;
    }
}