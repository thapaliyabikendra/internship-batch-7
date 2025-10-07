using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Infrastructure.AuthHandeler;

public class ApiKeyHandler 
{
    private readonly RequestDelegate _next;
    private const string ApiKeyHeaderName = "X-Api-key";
    private const string ApiKey = "MySecretApiKey";

    public ApiKeyHandler(RequestDelegate next)
    {
        _next = next;
    }


    public async Task InvokeAsync(HttpContext context)
    {
        if(!context.Request.Headers.TryGetValue(ApiKeyHeaderName,out var excratedApiKey))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Api Key Missing");
            return;
        }if (!ApiKey.Equals(excratedApiKey))
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Invalid Api Key ");
            return;
        }

        await _next(context);
    }
}
