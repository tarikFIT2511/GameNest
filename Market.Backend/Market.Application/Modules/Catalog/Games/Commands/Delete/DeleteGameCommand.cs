namespace Market.Application.Modules.Catalog.Games.Commands.Delete;

public class DeleteGameCommand : IRequest<Unit>
{
    public int Id { get; set; }
 
}
