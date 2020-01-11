using Prosolve.Services.Identification.Users.Events;
using Prosolve.Services.Identification.Users.Factories;

using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Users
{
    /// <summary>
    ///     Пользователь информационной системы.
    /// </summary>
    internal class UserAggregate: Entity<IUserAggregate>, IUserAggregate
    {
        /// <summary>
        ///     Адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        public IConfirmed<EmailAddress>? ContactEmail { get; }

        /// <summary>
        ///     Контактный телефон.
        /// </summary>
        public IConfirmed<PhoneNumber>? ContactPhoneNumber { get; }

        /// <summary>
        ///     Фио пользователя.
        /// </summary>
        public IFullName FullName { get; }

        public CreateUserDomainEvent Process(CreateUserDomainCommand command)
        {
            return new CreateUserDomainEvent(command.Id, command.CreationDate, command.Data);
        }

        public void Apply(CreateUserDomainEvent @event)
        {
            //todo Необходимо реализовать метод.Gj
        }

        /// <summary>
        ///     Конструктор для объекта <see cref="IUserAggregate" />.
        /// </summary>
        /// <param name="userBuilder">Строитель для объекта.</param>
        public UserAggregate(IUserBuilder userBuilder)
                : base(userBuilder.Identifier, userBuilder.Version)
        {
            FullName = userBuilder.FullName;
            ContactEmail = userBuilder.ContactEmailAddress;
            ContactPhoneNumber = userBuilder.ContactPhoneNumber;
        }
    }
}
