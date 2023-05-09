using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.InfluenceWaterContext.FishTankAggregate;
using Aquaculture.Domain.InfluenceWaterContext.PumpAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.InfluenceWaterContext;

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

        builder.Property(m => m.Name);
        builder.Property(m => m.RelocatedDate);
        builder.Property(m => m.Location);
    }
}
