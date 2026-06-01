namespace Market.Application.Modules.Catalog.Games.Queries.GetById;

public class GetGameByIdQuery : IRequest<GetGameByIdQueryDto>
{
    public int Id { get; set; }
}