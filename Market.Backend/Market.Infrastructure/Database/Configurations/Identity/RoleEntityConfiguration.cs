namespace Market.Infrastructure.Database.Configurations.Identity;

public sealed class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> b)
    {
        b.ToTable("Roles");

        b.HasKey(x => x.Id);

        b.Property(x => x.Id)
            .IsRequired();

        b.HasIndex(x => x.Id)
            .IsUnique();

        b.Property(x => x.Name)
            .HasMaxLength(RoleEntity.Constraints.NameMaxLength);

        b.HasIndex(x => x.Name)
            .IsUnique();
    }
}