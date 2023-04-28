using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.Configurations;

public class FishTankConfigurations : IEntityTypeConfiguration<FishTank>
{
    public void Configure(EntityTypeBuilder<FishTank> builder)
    {
        ConfigureFishTanksTable(builder);
    }

    private void ConfigureFishTanksTable(EntityTypeBuilder<FishTank> builder)
    {
        builder.ToTable("FishTanks");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => FishTankId.Create(value));

        builder.Property(m => m.WaterMeasurementId)
            .HasConversion(
            id => id.Value,
            value => WaterMeasurementId.Create(value));

        builder.Property(m => m.FishInfoId)
            .HasConversion(
            id => id.Value,
            value => FishInfoId.Create(value));

        builder.Property(m => m.Name);
    }
}
