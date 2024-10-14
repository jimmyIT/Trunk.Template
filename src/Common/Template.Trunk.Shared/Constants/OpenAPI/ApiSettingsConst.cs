namespace Template.Trunk.Shared.Constants.OpenAPI;

public struct ApiSettingsConst
{
    public const string ApiVersion = "v{version:apiVersion}";
    public const string DefaultRoute = $"api/{ApiVersion}";

    public struct Version
    {
        public const string V1_0 = "1.0";
        public const string V2_0 = "2.0";
    }

    public struct Tag
    {
        public const string User = "User";
    }

    public struct Controller
    {
        public const string User = "user";
    }
}
