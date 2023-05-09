using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.Entities;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aquaculture.Infrastructure.Persistance.ControlWaterContext;

public class WaterControlDbContext : DbContext
{
    public WaterControlDbContext(DbContextOptions<WaterControlDbContext> options)
        : base(options)
    {
    }

    public DbSet<MasterNetwork> MasterNetworks { get; set; } = null!;
    public DbSet<WaterMeasurement> WaterMeasurements { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WaterControlDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}
