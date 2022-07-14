using Microsoft.EntityFrameworkCore;

namespace EfCrossDbSample;

// In this sample we're using this additional context for the second DB just so we can seed some test data.
public class AppDbContext2 : DbContext
{
    public DbSet<Country> Countries => Set<Country>();

    public AppDbContext2(DbContextOptions<AppDbContext2> options)
        : base(options)
    {
    }
}
