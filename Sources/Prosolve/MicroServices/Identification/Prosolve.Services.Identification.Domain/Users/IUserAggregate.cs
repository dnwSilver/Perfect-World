using Prosolve.Services.Identification.Users.Events;

using Sharpdev.SDK.Domain;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Users
{

    /// <summary>
    ///     Пользователь информационной системы.
    /// </summary>
    public interface IUserAggregate: IAggregate<IUserAggregate>
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
        FullName FullName { get; }

        /// <summary>
        /// Подготовка
        /// </summary>
        /// <param name="command">Набор данных для проведения действия создания пользователя.</param>
        /// <returns>Событие с информацией о созданном пользователе.</returns>
        CreateUserDomainEvent Process(CreateUserDomainCommand command);

        /// <summary>
        /// Восстановление агрегата до состояния после регистрации.
        /// </summary>
        /// <param name="event">Событие вызвавшее изменение агрегата.</param>
        void Apply(CreateUserDomainEvent @event);
    }
}
