using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Trunk.Data.Entities.User;
using Template.Trunk.Shared.Cryptography;
using Template.Trunk.Shared.Helpers;

namespace Template.Trunk.Data.EntityTypeConfigurations.User;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    private readonly IHasher _hasher;
    public UserConfiguration(IHasher hasher)
    {
        _hasher = hasher;
    }

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

        string defaultAdminCode = StringHelper.GetRandomCode("XXXXX99999");
        string defaultAdminPwd = "123456aA@";
        builder.HasData(
            new UserEntity()
            {
                Id = 1,
                Code = defaultAdminCode,
                CreatedOn = DateTime.Now,
                Name = "Aministrator",
                PasswordHash = _hasher.GetHash(defaultAdminPwd, defaultAdminCode),
                EmailAddress = "jimmy.vtp94@gmail.com",
                CreateBy = defaultAdminCode
            });
    }
}
