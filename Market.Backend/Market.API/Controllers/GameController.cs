using Market.Application.Modules.Catalog.Games.Commands.Create;
using Market.Application.Modules.Catalog.Games.Commands.Delete;
using Market.Application.Modules.Catalog.Games.Commands.Status.Disable;
using Market.Application.Modules.Catalog.Games.Commands.Status.Enable;
using Market.Application.Modules.Catalog.Games.Commands.Update;
using Market.Application.Modules.Catalog.Games.Queries.GetById;
using Market.Application.Modules.Catalog.Games.Queries.List;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class GameController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CreateGame(CreateGameCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task UpdateGame(int id, UpdateGameCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }


    [HttpDelete("{id:int}")]
    public async Task Delete(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteGameCommand { Id = id }, ct);
    }

    [HttpGet("{id:int}")]
    public async Task<GetGameByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var user = await sender.Send(new GetGameByIdQuery { Id = id }, ct);
        return user; // if NotFoundException -> 404 via middleware
    }

    [HttpGet("/GamesList")]
    public async Task<PageResult<ListGamesQueryDto>> List([FromQuery] ListGamesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }

    [HttpPut("{id:int}/disable")]
    public async Task Disable(int id, CancellationToken ct)
    {
        await sender.Send(new DisableGameCommand { Id = id }, ct);
    }

    [HttpPut("{id:int}/enable")]
    public async Task Enable(int id, CancellationToken ct)  
    {
        await sender.Send(new EnableGameCommand { Id = id }, ct);
    }
}