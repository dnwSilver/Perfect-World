using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prosolve.MicroService.Identity.API.Models.Tokens
{
    /// <summary>
    /// Запрос на получение ключа авторизации.
    /// </summary>
    public class TokenRequest
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        [DisplayName("Имя пользователя")]
        [StringLength(50, MinimumLength = 5)]
        public string Login { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        [DisplayName("Пароль")]
        [StringLength(50, MinimumLength = 1)]
        public string Password { get; set; }
    }
}
