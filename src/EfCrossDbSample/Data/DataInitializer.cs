using Microsoft.EntityFrameworkCore;

namespace EfCrossDbSample.Data;

public static class DataInitializer
{
    public static async Task SeedTestData(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var dbContext2 = scope.ServiceProvider.GetRequiredService<AppDbContext2>();
            await dbContext2.Database.EnsureDeletedAsync();
            await dbContext2.Database.MigrateAsync();
            var country1 = new Country { Id = Guid.NewGuid(), Name = "Country1" };
            var country2 = new Country { Id = Guid.NewGuid(), Name = "Country2" };
            dbContext2.AddRange(country1, country2);
            await dbContext2.SaveChangesAsync();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.MigrateAsync();
            var customer1 = new Customer { Id = Guid.NewGuid(), Name = "Customer1", CountryId = country1.Id };
            var customer2 = new Customer { Id = Guid.NewGuid(), Name = "Customer2", CountryId = country2.Id };
            var customer3 = new Customer { Id = Guid.NewGuid(), Name = "Customer3" }; // NULL CountryId to demonstrate LEFt JOIN
            dbContext.AddRange(customer1, customer2, customer3);
            await dbContext.SaveChangesAsync();
        }
    }
}
