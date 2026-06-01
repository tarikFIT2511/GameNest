using Market.Domain.Common;

namespace Market.Domain.Entities.Catalog;

public sealed class GameEntity : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? CoverImageUrl { get; set; }
    public decimal AverageRating { get; set; }
    public bool IsEnabled { get; set; } = true;
    public ICollection<ReviewEntity> Reviews { get; set; } = new List<ReviewEntity>();
    public static class Constraints
    {
        public const int TitleMaxLength = 200;
        public const int DescriptionMaxLength = 2000;
        public const int CoverImageUrlMaxLength = 500;
    }

}

