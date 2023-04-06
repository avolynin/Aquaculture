using Aquaculture.Domain.FishInfoAggregate;
using Aquaculture.Domain.FishInfoAggregate.ValueObjects;
using Aquaculture.Domain.FishTankAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.Configurations;

public class FishInfoConfigurations : IEntityTypeConfiguration<FishInfo>
{
    public void Configure(EntityTypeBuilder<FishInfo> builder)
    {
        ConfigureFishInfoTable(builder);
        ConfigureFishTypeTable(builder);
    }

    private void ConfigureFishTypeTable(EntityTypeBuilder<FishInfo> builder)
    {
        builder.OwnsOne(m => m.FishType, sb =>
        {
            sb.ToTable("FishTypes");
            sb.WithOwner().HasForeignKey("FishInfoId");
            sb.HasKey("Id", "FishInfoId");

            sb.Property(s => s.Id)
                .HasColumnName("FishTypeId")
                .HasConversion(
                    id => id.Value,
                    value => FishTypeId.Create(value));

            sb.Property(s => s.Name);

            sb.OwnsOne(x => x.TolerantParams, p =>
            {
                p.Property(m => m.Temperature);
                p.Property(m => m.DissolvedOxygen);
                p.Property(m => m.Acidity);
                p.Property(m => m.Alkalinity);
                p.Property(m => m.CarbonDioxide);
                p.Property(m => m.Ammonia);
            });

            sb.OwnsOne(x => x.CriticalParams, p =>
            {
                p.Property(m => m.Temperature);
                p.Property(m => m.DissolvedOxygen);
                p.Property(m => m.Acidity);
                p.Property(m => m.Alkalinity);
                p.Property(m => m.CarbonDioxide);
                p.Property(m => m.Ammonia);
            });

            sb.OwnsOne(x => x.ComfortParams, p =>
            {
                p.Property(m => m.Temperature);
                p.Property(m => m.DissolvedOxygen);
                p.Property(m => m.Acidity);
                p.Property(m => m.Alkalinity);
                p.Property(m => m.CarbonDioxide);
                p.Property(m => m.Ammonia);
            });
        });
    }

    private void ConfigureFishInfoTable(EntityTypeBuilder<FishInfo> builder)
    {
        builder.ToTable("FishInfomations");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => FishInfoId.Create(value));

        builder.Property(m => m.AvgWeight);
        builder.Property(m => m.BornDate);
    }
}
