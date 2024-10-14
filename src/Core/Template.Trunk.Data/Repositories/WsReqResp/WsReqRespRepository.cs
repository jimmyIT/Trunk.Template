using Template.Trunk.Data.DbContexts;
using Template.Trunk.Data.Entities.WsReqResp;

namespace Template.Trunk.Data.Repositories.WsReqResp;

public class WsReqRespRepository
    : BaseApplicationRepository<WsReqRespEntity>, IWsReqRespRepository
{
    public WsReqRespRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}
