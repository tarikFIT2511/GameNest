namespace Market.Infrastructure.Database.Seeders;

public partial class StaticDataSeeder
{
    private static DateTime DateTime { get; set; } = new DateTime(2022, 4, 13, 1, 22, 18, 866, DateTimeKind.Local);

    public static void Seed(ModelBuilder modelBuilder)
    {
        // Static data is added in the migration
        // if it does not exist in the DB at the time of creating the migration
        // example of static data: roles
        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        //roles
        modelBuilder.Entity<RoleEntity>().HasData(new List<RoleEntity>
        {
            new RoleEntity{
                Id = 1,
                Name = "Admin",
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = null,
            },
            new RoleEntity{
                Id = 2,
                Name = "Developer",
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = null,
            },
            new RoleEntity{
                Id = 3,
                Name = "Customer",
                CreatedAtUtc = DateTime.UtcNow,
                ModifiedAtUtc = null,
            },
        });
    }
}