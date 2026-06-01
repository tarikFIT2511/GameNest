using Market.Application.Modules.Catalog.Reviews.Commands.Create;
using Market.Application.Modules.Catalog.Reviews.Commands.Delete;
using Market.Application.Modules.Catalog.Reviews.Commands.Update;
using Market.Application.Modules.Catalog.Reviews.Queries.GetByGameId;
using Market.Application.Modules.Catalog.Reviews.Queries.GetById;
using Market.Application.Modules.Catalog.Reviews.Queries.GetByUserId;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class ReviewController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateReviewCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task Update(int id, UpdateReviewCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteReviewCommand { Id = id }, ct);
    }

    [HttpGet("{id:int}")]
    public async Task<GetReviewByIdQueryDto> GetById(int id, CancellationToken ct)
    {
        var review = await sender.Send(new GetReviewByIdQuery { Id = id }, ct);
        return review;
    }

    [HttpGet("game/{GameId:int}")]
    public async Task<PageResult<ListReviewsByGameQueryDto>> ListByGameId(int GameId, CancellationToken ct)
    {
        var review = await sender.Send(new ListReviewsByGameQuery { GameId = GameId }, ct);
        return review;
    }

    [HttpGet("user/{UserId:int}")]
    public async Task<PageResult<ListReviewsByUserQueryDto>> ListByUserId(int UserId, CancellationToken ct)
    {
        var review = await sender.Send(new ListReviewsByUserQuery { UserId = UserId }, ct);
        return review;
    }

}