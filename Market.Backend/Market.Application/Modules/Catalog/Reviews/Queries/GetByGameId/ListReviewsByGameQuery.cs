namespace Market.Application.Modules.Catalog.Reviews.Queries.GetByGameId;

public sealed class ListReviewsByGameQuery : BasePagedQuery<ListReviewsByGameQueryDto>
{
    public int GameId { get; set; }
}
