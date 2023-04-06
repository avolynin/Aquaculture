using Aquaculture.Domain.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.WaterMeasurementAggreate;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;
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

        builder.OwnsOne(x => x.WaterParams, p =>
        {
            p.Property(m => m.Temperature);
            p.Property(m => m.DissolvedOxygen);
            p.Property(m => m.Acidity);
            p.Property(m => m.Alkalinity);
            p.Property(m => m.CarbonDioxide);
            p.Property(m => m.Ammonia);
        });
    }
}
