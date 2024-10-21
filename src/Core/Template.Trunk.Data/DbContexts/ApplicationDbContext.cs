using Microsoft.EntityFrameworkCore;
using Template.Trunk.Data.Entities.RequestType;
using Template.Trunk.Data.Entities.User;
using Template.Trunk.Data.Entities.UserSession;
using Template.Trunk.Data.Entities.WsReqResp;
using Template.Trunk.Data.EntityTypeConfigurations.RequestType;
using Template.Trunk.Data.EntityTypeConfigurations.User;
using Template.Trunk.Data.EntityTypeConfigurations.UserSession;
using Template.Trunk.Data.EntityTypeConfigurations.WsReqResp;
using Template.Trunk.Shared.Cryptography;

namespace Template.Trunk.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    private readonly IHasher _hasher;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHasher hasher) : base(options)
    {
        _hasher = hasher;
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserSessionEntity> UserSessions { get; set; }
    public DbSet<RequestTypeEntity> MessageTypes { get; set; }
    public DbSet<WsReqRespEntity> WsRequestResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration(_hasher));
        modelBuilder.ApplyConfiguration(new UserSessionConfiguration());
        modelBuilder.ApplyConfiguration(new RequestTypeConfiguration());
        modelBuilder.ApplyConfiguration(new WsReqRespConfiguration());
    }
}
