namespace Market.Application.Modules.Identity.ModerationActions.Queries.GetById;

public class GetModerationActionByIdQuery : IRequest<GetModerationActionByIdQueryDto>
{
    public int Id { get; set; }
}