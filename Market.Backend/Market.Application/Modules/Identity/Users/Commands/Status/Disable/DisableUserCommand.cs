namespace Market.Application.Modules.Identity.User.Commands.Status.Disable;

public sealed class DisableUserCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
