using Aquaculture.Domain.Common.ValueObjects;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate;
using Aquaculture.Domain.ControlWaterContext.MasterNetworkAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.ControlWaterContext;

public class MasterNetworkConfigurations : IEntityTypeConfiguration<MasterNetwork>
{
    public void Configure(EntityTypeBuilder<MasterNetwork> builder)
    {
        ConfigureMasterNetworksTable(builder);
        ConfigureSensorsTable(builder);
    }

    private void ConfigureMasterNetworksTable(
        EntityTypeBuilder<MasterNetwork> builder)
    {
        builder.ToTable("MasterNetworks");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => MasterNetworkId.Create(value));

        builder.Property(m => m.FishTankId)
            .HasConversion(
            id => id.Value,
            value => FishTankId.Create(value));

        builder.Property(m => m.Url);
        builder.Property(m => m.Duration);
        builder.Property(m => m.IsConntected);
        builder.Property(m => m.Location);
    }

    private void ConfigureSensorsTable(EntityTypeBuilder<MasterNetwork> builder)
    {
        builder.OwnsMany(m => m.Sensors, sb =>
        {
            sb.ToTable("Sensors");
            sb.WithOwner().HasForeignKey();
            sb.HasKey("Id", "MasterNetworkId");

            sb.Property(s => s.Id)
                .HasColumnName("SensorId")
                .HasConversion(
                id => id.Value,
                value => SensorId.Create(value));

            sb.Property(s => s.FishTankId)
                .HasConversion(
                id => id.Value,
                value => FishTankId.Create(value));

            sb.Property(s => s.WaterParamId)
                .HasConversion(
                id => id.Value,
                value => WaterParamId.Create(value));

            sb.Property(s => s.Location);
            sb.Property(s => s.Depth).IsRequired(false);
            sb.Property(s => s.Status);
            sb.Property(s => s.Place);
            sb.Property(s => s.Charging);
        });

        builder.Metadata.FindNavigation(nameof(MasterNetwork.Sensors))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
