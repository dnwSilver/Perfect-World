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
    public class UserBuilder : EntityBuilderBase<IUserAggregate>, IUserBuilder
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <returns>Адрес электронной для связи с клиентом.</returns>
        public IConfirmed<EmailAddress>? ContactEmailAddress { get; set; }
        
        /// <summary>
        ///     Установка номера телефона указанного для получения обратной связи.
        /// </summary>
        /// <returns>Номер телефона для связи с клиентом.</returns>
        public IConfirmed<PhoneNumber>? ContactPhoneNumber { get; set; }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <returns>Фамилия имя и отчество пользователя.</returns>
        public IFullName FullName { get; set; }
    }
}
