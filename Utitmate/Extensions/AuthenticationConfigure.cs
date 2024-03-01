using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Utitmate.Extensions
{
    public static class AuthenticationConfigure
    {
        public static void ConfigureAuthServices(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    // Configure JWT bearer authentication options
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersecretunguesstextjejieijjrorjff")),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // Add authorization services
            services.AddAuthorization();

            // Other service configurations...
        }

    }
}
