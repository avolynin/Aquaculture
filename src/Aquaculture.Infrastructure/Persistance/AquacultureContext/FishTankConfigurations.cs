using Aquaculture.Domain.AquacultureContext.FishTankAggregate;
using Aquaculture.Domain.AquacultureContext.FishTankAggregate.ValueObjects;
using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.AquacultureContext;

public class FishTankConfigurations : IEntityTypeConfiguration<FishTank>
{
    public void Configure(EntityTypeBuilder<FishTank> builder)
    {
        ConfigureFishTanksTable(builder);
        ConfigureFishInfosTable(builder);
        // ConfigureSensorIdsTable(builder);
    }

    //private void ConfigureSensorIdsTable(EntityTypeBuilder<FishTank> builder)
    //{
    //    builder.OwnsMany(m => m.SensorIds, dib =>
    //    {
    //        dib.ToTable("SensorIds");
    //        dib.WithOwner().HasForeignKey("FishTankId");
    //        dib.HasKey("Id");

    //        dib.Property(d => d.Value)
    //            .HasColumnName("SensorId");
    //    });

    //    builder.Metadata.FindNavigation(nameof(FishTank.SensorIds))!
    //        .SetPropertyAccessMode(PropertyAccessMode.Field);
    //}

    private void ConfigureFishInfosTable(EntityTypeBuilder<FishTank> builder)
    {
        builder.OwnsMany(m => m.FishInfos, sb =>
        {
            sb.ToTable("FishInfos");
            sb.WithOwner().HasForeignKey();
            sb.HasKey("Id", "FishTankId");

            sb.Property(s => s.Id)
                .HasColumnName("FishInfoId")
                .HasConversion(
                id => id.Value,
                value => FishInfoId.Create(value));

            sb.Property(s => s.TypeId)
                .HasConversion(
                id => id.Value,
                value => FishTypeId.Create(value));

            sb.Property(s => s.NumberFish);
            sb.Property(s => s.Anomaly).IsRequired(false);
            sb.Property(s => s.CreatedDate);
            sb.Property(s => s.CommitedDate);
        });

        builder.Metadata.FindNavigation(nameof(FishTank.FishInfos))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureFishTanksTable(EntityTypeBuilder<FishTank> builder)
    {
        builder.ToTable("FishTanks");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => FishTankId.Create(value));

        builder.Property(m => m.MasterNetworkId)
            .HasConversion(
            id => id.Value,
            value => MasterNetworkId.Create(value));

        builder.Property(m => m.Name);
        builder.Property(m => m.Volume);
        builder.Property(m => m.Location);
    }
}
