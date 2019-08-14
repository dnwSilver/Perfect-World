using Microsoft.IdentityModel.Tokens;

namespace Sharpdev.SDK.API
{
    /// <summary>
    ///     Набор параметров для настройки сервиса авторизации для сервиса.
    /// </summary>
    public interface IAuthorizationOptions
    {
        /// <summary>
        ///     Издатель ключа.
        /// </summary>
        string Issuer { get; }

        /// <summary>
        ///     Потребитель ключа.
        /// </summary>
        string Audience { get; }

        /// <summary>
        ///     Ключ шифрования.
        /// </summary>
        string Key { get; }

        /// <summary>
        ///     Время жизни ключа в минутах.
        /// </summary>
        int LifeTime { get; }

        /// <summary>
        ///     Ключ после шифрования.
        /// </summary>
        SymmetricSecurityKey GetSymmetricSecurityKey { get; }
    }
}
