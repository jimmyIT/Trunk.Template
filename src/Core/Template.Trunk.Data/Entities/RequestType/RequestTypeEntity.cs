using Template.Trunk.Data.Bases.Entities;
using Template.Trunk.Data.Entities.WsReqResp;

namespace Template.Trunk.Data.Entities.RequestType;

public class RequestTypeEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }

    // Navigation Property
    public virtual ICollection<WsReqRespEntity> WsReqResps { get; set; } = [];
}
