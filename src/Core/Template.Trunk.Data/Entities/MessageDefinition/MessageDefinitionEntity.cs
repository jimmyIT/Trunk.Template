using Template.Trunk.Data.Bases.Entities;

namespace Template.Trunk.Data.Entities.MessageType;

public class MessageDefinitionEntity : IBaseEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string MessageType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte[]? Timestamp { get; set; }
}
