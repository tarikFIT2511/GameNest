namespace Market.Application.Modules.Catalog.Games.Queries.GetById;

public class GetGameByIdQueryDto
{
    public required int Id { get; init; }
    public required string Title { get; set; }
    public required string? Description { get; set; }
    public required decimal Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required string? CoverImageUrl { get; set; }
    public required decimal AverageRating { get; set; }

}
