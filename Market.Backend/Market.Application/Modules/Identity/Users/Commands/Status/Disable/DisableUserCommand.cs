namespace Market.Application.Modules.Identity.Users.Commands.Status.Disable;

public sealed class DisableUserCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
