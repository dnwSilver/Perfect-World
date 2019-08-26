using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;
using Sharpdev.SDK.Types.PhoneNumbers;

namespace Prosolve.Services.Identification.Entities.Users
{
    /// <summary>
    ///     Пользователь информационной системы.
    /// </summary>
    internal class UserEntity : Entity<IUserEntity>, IUserEntity
    {
        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public UserStatus Status { get; private set; }

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
        public FullName FullName { get; }

        /// <summary>
        ///     Конструктор для объекта <see cref="IUserEntity" />.
        /// </summary>
        /// <param name="userBuilder">Строитель для объекта.</param>
        public UserEntity(IUserBuilder userBuilder)
            : base(userBuilder.Identifier, userBuilder.Version)
        {
            this.FullName = userBuilder.FullName;
            this.ContactEmail = userBuilder.ContactEmailAddress;
            this.ContactPhoneNumber = userBuilder.ContactPhoneNumber;
        }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(UserStatus newStatus)
        {
            this.Status = newStatus;
        }
    }
}
