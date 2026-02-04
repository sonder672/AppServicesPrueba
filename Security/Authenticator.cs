using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace StressApi.Security;

public static class Authenticator
{
    public static IServiceCollection AddJwtAuth(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var tenantId = configuration["AzureAd:TenantId"];
        var clientId = configuration["AzureAd:ClientId"];

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority =
                    $"https://login.microsoftonline.com/{tenantId}/v2.0";

                options.Audience = clientId;

                options.Events = JwtBearerLoggingEvents.Create(
                    services.BuildServiceProvider()
                        .GetRequiredService<ILoggerFactory>()
                        .CreateLogger("Security")
                );
            });

        services.AddAuthorization();

        return services;
    }
}
