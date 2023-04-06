using Aquaculture.Domain.UserAggregate;
using Aquaculture.Domain.UserAggregate.ValueObjects;
using Aquaculture.Domain.WaterMeasurementAggreate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aquaculture.Infrastructure.Persistance.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);

        builder.Property(m => m.Id)
            .HasConversion(
            id => id.Value,
            value => UserId.Create(value));

        builder.Property(u => u.Email);
        builder.Property(u => u.Role);
        builder.Property(u => u.FullName);
        builder.Property(u => u.Password);
    }
}
