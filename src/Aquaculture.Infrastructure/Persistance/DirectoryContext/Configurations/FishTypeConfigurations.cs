using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate;
using Aquaculture.Domain.DirectoryContext.FishTypeAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext.Configurations;

public class FishTypeConfigurations : IEntityTypeConfiguration<FishType>
{
    public void Configure(EntityTypeBuilder<FishType> builder)
    {
        ConfigureFishTypeTable(builder);
        ConfigureCriticalParamsTable(builder);
        ConfigureTolerantParamsTable(builder);
        ConfigureComfortParamsTable(builder);
    }

    private void ConfigureFishTypeTable(EntityTypeBuilder<FishType> builder)
    {
        builder.ToTable("FishTypes");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => FishTypeId.Create(value));

        builder.Property(m => m.Name);
        builder.OwnsOne(m => m.Age);
    }

    private void ConfigureCriticalParamsTable(EntityTypeBuilder<FishType> builder)
    {
        builder.OwnsMany(m => m.CriticalParams, dib =>
        {
            dib.ToTable("CriticalParamsIds");
            dib.WithOwner().HasForeignKey("FishTypeId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName("CriticalParamId");
        });

        builder.Metadata.FindNavigation(nameof(FishType.CriticalParams))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureTolerantParamsTable(EntityTypeBuilder<FishType> builder)
    {
        builder.OwnsMany(m => m.TolerantParams, dib =>
        {
            dib.ToTable("TolerantParamsIds");
            dib.WithOwner().HasForeignKey("FishTypeId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName("TolerantParamId");
        });

        builder.Metadata.FindNavigation(nameof(FishType.TolerantParams))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureComfortParamsTable(EntityTypeBuilder<FishType> builder)
    {
        builder.OwnsMany(m => m.ComfortParams, dib =>
        {
            dib.ToTable("ComfortParamsIds");
            dib.WithOwner().HasForeignKey("FishTypeId");
            dib.HasKey("Id");

            dib.Property(d => d.Value)
                .HasColumnName("ComfortParamId");
        });

        builder.Metadata.FindNavigation(nameof(FishType.ComfortParams))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
