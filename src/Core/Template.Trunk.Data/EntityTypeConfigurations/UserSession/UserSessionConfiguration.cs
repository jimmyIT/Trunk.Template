using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Trunk.Data.Entities.UserSession;

namespace Template.Trunk.Data.EntityTypeConfigurations.UserSession;

public class UserSessionConfiguration : IEntityTypeConfiguration<UserSessionEntity>
{
    public void Configure(EntityTypeBuilder<UserSessionEntity> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Id).IsUnique();
        builder.Property(e => e.Id)
               .ValueGeneratedOnAdd();

        builder.HasIndex(u => u.Code).IsUnique();
        builder.Property(e => e.Code)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasOne(u => u.User)
            .WithMany(u => u.UserSessions)
            .HasForeignKey(us => us.UserCode)
            .HasPrincipalKey(u => u.Code)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(g => g.Timestamp)
               .IsRowVersion();
    }
}
