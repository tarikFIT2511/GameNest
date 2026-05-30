using Market.Application.Modules.Identity.Users.Commands.Status.Enable;
using Market.Application.Modules.Identity.Users.Commands.Update;
using Market.Application.Modules.Identity.Users.Commands.Create;
using Market.Application.Modules.Identity.Users.Commands.Delete;
using Market.Application.Modules.Identity.Users.Commands.Status.Disable;
using Market.Application.Modules.Identity.Users.Queries.GetById;
using Market.Application.Modules.Identity.Users.Queries.List;
using Market.Application.Modules.Identity.UserRoles.Commands.Create;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost] 
    public async Task<ActionResult<int>> CreateUser(CreateUserCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return Ok(id);
    }

    [HttpPut("{id:int}/username")]
    public async Task UpdateUsername(int id, UpdateUsernameCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }

    [HttpPut("{id:int}/email")]
    public async Task UpdateEmail(int id, UpdateUserEmailCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteUserCommand { Id = id }, ct);
    }

    [HttpGet("{id:int}")]
    public async Task<GetUserByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var user = await sender.Send(new GetUserByIdQuery { Id = id }, ct);
        return user; // if NotFoundException -> 404 via middleware
    }

    [HttpGet("/UsersList")]
    public async Task<PageResult<ListUsersQueryDto>> List([FromQuery] ListUsersQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpPut("{id:int}/disable")]
    public async Task Disable(int id, CancellationToken ct)
    {
        await sender.Send(new DisableUserCommand { Id = id }, ct);
    }

    [HttpPut("{id:int}/enable")]
    public async Task Enable(int id, CancellationToken ct)
    {
        await sender.Send(new EnableUserCommand { Id = id }, ct);
    }
}