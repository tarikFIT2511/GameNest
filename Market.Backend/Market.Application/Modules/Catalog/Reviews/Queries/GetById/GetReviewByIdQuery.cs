namespace Market.Application.Modules.Catalog.Reviews.Queries.GetById;

public class GetReviewByIdQuery : IRequest<GetReviewByIdQueryDto>
{
    public int Id { get; set; }
}