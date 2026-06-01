namespace Market.Application.Modules.Catalog.Games.Commands.Create;

public class CreateGameCommand : IRequest<int>
{
    public required string Title { get; set; }
    public string Description { get; set; }
    public required decimal Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public string CoverImageUrl { get; set; }
}