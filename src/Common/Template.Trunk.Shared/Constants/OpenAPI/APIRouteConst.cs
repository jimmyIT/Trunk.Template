namespace Template.Trunk.Shared.Constants.OpenAPI;

public struct APIRouteConst
{
    public struct User
    {
        public const string GenerateToken = "/generate-token";
        public const string RefreshToken = "/refresh-token";
        public const string RevokeToken = "/revoke-token";
        public const string Get = "/{code}";
        public const string Create = "";
        public const string Update = "";
        public const string GetByCode = "/{code}";
    }
}
