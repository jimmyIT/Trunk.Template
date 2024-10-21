using Template.Trunk.Data.Bases.Entities;
using Template.Trunk.Data.Entities.RequestType;

namespace Template.Trunk.Data.Entities.WsReqResp;

/// <summary>
/// Store the Requests/Responses.
/// </summary>
public class WsReqRespEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public string ReferenceId { get; set; } = default!;
    public string CreateBy { get; set; } = default!;
    public DateTime CreatedOn { get; set; }
    public string Url { get; set; } = default!;
    public string RequestHeader { get; set; } = default!;
    public string RequestMessage { get; set; } = default!;
    public string ResponseMessage { get; set; } = default!;
    public int Status { get; set; } = default!;
    public string ErrorCode { get; set; } = default!;
    public string ErrorMessage { get; set; } = default!;
    public byte[]? Timestamp { get; set; }

    public string MessageDefinitionCode { get; set; } = default!;
    // Navigation Property
    public RequestTypeEntity MessageDefinition { get; set; } = default!;
}
