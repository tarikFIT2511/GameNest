namespace Market.Application.Modules.Identity.Roles.Queries.GetById;

public class GetRoleByIdQuery : IRequest<GetRoleByIdQueryDto>
{
    public int Id { get; set; }
}