using Market.Domain.Enums;

namespace Market.Application.Modules.Identity.UserProfiles.Commands.Update;

public sealed class UpdateUserProfileCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public required Country Country { get; set; }
    public required string AvatarUrl { get; set; }
    public required string Bio { get; set; }
}
