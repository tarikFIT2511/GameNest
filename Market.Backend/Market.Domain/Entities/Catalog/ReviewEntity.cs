using Market.Domain.Common;
using Market.Domain.Entities.Identity;

namespace Market.Domain.Entities.Catalog;

public sealed class ReviewEntity : BaseEntity
    {
    public int UserId { get; set; }
    public UserEntity? User { get; set; }
    public int GameId { get; set; }
    public GameEntity? Game { get; set; }
    /// <summary>
    /// Rating of the game is defined by 1 - 5 
    /// </summary>
    public int Rating { get; set; } 
    public string? Comment { get; set; }

    public static class Constraints
    {
        public const int MinRating = 1;
        public const int MaxRating = 5;
        public const int CommentMaxLength = 2000;
    }

}

