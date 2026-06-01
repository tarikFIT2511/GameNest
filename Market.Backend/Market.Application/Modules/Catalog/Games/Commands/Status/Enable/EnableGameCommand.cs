namespace Market.Application.Modules.Catalog.Games.Commands.Status.Enable;

public sealed class EnableGameCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
