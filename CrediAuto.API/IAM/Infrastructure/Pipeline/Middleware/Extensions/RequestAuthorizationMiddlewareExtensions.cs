using CrediAuto.API.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace CrediAuto.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;

public static class RequestAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestAuthorizationMiddleware>();
    }
}