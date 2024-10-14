namespace Template.Trunk.Server.Application.Common.Domain.AppSettings;

public class SwaggerDocSettings
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string TermsOfServiceUrl { get; set; } = string.Empty;
    public OpenApiInfoSettings? OpenApiInfo { get; set; }
    public OpenApiContactSettings? OpenApiContact { get; set; }
    public OpenApiLicenseSettings? OpenApiLicense { get; set; }
}
