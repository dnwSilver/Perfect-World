using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Users.Factories
{
    /// <summary>
    ///     Строитель для объекта <see cref="IUserAggregate" />.
    /// </summary>
    public interface IUserBuilder : IEntityBuilder<IUserAggregate>
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <returns>Адрес электронной для связи с клиентом.</returns>
        IConfirmed<EmailAddress>? ContactEmailAddress { get; }

        /// <summary>
        ///     Установка номера телефона указанного для получения обратной связи.
        /// </summary>
        /// <returns>Номер телефона для связи с клиентом.</returns>
        IConfirmed<PhoneNumber>? ContactPhoneNumber { get; }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <returns>Фамилия имя и отчество пользователя.</returns>
        FullName FullName { get; }
    }
}
