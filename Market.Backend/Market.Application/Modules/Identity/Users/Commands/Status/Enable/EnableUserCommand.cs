namespace Market.Application.Modules.Identity.Users.Commands.Status.Enable;

public sealed class EnableUserCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
