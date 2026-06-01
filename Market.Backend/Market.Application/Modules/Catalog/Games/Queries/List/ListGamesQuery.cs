namespace Market.Application.Modules.Catalog.Games.Queries.List;

public sealed class ListGamesQuery : BasePagedQuery<ListGamesQueryDto>
{
    public string? Search { get; init; }
    public bool? OnlyEnabled { get; init; }
}
