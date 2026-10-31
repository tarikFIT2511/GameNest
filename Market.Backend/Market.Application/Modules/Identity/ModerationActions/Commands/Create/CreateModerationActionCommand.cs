using Market.Domain.Enums;

namespace Market.Application.Modules.Identity.ModerationActions.Commands.Create;

public class CreateModerationActionCommand : IRequest<int>
{
    public required int AdminUserId { get; set; }
    public required int TargetUserId {  get; set; }
    public required ModerationActionType ActionType { get; set; }
    public string? Reason {  get; set; }
}