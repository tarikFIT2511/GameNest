// MarketUserEntity.cs
using Market.Domain.Common;

namespace Market.Domain.Entities.Identity;

public sealed class ModerationActionEntity : BaseEntity
{
    public int AdminUserId {  get; set; } // user which gave the action
    public UserEntity AdminUser {  get; set; }
    public required int TargetUserId { get; set; } // user which recieved the action
    public UserEntity TargetUser { get; set; }
    public ModerationActionType ActionType { get; set; }
    public string? Reason {  get; set; }
}