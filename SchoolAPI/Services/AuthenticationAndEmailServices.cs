using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.IdentityModel.Tokens;
using SchoolAPI.Configuration;
using System.Text;

namespace SchoolAPI.Services
{
    public static class AuthenticationAndEmailServices
    {
        public static void AddAuthenticationAndEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de JWT
            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            // Configuración de Email
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.AddSingleton<IEmailSender, EmailServices>();

            // Configuración de autenticación
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(configuration.GetSection("JwtConfig:Secret").Value);

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    // Esta opción se deja en falso en el entorno de desarrollo, pero en producción debe ir verdadero
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true,
                };
            });
        }
    }
}
