using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.ControlWaterContext;

public class WaterMeasurementConfigurations : IEntityTypeConfiguration<WaterMeasurement>
{
    public void Configure(EntityTypeBuilder<WaterMeasurement> builder)
    {
        ConfigureWaterMeasurementsTable(builder);
    }

    private void ConfigureWaterMeasurementsTable(
        EntityTypeBuilder<WaterMeasurement> builder)
    {
        builder.ToTable("WaterMeasurements");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => WaterMeasurementId.Create(value));

        builder.Property(m => m.FishTankId)
            .HasConversion(
            id => id.Value,
            value => FishTankId.Create(value));

        builder.Property(m => m.Value);
        builder.Property(m => m.Depth).IsRequired(false);
        builder.Property(m => m.Location);
        builder.Property(m => m.TimeStamp);
    }
}
