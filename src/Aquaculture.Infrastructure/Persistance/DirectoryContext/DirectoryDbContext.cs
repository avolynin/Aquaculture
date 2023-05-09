using Aquaculture.Domain.DirectoryContext.DiseaseAggregate;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Aquaculture.Infrastructure.Persistance.ControlWaterContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext;

public class DirectoryDbContext : DbContext
{
    public DirectoryDbContext(DbContextOptions<WaterControlDbContext> options)
        : base(options)
    {
    }

    public DbSet<Disease> Diseases { get; set; } = null!;
    public DbSet<FishType> FishTypes { get; set; } = null!;
    public DbSet<WaterParam> WaterParams { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DirectoryDbContext).Assembly);
        modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.IsPrimaryKey())
            .ToList()
            .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

        base.OnModelCreating(modelBuilder);
    }
}
