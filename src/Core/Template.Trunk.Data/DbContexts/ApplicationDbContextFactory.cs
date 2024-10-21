using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Template.Trunk.Shared.Cryptography;

namespace Template.Trunk.Data.DbContexts;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer("Server=PHUONG-VO;Database=DemoDatabase;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true;Encrypt=false;");

        // Manually instantiate the hasher or use a default implementation
        IHasher hasher = new Hasher(new PasswordHasher<object>());

        return new ApplicationDbContext(optionsBuilder.Options, hasher);
    }
}
