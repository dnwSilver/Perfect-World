using Prosolve.Services.Identification.Users;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Testing;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identity.UnitTest.Users.ObjectGenerators
{
    /// <summary>
    ///     Заглушка для процесса <see cref="IUserBuilder" />.
    /// </summary>
    internal class UserBuilderGenerator : TestObjectGeneratorBase<IUserBuilder>
    {
        private IConfirmed<EmailAddress> _emailAddress;
        private IConfirmed<PhoneNumber> _phoneNumber;

        private FullName _fullName;

        private IIdentifier<IUserEntity> _userIdentifier;

        /// <summary>
        ///     Создание объекта.
        /// </summary>
        /// <param name="stubNumber">Порядковый номер создаваемого объекта.</param>
        /// <returns>Созданный объект, размещённый в куче.</returns>
        protected override IUserBuilder AllocateStub(int stubNumber)
        {
            var userBuilder = new UserBuilder()
                              .SetFullName(this._fullName)
                              .SetContactEmailAddress(this._emailAddress)
                              .SetContactPhoneNumber(this._phoneNumber)
                              .SetIdentifier(this._userIdentifier)
                              .SetVersion(1) as IUserBuilder;

            return userBuilder;
        }
        
        /// <summary>
        ///     Заполнение идентификатора пользователя.
        /// </summary>
        /// <param name="userIdentifier">Идентификатор пользователя.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUserEntity" />.</returns>
        public UserBuilderGenerator With(IIdentifier<IUserEntity> userIdentifier)
        {
            this._userIdentifier = userIdentifier;

            return this;
        }

        /// <summary>
        ///     Заполнение идентификатора пользователя.
        /// </summary>
        /// <param name="fullName">ФИО клиента.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUserEntity" />.</returns>
        public UserBuilderGenerator With(FullName fullName)
        {
            this._fullName = fullName;

            return this;
        }

        /// <summary>
        ///     Заполнение контактного адреса электронной почты.
        /// </summary>
        /// <param name="contactEmail">Электронный адрес для контакта.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUserEntity" />.</returns>
        public UserBuilderGenerator With(IConfirmed<EmailAddress> contactEmail)
        {
            this._emailAddress = contactEmail;

            return this;
        }
        
        

        /// <summary>
        ///     Заполнение телефонного номера.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона для контакта.</param>
        /// <returns>Строитель для заглушки объекта <see cref="IUserEntity" />.</returns>
        public UserBuilderGenerator With(IConfirmed<PhoneNumber> phoneNumber)
        {
            this._phoneNumber = phoneNumber;

            return this;
        }
    }
}
