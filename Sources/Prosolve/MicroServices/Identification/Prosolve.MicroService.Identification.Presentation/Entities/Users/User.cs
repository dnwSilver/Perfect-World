using Sharpdev.SDK.Domain.Entities;
using Sharpdev.SDK.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    /// <summary>
    ///     Пользователь информационной системы.
    /// </summary>
    internal class User : Entity<IUser>, IUser
    {
        /// <summary>
        ///     Конструктор для объекта <see cref="IUser" />.
        /// </summary>
        /// <param name="identifier">Уникальный идентификатор объекта.</param>
        /// <param name="currentVersion">Версия объекта.</param>
        /// <param name="fullName">Фамилия имя и отчество пользователя.</param>
        /// <param name="contactEmail">Контактный адрес электронной почты.</param>
        public User(IIdentifier<IUser> identifier,
                    int currentVersion,
                    FullName fullName,
                    IConfirmed<EmailAddress> contactEmail)
            : base(identifier, currentVersion)
        {
            this.FullName = fullName;
            this.ContactEmail = contactEmail;
        }

        /// <summary>
        ///     Текущий статус объекта.
        /// </summary>
        /// <returns>Статус объекта.</returns>
        public UserStatus Status { get; private set; }

        /// <summary>
        ///     Смена статуса.
        /// </summary>
        /// <param name="newStatus">Новый статус.</param>
        public void ChangeStatus(UserStatus newStatus)
        {
            this.Status = newStatus;
        }

        /// <summary>
        ///     Адрес электронной почты указанный для получения обратной связи.
        /// </summary>
        public IConfirmed<EmailAddress> ContactEmail { get; }

        /// <summary>
        ///     Фио пользователя.
        /// </summary>
        public FullName FullName { get; }
    }
}
