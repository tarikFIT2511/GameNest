namespace Market.Infrastructure.Database.Configurations.Catalog;

public class GameConfiguration : IEntityTypeConfiguration<GameEntity>
{
    public void Configure(EntityTypeBuilder<GameEntity> builder)
    {
        builder
            .ToTable("Games");

        builder
            .Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(GameEntity.Constraints.TitleMaxLength);

        builder
            .Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(GameEntity.Constraints.DescriptionMaxLength);

        builder
            .Property(x => x.CoverImageUrl)
            .IsRequired()
            .HasMaxLength(GameEntity.Constraints.CoverImageUrlMaxLength);
    }
}
