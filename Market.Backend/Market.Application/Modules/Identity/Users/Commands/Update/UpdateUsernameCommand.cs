namespace Market.Application.Modules.Catalog.ProductCategories.Commands.Update;

public sealed class UpdateUsernameCommand : IRequest<Unit>
{
    [JsonIgnore]
    public required int Id { get; set; }
    public required string Username { get; set; }
    //implement password change later but in seperate ChangePasswordCommand
}
