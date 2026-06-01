namespace Market.Application.Modules.Catalog.Games.Queries.List;

public sealed class ListGamesQueryDto
{
    public required int Id { get; init; }
    public required string Title { get; init; }
    public required decimal Price  { get; init; }
    public required string CoverImageUrl { get; init; }
}
