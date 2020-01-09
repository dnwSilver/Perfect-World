using System.Security.Claims;

namespace Prosolve.Services.Identification
{
    /// <summary>
    ///     Сервис по управлению пользователями предоставляемый для бизнеса.
    /// </summary>
    internal class IdentificationService
    {
        /// <summary>
        ///     Авторизация пользователя.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>
        ///     Коллекция объектов <see cref="Claim" />, описывающих утверждения для пользователя.
        /// </returns>
        public ClaimsIdentity Authorize(string login, string password)
        {
            var claims = new []
                         {
                             new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                             new Claim(ClaimsIdentity.DefaultRoleClaimType, "Member")
                         };
            var claimsIdentity = new ClaimsIdentity(claims,
                                                    "Token",
                                                    ClaimsIdentity.DefaultNameClaimType,
                                                    ClaimsIdentity.DefaultRoleClaimType);

            //_logger.LogInformation($"Авторизация пользователя {login}");

            return claimsIdentity;
        }
    }
}
