using System;

using Sharpdev.SDK.Layers.Domain.Entities;
using Sharpdev.SDK.Layers.Kernel;
using Sharpdev.SDK.Types.EmailAddresses;
using Sharpdev.SDK.Types.FullNames;

namespace Prosolve.MicroService.Identity.Entities.Users
{
    internal class User : Entity<IUser>, IUser
    {
        /// <summary>
        ///     Конструктор для объекта <see cref="IUser" />.
        /// </summary>
        /// <param name="identifier">Уникальный идентификатор объекта.</param>
        /// <param name="currentVersion">Версия объекта.</param>
        public User(IIdentifier<IUser> identifier, int currentVersion)
            : base(identifier, currentVersion)
        {
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
            Status = newStatus;
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
