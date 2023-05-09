using Aquaculture.Domain.ControlWaterContext.WaterMeasurementAggreate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.DiseaseAggregate;
using Aquaculture.Domain.DirectoryContext.DiseaseAggregate.ValueObjects;
using Aquaculture.Domain.DirectoryContext.WaterParamAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.DirectoryContext.Configurations;

public class DiseaseConfigurations : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        ConfigureDiseasesTable(builder);
    }

    private void ConfigureDiseasesTable(EntityTypeBuilder<Disease> builder)
    {
        builder.ToTable("Diseases");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => DiseaseId.Create(value));

        builder.Property(m => m.Name);
        builder.Property(m => m.Description).IsRequired(false);
    }
}
