namespace Market.Application.Modules.Identity.Users.Queries.GetById;

public class GetUserByIdQuery : IRequest<GetUserByIdQueryDto>
{
    public int Id { get; set; }
}