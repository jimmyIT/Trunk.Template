using Template.Trunk.Data.Bases.Entities;
using Template.Trunk.Data.Entities.User;

namespace Template.Trunk.Data.Entities.UserSession
{
    public class UserSessionEntity : IBaseEntity
    {
        public int Id { get; set; }
        public string Code { get; set; } = default!;
        public byte[]? Timestamp { get; set; }
        public string RefreshToken { get; set; } = default!;
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? LastActivityAt { get; set; }
        public bool IsActive { get; set; } = true;

        // Foreign Key
        public string UserCode { get; set; } = default!;

        // Navigation Property
        public virtual UserEntity User { get; set; } = default!;
    }
}
