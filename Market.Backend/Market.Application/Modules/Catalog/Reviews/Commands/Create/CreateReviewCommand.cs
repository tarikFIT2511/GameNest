namespace Market.Application.Modules.Catalog.Reviews.Commands.Create;

public class CreateReviewCommand : IRequest<int>
{
    public int UserId { get; set; }
    public int GameId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}