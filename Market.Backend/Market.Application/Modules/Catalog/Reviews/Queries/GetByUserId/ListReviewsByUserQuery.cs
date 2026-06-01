namespace Market.Application.Modules.Catalog.Reviews.Queries.GetByUserId;

public sealed class ListReviewsByUserQuery : BasePagedQuery<ListReviewsByUserQueryDto>
{
    public int UserId { get; set; }
}
