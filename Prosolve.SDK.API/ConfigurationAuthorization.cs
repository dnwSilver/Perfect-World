using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Sharpdev.SDK.API
{
    /// <summary>
    ///     Набор настроек для микросервисов.
    /// </summary>
    public static partial class Configuration
    {
        /// <summary>
        ///     Настраиваем сервис для авторизации пользователей.
        /// </summary>
        /// <param name="services">Сервис для которого настраиваем.</param>
        /// <param name="authorizationOptions">Настройки авторизации.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigurationAuthorization(this IServiceCollection services,
                                                                    IAuthorizationOptions authorizationOptions)
        {
            var tokenValidationParameters = new TokenValidationParameters
                                            {
                                                ValidateIssuerSigningKey = true,
                                                ValidateAudience = true,
                                                ValidateLifetime = true,
                                                ValidateIssuer = true,
                                                ValidIssuer = authorizationOptions.Issuer,
                                                ValidAudience = authorizationOptions.Audience,
                                                IssuerSigningKeys =
                                                    new SecurityKey[] { authorizationOptions.GetSymmetricSecurityKey }
                                            };

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o =>
                    {
                        o.IncludeErrorDetails = true;
                        o.TokenValidationParameters = tokenValidationParameters;
                        o.Events = new JwtBearerEvents
                                   {
                                       OnAuthenticationFailed = c =>
                                       {
                                           c.NoResult();
                                           c.Response.StatusCode = StatusCodes.Status401Unauthorized;
                                           c.Response.ContentType = "text/plain";

                                           return c.Response.WriteAsync(c.Exception.ToString());
                                       }
                                   };
                    });

            return services;
        }
    }
}
