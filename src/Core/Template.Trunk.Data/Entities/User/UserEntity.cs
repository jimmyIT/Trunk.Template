using Template.Trunk.Data.Bases.Entities;
using Template.Trunk.Data.Entities.UserSession;

namespace Template.Trunk.Data.Entities.User;

/// <summary>
/// Store the User Details.
/// </summary>
public class UserEntity : IBaseEntityDetails
{
    public int Id { get; set; }
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string CreateBy { get; set; } = default!;
    public DateTime CreatedOn { get; set; } = default!;
    public string? AmendedBy { get; set; } = default!;
    public DateTime? AmendedOn { get; set; } = default!;
    public byte[]? Timestamp { get; set; }
    
    // Navigation Property
    public virtual ICollection<UserSessionEntity> UserSessions { get; set; } = [];
}
