namespace Market.Application.Modules.Identity.UserRoles.Queries.GetUserRoles;

public class GetUserRolesQuery : IRequest<GetUserRolesQueryDto>
{
    public int UserId { get; set; }
}