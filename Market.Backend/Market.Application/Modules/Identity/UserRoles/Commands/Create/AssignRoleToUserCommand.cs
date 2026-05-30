namespace Market.Application.Modules.Identity.UserRoles.Commands.Create;

public class AssignRoleToUserCommand : IRequest
{
    public required int UserId { get; set; }
    public required int RoleId { get; set; }
}