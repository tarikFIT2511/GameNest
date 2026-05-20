using Market.Application.Modules.Catalog.ProductCategories.Commands.Delete;
using Market.Application.Modules.Catalog.ProductCategories.Commands.Status.Disable;
using Market.Application.Modules.Catalog.ProductCategories.Commands.Status.Enable;
using Market.Application.Modules.Catalog.ProductCategories.Commands.Create;
using Market.Application.Modules.Catalog.ProductCategories.Commands.Update;
using Market.Application.Modules.Catalog.ProductCategories.Queries.GetById;
using Market.Application.Modules.Catalog.ProductCategories.Queries.List;
using Market.Application.Modules.Identity.Users.Commands.Create;
using Market.Application.Modules.Identity.Users.Commands.Delete;
using Market.Application.Modules.Identity.User.Commands.Status.Disable;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost]  //tested successfully
    public async Task<ActionResult<int>> CreateUser(CreateUserCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return Ok(id);
    }

    [HttpPut("{id:int}")] //not finished
    public async Task Update(int id, UpdateUsernameCommand command, CancellationToken ct)
    {
        // ID from the route takes precedence
        command.Id = id;
        await sender.Send(command, ct);
        // no return -> 204 No Content
    }

    [HttpDelete("{id:int}")] //tested successfully
    public async Task Delete(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteUserCommand { Id = id }, ct);
    }

    [HttpPut("{id:int}/disable")] //tested successfully
    public async Task Disable(int id, CancellationToken ct)
    {
        await sender.Send(new DisableUserCommand { Id = id }, ct);
        // no return -> 204 No Content
    }

    [HttpPut("{id:int}/enable")] //tested successfully
    public async Task Enable(int id, CancellationToken ct)
    {
        await sender.Send(new EnableUserCommand { Id = id }, ct);
        // no return -> 204 No Content
    }
}