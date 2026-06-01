using Market.Application.Modules.Catalog.Reviews.Queries.GetByGameId;
using Market.Application.Modules.Catalog.Reviews.Queries.GetById;

namespace Market.Application.Modules.Catalog.Reviews.Queries.GetByUserId;

public sealed class ListReviewsByUserQueryDto
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public ListReviewsByUserQueryGameDto? Game { get; set; }

    public class ListReviewsByUserQueryGameDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
    }
}
