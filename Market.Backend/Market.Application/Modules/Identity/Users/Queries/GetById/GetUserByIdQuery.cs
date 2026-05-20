namespace Market.Application.Modules.Catalog.ProductCategories.Queries.GetById;

public class GetUserByIdQuery : IRequest<GetProductCategoryByIdQueryDto>
{
    public int Id { get; set; }
}