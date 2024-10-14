using Microsoft.EntityFrameworkCore;
using Template.Trunk.Data.Entities.MessageType;
using Template.Trunk.Data.Entities.User;
using Template.Trunk.Data.Entities.UserSession;
using Template.Trunk.Data.Entities.WsReqResp;
using Template.Trunk.Data.EntityTypeConfigurations.MessageType;
using Template.Trunk.Data.EntityTypeConfigurations.User;
using Template.Trunk.Data.EntityTypeConfigurations.UserSession;
using Template.Trunk.Data.EntityTypeConfigurations.WsReqResp;

namespace Template.Trunk.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base()
    {

    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserSessionEntity> UserSessions { get; set; }
    public DbSet<MessageDefinitionEntity> MessageTypes { get; set; }
    public DbSet<WsReqRespEntity> WsRequestResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        modelBuilder.ApplyConfiguration(new UserSessionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MessageDefinitionTypeConfiguration());
        modelBuilder.ApplyConfiguration(new WsReqRespTypeConfiguration());
    }
}
