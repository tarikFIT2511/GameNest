namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class UserProfileEntityConfiguration : IEntityTypeConfiguration<UserProfileEntity>
{
    public void Configure(EntityTypeBuilder<UserProfileEntity> b)
    {
        b.ToTable("UserProfiles");

        b.HasKey(x => x.Id);

        b.HasOne(x => x.User)
            .WithOne(x => x.Profile)
            .HasForeignKey<UserProfileEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);//ensures if user gets deleted, his profile gets deleted, too.

        b.Property(x => x.UserId)
            .IsRequired();

        b.Property(x => x.Country)
            .HasMaxLength(100);

        b.Property(x => x.AvatarUrl)
            .HasMaxLength(500);

        b.Property(x => x.Bio)
            .HasMaxLength(1000);

        b.HasIndex(x => x.UserId)
            .IsUnique();
    }
}