namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class ModerationActionEntityConfiguration : IEntityTypeConfiguration<ModerationActionEntity>
{
    public void Configure(EntityTypeBuilder<ModerationActionEntity> b)
    {
        b.ToTable("ModerationActions");

        b.HasKey(x => x.Id);

        b.Property(x => x.ActionType)
            .HasConversion<string>()
            .IsRequired();

        b.Property(x => x.Reason)
            .IsRequired();

        b.HasOne(x => x.AdminUser)
            .WithMany()
            .HasForeignKey(x => x.AdminUserId);

        b.HasOne(x => x.TargetUser)
            .WithMany(x => x.ActionsReceived)
            .HasForeignKey(x => x.TargetUserId);
    }
}