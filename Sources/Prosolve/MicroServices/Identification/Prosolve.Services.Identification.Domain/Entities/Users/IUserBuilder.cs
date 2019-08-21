using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Entities.Users
{
    /// <summary>
    ///     Строитель для объекта <see cref="IUserEntity" />.
    /// </summary>
    public interface IUserBuilder : IEntityBuilder<IUserEntity>
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <returns>Адрес электронной для связи с клиентом.</returns>
        IConfirmed<EmailAddress> ContactEmailAddress { get; }

        /// <summary>
        ///     Установка номера телефона указанного для получения обратной связи.
        /// </summary>
        /// <returns>Номер телефона для связи с клиентом.</returns>
        IConfirmed<PhoneNumber> ContactPhoneNumber { get; }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <returns>Фамилия имя и отчество пользователя.</returns>
        FullName FullName { get; }

        /// <summary>
        ///     Фиксация ФИО для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="fullName">ФИО.</param>
        /// <returns>Строитель для <see cref="IUserBuilder" />". /></returns>
        IUserBuilder SetFullName(FullName fullName);

        /// <summary>
        ///     Фиксация контактного электронного адреса для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="confirmedEmailAddress">Контактный адрес электронной почты.</param>
        /// <returns>Строитель для <see cref="IUserBuilder" />". /></returns>
        IUserBuilder SetContactEmailAddress(IConfirmed<EmailAddress> confirmedEmailAddress);

        /// <summary>
        ///     Фиксация контактного номера телефона для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="confirmedContactPhoneNumber">Контактный номер телефона.</param>
        /// <returns>Строитель для <see cref="IUserBuilder" />". /></returns>
        IUserBuilder SetContactPhoneNumber(IConfirmed<PhoneNumber> confirmedContactPhoneNumber);
    }
}
