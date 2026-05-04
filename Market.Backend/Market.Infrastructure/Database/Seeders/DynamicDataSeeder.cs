using Microsoft.AspNetCore.Identity;

namespace Market.Infrastructure.Database.Seeders;

/// <summary>
/// Dynamic seeder executed at runtime,
/// usually on application startup (e.g. in Program.cs).
/// Used for inserting demo/test data that is not part of migrations.
/// </summary>
public static class DynamicDataSeeder
{
    public static async Task SeedAsync(DatabaseContext context)
    {
        // Ensure database exists (without migrations)
        await context.Database.EnsureCreatedAsync();

        await SeedProductCategoriesAsync(context);
        await SeedUsersAsync(context);
    }

    private static async Task SeedProductCategoriesAsync(DatabaseContext context)
    {
        if (!await context.ProductCategories.AnyAsync())
        {
            context.ProductCategories.AddRange(
                new ProductCategoryEntity
                {
                    Name = "Computers (demo)",
                    IsEnabled = true,
                    CreatedAt = DateTime.UtcNow
                },
                new ProductCategoryEntity
                {
                    Name = "Mobile devices (demo)",
                    IsEnabled = true,
                    CreatedAt = DateTime.UtcNow
                }
            );

            await context.SaveChangesAsync();
            Console.WriteLine("✅ Dynamic seed: product categories added.");
        }
    }

    /// <summary>
    /// Creates demo users if none exist in the database.
    /// </summary>
    private static async Task SeedUsersAsync(DatabaseContext context)
    {
        if (await context.Users.AnyAsync())
            return;

        var hasher = new PasswordHasher<UserEntity>();

        var admin = new UserEntity
        {
            Email = "admin@market.local",
            PasswordHash = hasher.HashPassword(null!, "Admin123!"),
            Role = "Admin",
            IsEnabled = true,
        };

        var user = new UserEntity
        {
            Email = "user@market.local",
            PasswordHash = hasher.HashPassword(null!, "User123!"),
            Role = "User",
            IsEnabled = true,
        };

        context.Users.AddRange(admin, user);
        await context.SaveChangesAsync();

        Console.WriteLine("✅ Dynamic seed: demo users added.");
    }
}