using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Trunk.Data.Entities.WsReqResp;

namespace Template.Trunk.Data.EntityTypeConfigurations.WsReqResp;

public class WsReqRespConfiguration : IEntityTypeConfiguration<WsReqRespEntity>
{
    public void Configure(EntityTypeBuilder<WsReqRespEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasOne(u => u.MessageDefinition)
            .WithMany(u => u.WsReqResps)
            .HasForeignKey(us => us.MessageDefinitionCode)
            .HasPrincipalKey(u => u.Code)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(g => g.Timestamp)
               .IsRowVersion();
    }
}
