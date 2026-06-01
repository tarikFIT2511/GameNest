namespace Market.Application.Modules.Catalog.Reviews.Queries.GetById;

public class GetReviewByIdQueryDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public GetReviewByIdUserDto? User { get; set; }
}

public class GetReviewByIdUserDto
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public GetReviewByIdQueryUserProfileDto? Profile { get; set; }
}

public class GetReviewByIdQueryUserProfileDto
{
    public string? AvatarUrl { get; set; }
}