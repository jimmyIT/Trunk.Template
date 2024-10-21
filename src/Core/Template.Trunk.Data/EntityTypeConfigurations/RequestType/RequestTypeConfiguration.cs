using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Trunk.Data.Entities.RequestType;

namespace Template.Trunk.Data.EntityTypeConfigurations.RequestType;

public class RequestTypeConfiguration : IEntityTypeConfiguration<RequestTypeEntity>
{
    public void Configure(EntityTypeBuilder<RequestTypeEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(10)
               .IsRequired();

        builder.Property(e => e.Description)
              .HasMaxLength(100);

        builder.Property(g => g.Timestamp)
               .IsRowVersion();

        builder.HasData(RequestTypePredefinedData.RequestTypes);
    }
}
