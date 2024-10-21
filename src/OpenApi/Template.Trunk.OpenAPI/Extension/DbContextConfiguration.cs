using Microsoft.EntityFrameworkCore;
using Template.Trunk.Data.DbContexts;

namespace Template.Trunk.OpenAPI.Extension
{
    public static class DbContextConfiguration
    {
        public static void MigrateDatabase(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
