namespace Market.Application.Modules.Identity.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
