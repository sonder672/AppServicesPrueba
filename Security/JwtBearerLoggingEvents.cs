using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace StressApi.Security;

public static class JwtBearerLoggingEvents
{
    public static JwtBearerEvents Create(ILogger logger)
    {
        return new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                logger.LogWarning(
                    "Unauthorized API access attempt. Path: {Path}, IP: {IP}",
                    context.HttpContext.Request.Path,
                    context.HttpContext.Connection.RemoteIpAddress
                );

                return Task.CompletedTask;
            },

            OnAuthenticationFailed = context =>
            {
                logger.LogWarning(
                    context.Exception,
                    "Authentication failed. Path: {Path}",
                    context.HttpContext.Request.Path
                );

                return Task.CompletedTask;
            }
        };
    }
}
