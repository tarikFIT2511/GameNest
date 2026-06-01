namespace Market.Application.Modules.Catalog.Games.Commands.Status.Disable;

public sealed class DisableGameCommand : IRequest<Unit>
{
    public required int Id { get; set; }

}
