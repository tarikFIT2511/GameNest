using Market.Domain.Enums;

namespace Market.Application.Modules.Identity.Users.Commands.Create;

public class CreateUserCommand : IRequest<int>
{
    public required string Email { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required Country Country { get; set; }
}