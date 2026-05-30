namespace Market.Application.Modules.Identity.UserRoles.Commands.Delete;

public class RemoveRoleFromUserCommand : IRequest<Unit>
{
    public required int UserId { get; set; }
    public required int RoleId { get; set; }
}
