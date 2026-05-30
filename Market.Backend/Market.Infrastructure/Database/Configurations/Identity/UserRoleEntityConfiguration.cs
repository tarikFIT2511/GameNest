namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
{
    public void Configure(EntityTypeBuilder<UserRoleEntity> b)
    {
        b.ToTable("UserRoles");

        b.HasKey(x => x.Id);

        b.HasIndex(x => new { x.UserId, x.RoleId })
            .IsUnique();

        // relationships
        b.HasOne(x => x.User)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.Role)
            .WithMany(x => x.UserRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}