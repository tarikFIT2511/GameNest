namespace Market.Application.Modules.Identity.Users.Commands.Update;

public sealed class UpdateUserEmailCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public required string Email { get; set; }
    //implement password change later but in seperate ChangePasswordCommand
}
