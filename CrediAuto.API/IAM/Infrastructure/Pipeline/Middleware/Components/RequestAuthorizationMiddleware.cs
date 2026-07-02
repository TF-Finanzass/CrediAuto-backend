using System;
using System.Linq;
using System.Threading.Tasks;
using CrediAuto.API.IAM.Application.Internal.OutboundServices;
using CrediAuto.API.IAM.Domain.Model.Queries;
using CrediAuto.API.IAM.Domain.Services;
using CrediAuto.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Microsoft.AspNetCore.Http;

namespace CrediAuto.API.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("Entering InvokeAsync");

        // Deja pasar las peticiones OPTIONS del preflight de CORS sin autorizar,
        // ya que en esta etapa GetEndpoint() puede devolver null y romper el middleware.
        if (HttpMethods.IsOptions(context.Request.Method))
        {
            Console.WriteLine("OPTIONS preflight request, skipping authorization");
            await next(context);
            return;
        }

        var endpoint = context.Request.HttpContext.GetEndpoint();
        var allowAnonymous = endpoint?.Metadata
            .Any(m => m.GetType() == typeof(AllowAnonymousAttribute)) ?? false;

        Console.WriteLine($"Allow Anonymous is {allowAnonymous}");

        if (allowAnonymous)
        {
            Console.WriteLine("Skipping authorization");
            await next(context);
            return;
        }

        Console.WriteLine("Entering authorization");

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token == null)
        {
            Console.WriteLine("No token provided. Returning 401.");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        var userId = await tokenService.ValidateToken(token);

        if (userId == null)
        {
            Console.WriteLine("Invalid token. Returning 401.");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return;
        }

        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);

        var user = await userQueryService.Handle(getUserByIdQuery);

        Console.WriteLine("Successful authorization. Updating Context...");
        context.Items["User"] = user;
        Console.WriteLine("Continuing with Middleware Pipeline");

        await next(context);
    }
}