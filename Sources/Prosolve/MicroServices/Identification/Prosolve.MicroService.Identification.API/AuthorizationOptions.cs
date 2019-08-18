using System.Text;

using Microsoft.IdentityModel.Tokens;

using Sharpdev.SDK.API;

namespace Prosolve.MicroService.Identification.API
{
    /// <summary>
    ///     Набор параметров для настройки сервиса авторизации для сервиса <see cref="IdentityService"/>.
    ///
    /// </summary>
    public class AuthorizationOptions : IAuthorizationOptions
    {
        // todo: Вынести в файл с настройками ключ, время жизни.
        /// <summary>
        ///     Издатель ключа.
        /// </summary>
        public string Issuer { get; } = $"{nameof(IdentityService)}ClientIssue";

        /// <summary>
        ///     Потребитель ключа.
        /// </summary>
        public string Audience { get; } = $"{nameof(IdentityService)}Client";

        /// <summary>
        ///     Ключ шифрования.
        /// </summary>
        public string Key { get; } = "6Q$Jl{xu}QkWrAwbVNxHeerjadji-sdasjKLSJD12*(@ad#&*#JAK@&";

        /// <summary>
        ///     Время жизни ключа в минутах.
        /// </summary>
        public int LifeTime { get; } = 60;

        /// <summary>
        ///     Ключ после шифрования.
        /// </summary>
        public SymmetricSecurityKey GetSymmetricSecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.Key));
    }
}
