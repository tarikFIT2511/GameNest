namespace Market.Application.Modules.Identity.ModerationActions.Queries.GetById;

public class GetModerationActionByIdQueryDto
{
    public required int Id { get; init; }
    public required int AdminUserId { get; init; }
    public required string AdminUsername { get; init; }
    public required int TargetUserId { get; init; }
    public required string TargetUsername { get; init; }
    public required ModerationActionType ActionType { get; init; }
    public required string Reason { get; init; }
    public required DateTime CreatedAt { get; init; }
}
