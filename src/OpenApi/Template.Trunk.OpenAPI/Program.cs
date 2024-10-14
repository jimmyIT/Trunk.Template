using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using Template.Trunk.Server.Application.Common.Constants;
using Template.Trunk.Server.Application.Common.Domain.AppSettings;
using Template.Trunk.Shared.Constants.OpenAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Set up JWT token
// Setting Jwt Config
IConfiguration jwtConfigSection = builder.Configuration.GetSection(AppSettingsConst.JWTConfiguration);
builder.Services.Configure<JWTSettings>(jwtConfigSection);

IConfiguration swaggerDocSection = builder.Configuration.GetSection(AppSettingsConst.SwaggerDocConfiguration);
builder.Services.Configure<List<SwaggerDocSettings>>(jwtConfigSection);

JWTSettings? jwtConfigs = jwtConfigSection.Get<JWTSettings>();
List<SwaggerDocSettings>? swaggerDocConfigs = swaggerDocSection.Get<List<SwaggerDocSettings>>();
if (swaggerDocConfigs == null || swaggerDocConfigs.Count == 0)
    throw new Exception("Failed to get config settings.");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
    c.TagActionsBy(api =>
    {
        if (api.GroupName != null)
        {
            return new[] { api.GroupName };
        }
        if (api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
        {
            return new[] { controllerActionDescriptor.ControllerName };
        }
        throw new InvalidOperationException("Unable to determine tag for endpoint.");
    });
    c.DocInclusionPredicate((name, api) => true);

    foreach (var item in swaggerDocConfigs)
    {
        OpenApiInfoSettings? openAPIInfoConfigs = item?.OpenApiInfo;
        OpenApiContactSettings? openAPIContactConfigs = item?.OpenApiContact;
        OpenApiLicenseSettings? openAPILiecenseConfigs = item?.OpenApiLicense;
        c.SwaggerDoc(item?.Name,
        new OpenApiInfo
        {
            Title = openAPIInfoConfigs?.Title,
            Version = openAPIInfoConfigs?.Version,
            Description = item?.Description,
            TermsOfService = new Uri(item?.TermsOfServiceUrl ?? "https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = openAPIContactConfigs?.Name,
                Email = openAPIContactConfigs?.Email,
                Url = new Uri(openAPIContactConfigs?.Url ?? "https://example.com/phuong.vt5614"),
            },
            License = new OpenApiLicense
            {
                Name = openAPILiecenseConfigs?.Name,
                Url = new Uri(openAPILiecenseConfigs?.Url ?? "https://example.com/license"),
            }
        });
    }    
    
    c.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

        var versions = methodInfo.DeclaringType?.GetCustomAttributes(true)
                                                .OfType<ApiVersionAttribute>()
                                                .SelectMany(attr => attr.Versions);

        return versions?.Any(v => $"v{v.ToString()}" == docName) ?? false;
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigs?.Key ?? string.Empty)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                        new HeaderApiVersionReader("x-api-version"),
                                                        new MediaTypeApiVersionReader("x-api-version"));
    options.ReportApiVersions = true;
}).AddMvc().AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstitutionFormat = "VVVV"; // Change version in path fron 'v1' to 'v1.0'
    options.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
        options.RouteTemplate = "swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(DocExpansion.None);
        options.ConfigObject.AdditionalItems.Add("tagsSorter", "alpha");

        options.SwaggerEndpoint($"/swagger/v{ApiSettingsConst.Version.V1_0}/swagger.json", $"Api Version {ApiSettingsConst.Version.V1_0}");
        options.SwaggerEndpoint($"/swagger/v{ApiSettingsConst.Version.V2_0}/swagger.json", $"Api Version {ApiSettingsConst.Version.V2_0}");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
