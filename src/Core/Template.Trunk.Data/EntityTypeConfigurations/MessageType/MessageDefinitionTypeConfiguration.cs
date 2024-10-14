using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Trunk.Data.Entities.MessageType;

namespace Template.Trunk.Data.EntityTypeConfigurations.MessageType;

public class MessageDefinitionTypeConfiguration : IEntityTypeConfiguration<MessageDefinitionEntity>
{
    public void Configure(EntityTypeBuilder<MessageDefinitionEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(g => g.Timestamp)
               .IsRowVersion();
    }
}
