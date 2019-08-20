using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.Services.Identification.Entities.Users
{
    /// <summary>
    ///     Строитель для объекта <see cref="IUser" />.
    /// </summary>
    public interface IUserBuilder : IEntityBuilder<IUser>
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <returns>Адрес электронной для связи с клиентом.</returns>
        IConfirmed<EmailAddress> ContactEmailAddress { get; set; }
        
        /// <summary>
        ///     Установка номера телефона указанного для получения обратной связи.
        /// </summary>
        /// <returns>Номер телефона для связи с клиентом.</returns>
        IConfirmed<EmailAddress> ContactPhoneNumber { get; set; }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <returns>Фамилия имя и отчество пользователя.</returns>
        FullName FullName { get; set; }
    }
}
