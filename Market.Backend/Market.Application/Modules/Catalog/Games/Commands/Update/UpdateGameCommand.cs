namespace Market.Application.Modules.Catalog.Games.Commands.Update;

public sealed class UpdateGameCommand : IRequest<Unit>
{
    [JsonIgnore]
    public required  int Id { get; set; }
    public required  string Title { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required string CoverImageUrl { get; set; }
}
