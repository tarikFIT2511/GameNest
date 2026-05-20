namespace Market.Application.Modules.Identity.Users.Commands.Create;

public class CreateUserCommandHandler(IAppDbContext context)
    : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var username = request.Username?.Trim();
        var email = request.Email?.Trim();
        var password = request.Password?.Trim(); //warning: needs password hash implementation

        if (string.IsNullOrWhiteSpace(username))
            throw new ValidationException("Username is required.");

        if (string.IsNullOrWhiteSpace(email))
            throw new ValidationException("Username is required.");

        if (string.IsNullOrWhiteSpace(password))
            throw new ValidationException("Username is required.");

        // Check if a user with the same name or email already exists.
        bool usernameExists = await context.Users
            .AnyAsync(x => x.Username == username, cancellationToken);
        bool emailExists = await context.Users
            .AnyAsync(x => x.Email == email, cancellationToken);

        if (usernameExists)
        {
            throw new MarketConflictException("Username already exists.");
        }
        if (emailExists)
        {
            throw new MarketConflictException("Email already exists.");
        }

        var user = new UserEntity
        {
            Username = username!,
            Email = email!,
            PasswordHash = password,//TEMPORARILY until hashing is implemented
            IsEnabled = true, // default IsEnabled
            CreatedAtUtc = DateTime.UtcNow
        };

        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}