using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistence.Configurations;

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

        builder.Property(m => m.TimeStamp);
    }
}
