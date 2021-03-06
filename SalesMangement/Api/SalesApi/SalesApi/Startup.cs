using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(SalesApi.Startup))]

namespace SalesApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            string securityKey = "0948129dsajsbdiqdbp";

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "abcd@domain.in",
                    ValidAudience = "Users",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                }
            });
        }
    }
}
