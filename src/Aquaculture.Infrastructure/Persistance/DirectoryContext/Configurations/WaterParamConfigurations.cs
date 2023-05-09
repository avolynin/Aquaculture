using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext.Configurations;

public class WaterParamConfigurations : IEntityTypeConfiguration<WaterParam>
{
    public void Configure(EntityTypeBuilder<WaterParam> builder)
    {
        ConfigureWaterParamsTable(builder);
    }

    private void ConfigureWaterParamsTable(EntityTypeBuilder<WaterParam> builder)
    {
        builder.ToTable("WaterParams");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => WaterParamId.Create(value));

        builder.Property(m => m.Name);
        builder.Property(m => m.Unit);
    }
}
