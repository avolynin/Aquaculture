using Aquaculture.Domain.FishInfoAggregate;
using Aquaculture.Domain.FishTankAggregate;
using Aquaculture.Domain.UserAggregate;
using Aquaculture.Domain.WaterMeasurementAggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aquaculture.Infrastructure.Persistence;

public class AquacultureDbContext : DbContext
{
    public AquacultureDbContext(DbContextOptions<AquacultureDbContext> options)
        : base(options)
    {
    }

    public DbSet<WaterMeasurement> WaterMeasurements { get; set; } = null!;
    public DbSet<FishTank> FishTanks { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<FishInfo> FishInfomations { get; set; } = null!;

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
