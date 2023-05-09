using Aquaculture.Domain.DirectoryContext.DiseaseAggregate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.InfluenceWaterContext;

public class PumpConfigurations : IEntityTypeConfiguration<Pump>
{
    public void Configure(EntityTypeBuilder<Pump> builder)
    {
        ConfigurePumpsTable(builder);
    }

    private void ConfigurePumpsTable(EntityTypeBuilder<Pump> builder)
    {
        builder.ToTable("Pumps");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => PumpId.Create(value));

        builder.Property(m => m.Efficiency);
        builder.Property(m => m.OperatingTime);
        builder.Property(m => m.Model);
        builder.Property(m => m.IsEnable);
    }
}
