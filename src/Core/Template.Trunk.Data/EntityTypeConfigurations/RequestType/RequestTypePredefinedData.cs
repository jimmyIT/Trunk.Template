using Template.Trunk.Data.Entities.RequestType;

namespace Template.Trunk.Data.EntityTypeConfigurations.RequestType
{
    public static class RequestTypePredefinedData
    {
        public static List<RequestTypeEntity> RequestTypes => new List<RequestTypeEntity>
        {
            GenerateToken,
            RefreshToken,
            RevokeToken
        };

        public static RequestTypeEntity GenerateToken => new RequestTypeEntity()
        {
            Id = 1,
            Code = "USER001",
            Description = "Generate token (Create user session)",
            Category = ""
        };

        public static RequestTypeEntity RefreshToken => new RequestTypeEntity()
        {
            Id = 2,
            Code = "USER002",
            Description = "Refresh token (Re-generate user session)",
            Category = ""
        };

        public static RequestTypeEntity RevokeToken => new RequestTypeEntity()
        {
            Id = 3,
            Code = "USER003",
            Description = "Revoke token (Delete user session)",
            Category = ""
        };
    }
}
