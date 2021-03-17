using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FoodPal.Auth.RandomStuff
{
    public class CustomAuthHandlers
    {
        public class CustomAuthOptions: AuthenticationSchemeOptions
        {
            public string RandomStuffWeNeed { get; set; }
        }

        public class CustomAuthHandler: AuthenticationHandler<CustomAuthOptions>
        {
            public CustomAuthHandler(
                IOptionsMonitor<CustomAuthOptions> options,
                ILoggerFactory logger,
                UrlEncoder urlEncoder,
                ISystemClock clock
                ) : base(options, logger, urlEncoder, clock) { }

            protected override Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                JwtSecurityToken securityToken;
                
                if(Request.Headers.ContainsKey("Authorization"))
                {
                    try 
                    {
                        var token = Request.Headers["Authorization"].ToString();
                        var tokenType = token.Split(" ")[0];

                        if(tokenType == "Bearer")
                        {
                            var tokenValue = token.Split(" ")[1];
                            var tokenDecoder = new JwtSecurityTokenHandler();
                            securityToken = tokenDecoder.ReadJwtToken(tokenValue);

                            var identity = new ClaimsIdentity(securityToken.Claims.Where(w=> w.Type != JwtClaimTypes.Role), "CustomAuthScheme");
                            identity.AddClaim(new Claim(
                                identity.RoleClaimType, securityToken.Claims.FirstOrDefault(f => f.Type == JwtClaimTypes.Role).Value));
                            
                            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), "CustomAuthScheme");
                            return Task.FromResult(AuthenticateResult.Success(ticket));
                        }
                    }
                    catch (Exception ex)
                    {
                        this.Logger.LogError(ex, "Caught Exception");
                    }
                }

                return Task.FromResult(AuthenticateResult.Fail("GTFO"));
            }
        }
    }
}
