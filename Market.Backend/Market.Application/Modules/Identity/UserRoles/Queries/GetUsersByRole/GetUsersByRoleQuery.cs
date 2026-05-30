namespace Market.Application.Modules.Identity.UserRoles.Queries.GetUsersByRole;

public class GetUsersByRoleQuery : IRequest<GetUsersByRoleQueryDto>
{
    public int RoleId { get; set; }
}