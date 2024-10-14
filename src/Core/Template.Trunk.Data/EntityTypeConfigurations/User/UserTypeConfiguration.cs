using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Trunk.Data.Entities.User;

namespace Template.Trunk.Data.EntityTypeConfigurations.User;

public class UserTypeConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(e => e.CreatedOn)
               //.HasDefaultValue(DateTime.UtcNow)
               .IsRequired();

        builder.Property(g => g.Timestamp)
               .IsRowVersion();
    }
}
