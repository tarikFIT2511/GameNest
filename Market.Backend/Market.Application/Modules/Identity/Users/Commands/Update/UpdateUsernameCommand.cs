namespace Market.Application.Modules.Identity.Users.Commands.Update;

public sealed class UpdateUsernameCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public required string Username { get; set; }
    //implement password change later but in seperate ChangePasswordCommand
}
