using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API02.Presentation.Configurations
{
    public class JwtConfiguration
    {
        public static void AddJwt(IServiceCollection services, 
            IConfiguration configuration)
        {
            var settings = configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(settings);

            var jwtSettings = settings.Get<JwtSettings>();
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

            services.AddAuthentication(
                auth =>
                {
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                        ValidateIssuer = false,
                        ValidateAudience = false

                    };
                }
            );

        services.AddTransient(map => new TokenSettings(jwtSettings));

        }
    }
}
