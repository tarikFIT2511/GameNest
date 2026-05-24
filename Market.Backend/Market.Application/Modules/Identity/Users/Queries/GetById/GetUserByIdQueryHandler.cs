using Market.Application.Modules.Identity.Users.Queries.GetById;

namespace Market.Application.ModulesIdentity.Users.Queries.GetById;

public class GetUserByIdQueryHandler(IAppDbContext context) : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryDto>
{
    public async Task<GetUserByIdQueryDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Where(c => c.Id == request.Id)
            .Select(x => new GetUserByIdQueryDto
            {
                Id = x.Id,
                Username = x.Username,
                Email = x.Email,
                CreatedAtUtc = x.CreatedAtUtc,
                IsEnabled = x.IsEnabled
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null)
        {
            throw new MarketNotFoundException($"User with Id {request.Id} not found.");
        }

        return user;
    }
}