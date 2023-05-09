using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aquaculture.Infrastructure.Persistance.AquacultureContext;

public class AquacultureDbContext : DbContext
{
    public AquacultureDbContext(DbContextOptions<AquacultureDbContext> options)
        : base(options)
    {
    }

    public DbSet<FishTank> FishTanks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AquacultureDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}
