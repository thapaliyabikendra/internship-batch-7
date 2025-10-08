using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assisment.Infrastructure.AuthHandeler;

public class ApiKeyFilter : IAsyncActionFilter
{
    private readonly IConfiguration _configuration;
    private const string ApiKeyHeaderName = "X-Api-key";

    public ApiKeyFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        
        var configuredKey = _configuration["Authentication:ApiKey"];

        // Check if header exists
        if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out StringValues extractedApiKey))
        {
            context.Result = new ContentResult
            {
                StatusCode = 401,
                Content = "API Key Missing"
            };
            return;
        }

        // Check if key is valid
        if (!configuredKey.Equals(extractedApiKey.ToString()))
        {
            context.Result = new ContentResult
            {
                StatusCode = 403,
                Content = "Invalid API Key"
            };
            return;
        }

       
        await next();
    }
}

