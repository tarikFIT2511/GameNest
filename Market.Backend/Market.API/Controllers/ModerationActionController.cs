using Market.Application.Modules.Identity.ModerationActions.Commands.Create;
using Market.Application.Modules.Identity.ModerationActions.Queries.GetById;
using Market.Application.Modules.Identity.ModerationActions.Queries.List;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class ModerationActionController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CreateModerationAction(CreateModerationActionCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return Ok(id);
    }

    [HttpGet("{id:int}")]
    public async Task<GetModerationActionByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var moderationAction = await sender.Send(new GetModerationActionByIdQuery { Id = id }, ct);
        return moderationAction; // if NotFoundException -> 404 via middleware
    }

    [HttpGet]
    public async Task<PageResult<ListModerationActionsQueryDto>> List([FromQuery] ListModerationActionsQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }
}