using Market.Application.Modules.Identity.UserRoles.Commands.Create;
using Market.Application.Modules.Identity.UserRoles.Commands.Delete;
using Market.Application.Modules.Identity.UserRoles.Queries.GetUserRoles;
using Market.Application.Modules.Identity.UserRoles.Queries.GetUsersByRole;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class UserRolesController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(AssignRoleToUserCommand command, CancellationToken ct)
    {
        await sender.Send(command, ct);
        return Ok();
    }

    [HttpDelete("{userId:int}/{roleId:int}")]
    public async Task<IActionResult> Delete(int userId, int roleId, CancellationToken ct)
    {
        await sender.Send(new RemoveRoleFromUserCommand
        {
            UserId = userId,
            RoleId = roleId
        }, ct);

        return NoContent();
    }

    [HttpGet("{userId:int}/roles")]
    public async Task<ActionResult<GetUserRolesQueryDto>> GetUserRolesById(int userId, CancellationToken ct)
    {
        var result = await sender.Send(new GetUserRolesQuery { UserId = userId }, ct);
        return Ok(result);
    }

    [HttpGet("roles/{roleId:int}/users")]
    public async Task<ActionResult<GetUsersByRoleQueryDto>> GetUsersByRole(int roleId, CancellationToken ct)
    {
        var result = await sender.Send(new GetUsersByRoleQuery { RoleId = roleId }, ct);
        return Ok(result);
    }
}