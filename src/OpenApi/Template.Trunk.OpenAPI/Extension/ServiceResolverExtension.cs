using Microsoft.AspNetCore.Identity;
using Template.Trunk.Shared.Cryptography;

namespace Template.Trunk.OpenAPI.Extension
{
    public static class ServiceResolverExtension
    {
        public static void ResolveScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher<object>, PasswordHasher<object>>();
            services.AddScoped<IHasher, Hasher>();
        }

        public static void ResolveSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
