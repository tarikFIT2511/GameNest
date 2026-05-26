using Market.Application.Modules.Identity.UserProfiles.Commands.Update;
using Market.Application.Modules.Identity.UserProfiles.Queries.GetById;
using Market.Application.Modules.Identity.UserProfiles.Queries.List;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class UserProfileController(ISender sender) : ControllerBase
{
    [HttpPut("{id:int}")]
    public async Task UpdateUserProfile(int id, UpdateUserProfileCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }

    [HttpGet("{id:int}")]
    public async Task<object> GetUserProfileById(int id, [FromQuery] ProfileViewType type, CancellationToken ct)
    {
        var result = await sender.Send(new GetUserProfileByIdQuery
        {
            Id = id,
            Type = type
        }, ct);

        return result;
    }

    [HttpGet("/UserProfileList")]
    public async Task<PageResult<ListUserProfilesQueryDto>> List([FromQuery] ListUserProfilesQuery query, CancellationToken ct)
    {
        var result = await sender.Send(query, ct);
        return result;
    }
}