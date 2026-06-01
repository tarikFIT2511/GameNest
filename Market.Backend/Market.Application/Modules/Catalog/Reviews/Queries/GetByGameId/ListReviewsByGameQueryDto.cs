namespace Market.Application.Modules.Catalog.Reviews.Queries.GetByGameId;

public class ListReviewsByGameQueryDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public ListReviewsByGameQueryUserDto? User { get; set; }
}

public class ListReviewsByGameQueryUserDto
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public ListReviewsByGameQueryUserProfileDto? Profile { get; set; }
}

public class ListReviewsByGameQueryUserProfileDto
{
    public string? AvatarUrl { get; set; }
}