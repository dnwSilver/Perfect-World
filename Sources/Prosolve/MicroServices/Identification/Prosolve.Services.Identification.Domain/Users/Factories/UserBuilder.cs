using Sharpdev.SDK.Domain.Factories;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Users.Factories
{
    public class UserBuilder : EntityBuilderBase<IUserEntity>, IUserBuilder
    {
        /// <summary>
        ///     Установка адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        /// <returns>Адрес электронной для связи с клиентом.</returns>
        public IConfirmed<EmailAddress>? ContactEmailAddress { get; private set; }
        
        /// <summary>
        ///     Установка номера телефона указанного для получения обратной связи.
        /// </summary>
        /// <returns>Номер телефона для связи с клиентом.</returns>
        public IConfirmed<PhoneNumber>? ContactPhoneNumber { get; private set;  }

        /// <summary>
        ///     Установка фамилии имени и отчества пользователя.
        /// </summary>
        /// <returns>Фамилия имя и отчество пользователя.</returns>
        public FullName FullName { get; private set; }

        /// <summary>
        ///     Фиксация ФИО для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="fullName">ФИО.</param>
        /// <returns>Строитель для <see cref="IUserBuilder" />". /></returns>
        public UserBuilder SetFullName(FullName fullName)
        {
            this.FullName = fullName;
            return this;
        }

        /// <summary>
        ///     Фиксация контактного электронного адреса для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="confirmedEmailAddress">Контактный адрес электронной почты.</param>
        /// <returns>Строитель для <see cref="IUserBuilder" />". /></returns>
        public UserBuilder SetContactEmailAddress(IConfirmed<EmailAddress>? confirmedEmailAddress)
        {
            this.ContactEmailAddress = confirmedEmailAddress;
            
            return this;
        }

        /// <summary>
        ///     Фиксация контактного номера телефона для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="confirmedContactPhoneNumber">Контактный номер телефона.</param>
        /// <returns>Строитель для <see cref="IUserBuilder" />". /></returns>
        public UserBuilder SetContactPhoneNumber(IConfirmed<PhoneNumber>? confirmedContactPhoneNumber)
        {
            this.ContactPhoneNumber = confirmedContactPhoneNumber;
            
            return this;
        }
    }
}
