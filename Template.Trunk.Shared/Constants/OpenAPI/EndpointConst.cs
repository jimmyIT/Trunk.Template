namespace Template.Trunk.Shared.Constants.OpenAPI;

public struct EndpointConst
{
    private const string Ver_01 = "v1";
    private const string Ver_02 = "v2";
    private const string _baseVer_01 = $"/api/{Ver_01}";

    public struct User
    {
        private const string Base = _baseVer_01 + "/user";

        public const string GenerateToken = Base + "/generate-token";
        public const string RefreshToken = Base + "/refresh-token";
        public const string RevokeToken = Base + "/revoke-token";
        public const string Create = Base;
        public const string Update = Base;
        public const string GetByCode = Base + "/{code}";
    }
}
