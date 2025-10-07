using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Assisment.Infrastructure.AuthHandeler;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock):
        base(options,logger,encoder,clock)
    {
        
    }
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return Task.FromResult(AuthenticateResult.Fail("Missing Authenticator Header"));
        }

        try
        { 
            var authHeader = Request.Headers["Authorization"].ToString();
            var encodedCreds = authHeader.Substring("Basic".Length).Trim();
            var credentials=Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds)).Split(':');

            var userName=credentials[0];
            var password=credentials[1];


            if(userName== "User" && password == "pass")
            {
                var claims = new[] { new Claim(ClaimTypes.Name, userName) };
                var claimIdentity = new ClaimsIdentity(claims, Scheme.Name);
                var principle = new ClaimsPrincipal(claimIdentity);
                var ticket = new AuthenticationTicket(principle, Scheme.Name);
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            else
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Username or Password"));
            }
        
        } catch(Exception ex)
        {
            return Task.FromResult(AuthenticateResult.Fail("Failed Authenticator"));
        }
    }


}
