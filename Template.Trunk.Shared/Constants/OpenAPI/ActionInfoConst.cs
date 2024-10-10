namespace Template.Trunk.Shared.Constants.OpenAPI;

public struct ActionInfoConst
{
    public struct User
    {
        public struct GenerateToken
        {
            public const string Code = "USER001";
            public const string Description = "Generate Token";
        }

        public struct RefreshToken
        {
            public const string Code = "USER002";
            public const string Description = "Refresh Token";
        }

        public struct RevokeToken
        {
            public const string Code = "USER003";
            public const string Description = "Revoke Token";
        }
    }
}
