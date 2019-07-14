using Microsoft.IdentityModel.Tokens;

namespace Sharpdev.SDK.API
{
    /// <summary>
    ///     Набор параметров для настройки сервиса авторизации для микросервиса.
    /// </summary>
    public interface IAuthorizationOptions
    {
        /// <summary>
        ///     Издатель токена.
        /// </summary>
        string Issuer { get; }

        /// <summary>
        ///     Потребитель токена.
        /// </summary>
        string Audience { get; }

        /// <summary>
        ///     Ключ шифрования.
        /// </summary>
        string Key { get; }

        /// <summary>
        ///     Время жизни токена в минутах.
        /// </summary>
        int LifeTime { get; }

        /// <summary>
        ///     Ключ после шифрования.
        /// </summary>
        SymmetricSecurityKey GetSymmetricSecurityKey { get; }
    }
}
