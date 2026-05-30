using Market.Application.Modules.Identity.Roles.Queries.GetById;
using Market.Application.Modules.Identity.Roles.Queries.List;
namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class RoleController(ISender sender) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<GetRoleByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var role = await sender.Send(new GetRoleByIdQuery { Id = id }, ct);
        return role; // if NotFoundException -> 404 via middleware
    }

    [HttpGet("/RolesList")]
    public async Task<PageResult<ListRolesQueryDto>> List([FromQuery] ListRolesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }
}