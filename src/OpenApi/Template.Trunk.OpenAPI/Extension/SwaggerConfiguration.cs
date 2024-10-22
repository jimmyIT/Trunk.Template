using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Polly;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;
using System.Text;
using Template.Trunk.Server.Application.Common.Constants;
using Template.Trunk.Server.Application.Common.Domain;
using Template.Trunk.Server.Application.Common.Domain.AppSettings;
using Template.Trunk.Shared.Constants.OpenAPI;

namespace Template.Trunk.OpenAPI.Extension
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services, IConfiguration config)
        {
            // Set up JWT token
            // Setting Jwt Config
            IConfiguration jwtConfigSection = config.GetSection(AppSettingsConst.JWTConfiguration);
            services.Configure<JWTSettings>(jwtConfigSection);

            IConfiguration swaggerDocSection = config.GetSection(AppSettingsConst.SwaggerDocConfiguration);
            services.Configure<List<SwaggerDocSettings>>(jwtConfigSection);

            JWTSettings? jwtConfigs = jwtConfigSection.Get<JWTSettings>();
            if (jwtConfigs == null || string.IsNullOrEmpty(jwtConfigs.Key))
            {
                throw new Exception("Missing JWT Key");
            }

            List<SwaggerDocSettings>? swaggerDocConfigs = swaggerDocSection.Get<List<SwaggerDocSettings>>();
            if (swaggerDocConfigs == null || swaggerDocConfigs.Count == 0)
                throw new Exception("Failed to get config settings.");

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
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
                    c.SwaggerDoc(
                        item?.Name,
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
                            },
                        });
                }

                // Add a security definition for Bearer token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter your Bearer token in the format **Bearer {your token}**",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                });

                // Add a security requirement
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType?.GetCustomAttributes(true)
                                                            .OfType<ApiVersionAttribute>()
                                                            .SelectMany(attr => attr.Versions);

                    return versions?.Any(v => $"v{v.ToString()}" == docName) ?? false;
                });
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                    {
                        options.ForwardDefaultSelector = context =>
                        {
                            string authorization = context.Request.Headers.Authorization;
                            return authorization?.Contains(ApiKeyConst.AuthenticationScheme, StringComparison.OrdinalIgnoreCase) is true ? ApiKeyConst.AuthenticationScheme : null;
                        };

                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidIssuer = jwtConfigs.Issuer,
                            ValidAudience = jwtConfigs.Audience,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigs.Key)),
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnChallenge = context =>
                            {
                                if (context.AuthenticateFailure == null &&
                                context.Error == null &&
                                context.ErrorDescription == null &&
                                context.ErrorUri == null)
                                {
                                    context.HandleResponse();
                                }
                                else
                                {
                                    // Handle authentication failure (e.g., invalid token).
                                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                    context.Response.ContentType = "application/json";
                                    var errorResponse = new ErrorMessage()
                                    {
                                        Code = "401",
                                        Message = "Unauthorized - You are not authorized to access this resource."
                                    };

                                    return context.Response.WriteAsJsonAsync(errorResponse);
                                }

                                return Task.CompletedTask;
                            },
                            OnForbidden = context =>
                            {
                                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                                context.Response.ContentType = "application/json";
                                var errorResponse = new ErrorMessage()
                                {
                                    Code = "403",
                                    Message = "Forbidden - You do not have permission to access this resource."
                                };

                                return context.Response.WriteAsJsonAsync(errorResponse);
                            },
                        };
                    });

            services.AddApiVersioning(options =>
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
        }

        public static void UseCustomSwagger(this IApplicationBuilder app, bool isDevelopment)
        {
            // Configure the HTTP request pipeline.
            if (isDevelopment)
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

        }
    }
}
