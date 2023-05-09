using Aquaculture.Domain.InfluenceWaterContext.FishTankAggregate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aquaculture.Infrastructure.Persistance.InfluenceWaterContext;

public class InfluenceWaterDbContext : DbContext
{
    public InfluenceWaterDbContext(DbContextOptions<InfluenceWaterDbContext> options)
        : base(options)
    {
    }

    public DbSet<FishTank> FishTanks { get; set; } = null!;
    public DbSet<Pump> Pumps { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InfluenceWaterDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}
