using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Prosolve.MicroService.Identification.API.Models.Tokens;

using Sharpdev.SDK.API;

namespace Prosolve.MicroService.Identification.API.Controllers
{
    /// <summary>
    ///     Контроллер для работы объектов учетных записей пользователей.
    /// </summary>
    [AllowAnonymous]
    [ApiVersionNeutral]
    public class TokenController : SharpdevControllerBase
    {
        /// <summary>
        ///     Сервис для управления пользователями.
        /// </summary>
        private readonly IIdentityService _identityService;

        /// <summary>
        ///     Конструктор для контроллера <see cref="TokenController" />.
        /// </summary>
        /// <param name="identityService">Сервис для управления пользователями.</param>
        public TokenController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        ///     Возвращает ключ авторизованного пользователя.
        /// </summary>
        /// <param name="request">Запрос, содержащий логин и пароль.</param>
        [HttpPost]
        public IActionResult PostToken([FromBody][Required]TokenRequest request)
        {
            var authorizeResult = _identityService.Authorize(request.Login, request.Password);

            if (authorizeResult.Failure)
                return this.BadRequest(new { ErrorMessage = "Неправильная пара пользователь-пароль." });

            var identity = authorizeResult.Value;
            var now = DateTime.UtcNow;
            var authorizationOptions = new AuthorizationOptions();

            // создаем JWT-ключ
            var jwt = new JwtSecurityToken(authorizationOptions.Issuer,
                                           authorizationOptions.Audience,
                                           notBefore: now,
                                           claims: identity.Claims,
                                           expires: now.Add(TimeSpan.FromMinutes(authorizationOptions.LifeTime)),
                                           signingCredentials: new SigningCredentials(
                                               authorizationOptions.GetSymmetricSecurityKey,
                                               SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new { accessToken = encodedJwt, login = identity.Name };

            return Ok(response);
        }
    }
}
